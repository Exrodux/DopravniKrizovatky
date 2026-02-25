using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace DopravniKrizovatky
{
    public partial class PracticeForm : Form
    {
        private Scenario currentScenario;
        private Random random = new Random();
        private string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../assets/images");

        private int currentStep = 0;
        private int score = 100;
        private Timer animationTimer;
        private Vehicle animatingVehicle = null;
        private float animationProgress = 0f;
        private float animationSpeed = 0.03f;

        public PracticeForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;

            this.FormClosed += PracticeForm_FormClosed;

            animationTimer = new Timer();
            animationTimer.Interval = 20;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        

        private void PracticeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainForm().Show();
        }

        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
            string folder = "../../scenarios";
            if (!Directory.Exists(folder)) folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../scenarios");

            if (!Directory.Exists(folder)) { MessageBox.Show("Složka scenarios nenalezena."); return; }
            string[] files = Directory.GetFiles(folder, "*.json");
            if (files.Length == 0) { MessageBox.Show("Žádné scénáře."); return; }

            try
            {
                string json = File.ReadAllText(files[random.Next(files.Length)]);
                currentScenario = JsonSerializer.Deserialize<Scenario>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                currentStep = 0; score = 100;
                animationTimer.Stop(); animatingVehicle = null;

                if (currentScenario.Vehicles != null)
                {
                    foreach (var v in currentScenario.Vehicles)
                    {
                        v.IsFinished = false; v.CurrentX = v.X; v.CurrentY = v.Y; v.CurrentRotation = v.Rotation;
                    }
                }
                lblTitle.Text = currentScenario.Title;

             
                lblDescription.Text = "Klikni na vozidlo, které má přednost.";
                lblDescription.ForeColor = Color.White; 

                if (lblScore != null) lblScore.Text = "Body: 100";
                pbMap.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show("Chyba: " + ex.Message); }
        }

        private void pbMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentScenario == null || animationTimer.Enabled) return;
            foreach (var v in currentScenario.Vehicles)
            {
                if (v.IsFinished) continue;
                if (new Rectangle(v.X, v.Y, 60, 40).Contains(e.Location))
                {
                    CheckAnswer(v); return;
                }
            }
        }

        private void CheckAnswer(Vehicle v)
        {
            if (v.CorrectOrder == currentStep + 1)
            {
                lblDescription.Text = "Správně! Vozidlo odjíždí.";
                lblDescription.ForeColor = Color.Lime; 

                animatingVehicle = v;
                animatingVehicle.CurrentX = v.X; animatingVehicle.CurrentY = v.Y; animatingVehicle.CurrentRotation = v.Rotation;
                animationProgress = 0f;
                animationTimer.Start();
                currentStep++;
            }
            else
            {
                score = Math.Max(0, score - 20);
                lblDescription.Text = "Chyba! Nedal jsi přednost.";
                lblDescription.ForeColor = Color.Red; 
            }
            if (lblScore != null) lblScore.Text = $"Body: {score}";
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (animatingVehicle == null) { animationTimer.Stop(); return; }
            animationProgress += animationSpeed;

            if (animationProgress >= 1.0f)
            {
                animationProgress = 1.0f; animatingVehicle.IsFinished = true;
                animationTimer.Stop(); animatingVehicle = null;

                
                if (currentStep == 1 && currentScenario.Signs != null)
                {
                    foreach (var sign in currentScenario.Signs)
                    {
                        if (sign.ImageName.ToLower().Contains("zelena"))
                            sign.ImageName = "semafor_cervena.png";
                        else if (sign.ImageName.ToLower().Contains("cervena"))
                            sign.ImageName = "semafor_zelena.png";
                    }
                }
                

                if (currentStep >= currentScenario.Vehicles.Count)
                {
                    lblDescription.Text = "Křižovatka je volná. Výborně!";
                    lblDescription.ForeColor = Color.Cyan;

                    SaveScoreToHistory(); // Sledování úspěšnosti
                    MessageBox.Show($"Křižovatka dokončena! Tvoje skóre: {score}\nVýsledek byl uložen do historie.", "Hotovo");
                }
                else
                {
                    lblDescription.Text = "Kdo jede dál?";
                    lblDescription.ForeColor = Color.White;
                }
                pbMap.Invalidate(); return; // Překreslení scény s novými barvami semaforů
            }

            // Výpočet pohybu (Bézierova křivka nebo Lerp)
            if (animatingVehicle.ControlX.HasValue && animatingVehicle.ControlY.HasValue)
            {
                float t = animationProgress; float u = 1 - t;
                animatingVehicle.CurrentX = (u * u * animatingVehicle.X) + (2 * u * t * animatingVehicle.ControlX.Value) + (t * t * animatingVehicle.TargetX);
                animatingVehicle.CurrentY = (u * u * animatingVehicle.Y) + (2 * u * t * animatingVehicle.ControlY.Value) + (t * t * animatingVehicle.TargetY);
            }
            else
            {
                animatingVehicle.CurrentX = Lerp(animatingVehicle.X, animatingVehicle.TargetX, animationProgress);
                animatingVehicle.CurrentY = Lerp(animatingVehicle.Y, animatingVehicle.TargetY, animationProgress);
            }
            animatingVehicle.CurrentRotation = Lerp(animatingVehicle.Rotation, animatingVehicle.TargetRotation, animationProgress);
            pbMap.Invalidate();
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            if (currentScenario == null) return;

          
            string bgPath = FindImagePath(currentScenario.BackgroundImage);
            if (File.Exists(bgPath))
                using (Image bg = Image.FromFile(bgPath)) e.Graphics.DrawImage(bg, 0, 0, pbMap.Width, pbMap.Height);
            else e.Graphics.Clear(Color.LightGray);

           
            if (currentScenario.Signs != null)
            {
                foreach (var sign in currentScenario.Signs)
                {
                    string p = FindImagePath(sign.ImageName);
                    if (File.Exists(p)) using (Image img = Image.FromFile(p)) e.Graphics.DrawImage(img, sign.X, sign.Y, 50, 50);
                }
            }

          
            if (currentScenario.Vehicles != null)
            {
                foreach (var v in currentScenario.Vehicles)
                {
                 
                    if (v.IsFinished && v != animatingVehicle) continue;

                    string p = FindImagePath(v.ImageName);
                    if (!File.Exists(p)) continue;

                    using (Image img = Image.FromFile(p))
                    {
                        var state = e.Graphics.Save();

                        // Určení aktuální polohy
                        bool useCurrent = (v == animatingVehicle) || v.IsFinished;
                        float dx = useCurrent ? v.CurrentX : v.X;
                        float dy = useCurrent ? v.CurrentY : v.Y;
                        float rot = useCurrent ? v.CurrentRotation : v.Rotation;

                        // --- TRANSFORMACE SOUŘADNIC AUTA (STŘED OTÁČENÍ) ---
                        e.Graphics.TranslateTransform(dx + 30, dy + 20); // Posun na střed auta
                        e.Graphics.RotateTransform(rot);                 // Otočení
                        e.Graphics.DrawImage(img, -30, -20, 60, 40);     // Vykreslení (vycentrované)

                        // --- BLINKRY (SOUŘADNICE, KTERÉ JSI CHTĚL) ---
                        if (!v.IsFinished && !string.IsNullOrEmpty(v.TurnSignal) && v.TurnSignal != "None")
                        {
                            int blinkrX = -22;        // Pozice na délku
                            int blinkrY_Left = -15;   // Pozice nahoře
                            int blinkrY_Right = 7;    // Pozice dole
                            int size = 6;             // Velikost

                            if (v.TurnSignal == "Left")
                                e.Graphics.FillEllipse(Brushes.Orange, blinkrX, blinkrY_Right, size, size);

                            if (v.TurnSignal == "Right")
                                e.Graphics.FillEllipse(Brushes.Orange, blinkrX, blinkrY_Left, size, size);
                        }

                        e.Graphics.Restore(state);

                        // --- TEXT NAD AUTEM (BÍLÝ S ČERNÝM STÍNEM) ---
                        if (!v.IsFinished)
                        {
                            using (Font font = new Font("Arial", 10, FontStyle.Bold))
                            {
                                // Stín (černý, posunutý o pixel)
                                e.Graphics.DrawString(v.Id, font, Brushes.Black, dx + 1, dy - 14);
                                // Hlavní text (bílý)
                                e.Graphics.DrawString(v.Id, font, Brushes.White, dx, dy - 15);
                            }
                        }
                    }
                }
            }
        }

        private float Lerp(float s, float e, float a) => s + (e - s) * a;

        private string FindImagePath(string f)
        {
            if (string.IsNullOrEmpty(f)) return "";
            string p = Path.Combine(imagesPath, f);
            return File.Exists(p) ? p : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../assets/images", f);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            Hide();
        }

        private void SaveScoreToHistory()
        {
            string filePath = "history.json";
            List<ScoreRecord> history = new List<ScoreRecord>();

            try
            {
                
                if (File.Exists(filePath))
                {
                    string existingJson = File.ReadAllText(filePath);
                    history = JsonSerializer.Deserialize<List<ScoreRecord>>(existingJson) ?? new List<ScoreRecord>();
                }

               
                history.Add(new ScoreRecord
                {
                    Date = DateTime.Now,
                    ScenarioTitle = currentScenario.Title,
                    FinalScore = score
                });

                
                string newJson = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, newJson);
            }
            catch (Exception ex) { MessageBox.Show("Nepodařilo se uložit historii: " + ex.Message); }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (!File.Exists("history.json"))
            {
                MessageBox.Show("Historie je zatím prázdná.");
                return;
            }

            string json = File.ReadAllText("history.json");
            var history = JsonSerializer.Deserialize<List<ScoreRecord>>(json);

            string report = "Historie pokusů:\n\n";
            foreach (var record in history.OrderByDescending(r => r.Date).Take(10)) 
            {
                report += $"{record.Date:dd.MM. HH:mm} - {record.ScenarioTitle}: {record.FinalScore} bodů\n";
            }

            MessageBox.Show(report, "Sledování úspěšnosti");
        }

        private void PracticeForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class ScoreRecord
    {
        public DateTime Date { get; set; }
        public string ScenarioTitle { get; set; }
        public int FinalScore { get; set; }
    }
}
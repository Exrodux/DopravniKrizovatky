using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace DopravniKrizovatky
{
    public partial class LearningForm : Form
    {
        private Scenario currentScenario;
        private Random random = new Random();
        private string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../assets/images");

        private int currentStep = 0;

        
        private Timer animationTimer;
        private Vehicle animatingVehicle = null;
        private float animationProgress = 0f;
        private float animationSpeed = 0.03f;

        public LearningForm()
        {
            InitializeComponent();

           
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;

           
            this.FormClosed += LearningForm_FormClosed;

            animationTimer = new Timer();
            animationTimer.Interval = 20;
            animationTimer.Tick += AnimationTimer_Tick;
        }

       
        private void LearningForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            new MainForm().Show();
        }

        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
            LoadRandomScenario();
        }

        private void LoadRandomScenario()
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

               
                currentStep = 0;
                animationTimer.Stop();
                animatingVehicle = null;
                if (currentScenario.Vehicles != null)
                {
                    foreach (var v in currentScenario.Vehicles)
                    {
                        v.IsFinished = false;
                        v.CurrentX = v.X; v.CurrentY = v.Y; v.CurrentRotation = v.Rotation;
                    }
                }

                lblTitle.Text = currentScenario.Title;
                UpdateDescription();
                pbMap.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show("Chyba: " + ex.Message); }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentScenario == null || animationTimer.Enabled) return;

            var vehicleToMove = currentScenario.Vehicles.FirstOrDefault(v => v.CorrectOrder == currentStep + 1);

            if (vehicleToMove != null && !vehicleToMove.IsFinished)
            {
                animatingVehicle = vehicleToMove;
                animatingVehicle.CurrentX = animatingVehicle.X;
                animatingVehicle.CurrentY = animatingVehicle.Y;
                animatingVehicle.CurrentRotation = animatingVehicle.Rotation;
                animationProgress = 0f;
                animationTimer.Start();
            }
            else if (currentStep < currentScenario.Vehicles.Count)
            {
                currentStep++;
                UpdateDescription();
                pbMap.Invalidate();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (animatingVehicle == null) { animationTimer.Stop(); return; }
            animationProgress += animationSpeed;

            if (animationProgress >= 1.0f)
            {
                animationProgress = 1.0f;
                animatingVehicle.IsFinished = true;
                animationTimer.Stop();
                animatingVehicle = null;

                if (currentStep < currentScenario.Vehicles.Count)
                {
                    currentStep++;
                    UpdateDescription();
                }
                pbMap.Invalidate();
                return;
            }

            if (animatingVehicle.ControlX.HasValue && animatingVehicle.ControlY.HasValue)
            {
                float t = animationProgress;
                float u = 1 - t;
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
                    if (File.Exists(p)) using (Image img = Image.FromFile(p)) e.Graphics.DrawImage(img, sign.X, sign.Y, 30, 30);
                }
            }

            if (currentScenario.Vehicles != null)
            {
                foreach (var v in currentScenario.Vehicles)
                {
                    string p = FindImagePath(v.ImageName);
                    if (!File.Exists(p)) continue;

                    using (Image img = Image.FromFile(p))
                    {
                        var state = e.Graphics.Save();
                        bool useCurrent = (v == animatingVehicle) || v.IsFinished;
                        float dx = useCurrent ? v.CurrentX : v.X;
                        float dy = useCurrent ? v.CurrentY : v.Y;
                        float rot = useCurrent ? v.CurrentRotation : v.Rotation;

                        e.Graphics.TranslateTransform(dx + 30, dy + 20);
                        e.Graphics.RotateTransform(rot);
                        e.Graphics.DrawImage(img, -30, -20, 60, 40);

                        if (!v.IsFinished && !string.IsNullOrEmpty(v.TurnSignal) && v.TurnSignal != "None")
                        {
                            if (v.TurnSignal == "Left") e.Graphics.FillEllipse(Brushes.Orange, -30, 10, 8, 8);
                            if (v.TurnSignal == "Right") e.Graphics.FillEllipse(Brushes.Orange, -30, -18, 8, 8);
                        }

                        if (v.CorrectOrder == currentStep + 1 && !v.IsFinished)
                        {
                            using (Pen pen = new Pen(Color.Gold, 3)) e.Graphics.DrawRectangle(pen, -32, -22, 64, 44);
                        }

                        e.Graphics.Restore(state);
                        if (!v.IsFinished) e.Graphics.DrawString(v.Id, SystemFonts.DefaultFont, Brushes.Black, dx, dy - 15);
                    }
                }
            }
        }

        private void UpdateDescription()
        {
            if (currentStep == 0) lblDescription.Text = $"{currentScenario.Description}\n\nKlikni na 'Další'.";
            else
            {
                var v = currentScenario.Vehicles.FirstOrDefault(x => x.CorrectOrder == currentStep);
                if (v != null) lblDescription.Text = $"Jede {v.Id}.\n{(v.Reason ?? currentScenario.Explanation)}";
                else lblDescription.Text = "Konec situace.";
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentScenario == null || animationTimer.Enabled) return;

            if (currentStep > 0)
            {
                
                currentStep--;

                var vehicleToReset = currentScenario.Vehicles.FirstOrDefault(v => v.CorrectOrder == currentStep + 1);

                if (vehicleToReset != null)
                {
                    vehicleToReset.IsFinished = false;
                    vehicleToReset.CurrentX = vehicleToReset.X;
                    vehicleToReset.CurrentY = vehicleToReset.Y;
                    vehicleToReset.CurrentRotation = vehicleToReset.Rotation;
                }

                UpdateDescription();
                pbMap.Invalidate();
            }
        }
    }
}
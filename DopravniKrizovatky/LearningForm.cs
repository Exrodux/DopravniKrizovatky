using System;
using System.Drawing; 
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Linq; 

namespace DopravniKrizovatky
{
    public partial class LearningForm : Form
    {
        private Scenario currentScenario;
        private Random random = new Random();

      
        private int currentStep = 0; 
        
        private string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../assets/images");

        public LearningForm()
        {
            InitializeComponent();

            this.FormClosed += LearningForm_FormClosed; 
        }

        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
          
            string folder = "../../scenarios"; 

            if (!Directory.Exists(folder))
            {
               
                folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../scenarios");
            }

            if (!Directory.Exists(folder))
            {
                MessageBox.Show($"Složka se scénáři nebyla nalezena!\nHledáno v: {Path.GetFullPath(folder)}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(folder, "*.json");

            if (files.Length == 0)
            {
                MessageBox.Show("Ve složce nejsou žádné scénáře!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string randomFile = files[random.Next(files.Length)];

            try
            {
                string json = File.ReadAllText(randomFile);
                currentScenario = JsonSerializer.Deserialize<Scenario>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

           
                currentStep = 0;
                lblTitle.Text = currentScenario.Title;
                UpdateDescription(); 

      
                pbMap.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání scénáře:\n" + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            if (currentScenario == null) return;

            string bgPath = FindImagePath(currentScenario.BackgroundImage);

            if (File.Exists(bgPath))
            {
                using (Image bg = Image.FromFile(bgPath))
                {
                    e.Graphics.DrawImage(bg, 0, 0, pbMap.Width, pbMap.Height);
                }
            }
            else
            {
                e.Graphics.Clear(Color.LightGray);
                e.Graphics.DrawString("Chybí pozadí!", SystemFonts.DefaultFont, Brushes.Red, 10, 10);
            }

        
            if (currentScenario.Vehicles != null)
            {
                foreach (var v in currentScenario.Vehicles)
                {

                    string carPath = FindImagePath(v.ImageName);

                    using (Image carImg = Image.FromFile(carPath))
                    {
                       
                        var originalState = e.Graphics.Save();

                        
                       
                        float centerX = v.X + 30; 
                        float centerY = v.Y + 20; 

                        e.Graphics.TranslateTransform(centerX, centerY);

                    
                        e.Graphics.RotateTransform(v.Rotation);

                      
                       
                        e.Graphics.DrawImage(carImg, -30, -20, 60, 40);

                        
                        if (v.CorrectOrder == currentStep)
                        {
                            Pen p = new Pen(Color.Gold, 4);
                            e.Graphics.DrawRectangle(p, -32, -22, 64, 44);
                        }

                  
                        e.Graphics.Restore(originalState);

                     
                        e.Graphics.DrawString(v.Id, SystemFonts.DefaultFont, Brushes.Black, v.X, v.Y - 15);
                    }
                }
            }
        }

    
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentScenario == null) return;

        
            if (currentStep < currentScenario.Vehicles.Count)
            {
                currentStep++;
                UpdateDescription();
                pbMap.Invalidate(); 
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentScenario == null) return;

            if (currentStep > 0)
            {
                currentStep--;
                UpdateDescription();
                pbMap.Invalidate();
            }
        }

    
        private void UpdateDescription()
        {
            if (currentStep == 0)
            {
                lblDescription.Text = currentScenario.Description + "\n\nKlikni na 'Další' pro spuštění výuky.";
            }
            else
            {
               
                var activeVehicle = currentScenario.Vehicles.FirstOrDefault(v => v.CorrectOrder == currentStep);

                if (activeVehicle != null)
                {
                    lblDescription.Text = $"KROK {currentStep}: Jede {activeVehicle.Id}.\n\n" +
                                          $"Vysvětlení: {currentScenario.Explanation}";
                }
                else
                {
                    lblDescription.Text = "Konec situace. Všechna vozidla odjela.";
                }
            }
        }

        
        private string FindImagePath(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return "";

        
            string path = Path.Combine(imagesPath, fileName);
            if (File.Exists(path)) return path;

           
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../assets/images", fileName);
            return path;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainMenu = new MainForm();
            mainMenu.Show();

            
            this.Hide();
        }
        private void LearningForm_FormClosed(object sender, FormClosedEventArgs e)

        {

            Application.Exit();

        }
    }
}
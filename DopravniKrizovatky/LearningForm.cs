using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace DopravniKrizovatky
{
    public partial class LearningForm : Form
    {
        private Scenario currentScenario;
        private Random random = new Random();

        public LearningForm()
        {
            InitializeComponent();
        }

        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
            string folder = "../../scenarios";

            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Složka 'scenarios' nebyla nalezena!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                lblTitle.Text = currentScenario.Title;
                lblDescription.Text =
                    currentScenario.Description + "\n\n" + currentScenario.Explanation;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání scénáře:\n" + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainMenu = new MainForm();
            mainMenu.Show();
            this.Close();
        }
    }
}

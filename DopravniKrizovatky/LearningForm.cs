using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace DopravniKrizovatky
{
    public partial class LearningForm : Form
    {
        private Scenario currentScenario;

        public LearningForm()
        {
            InitializeComponent();
        }

        private void btnLoadScenario_Click(object sender, EventArgs e)
        {
            string path = "../../scenarios/scen01.json"; 
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                currentScenario = JsonSerializer.Deserialize<Scenario>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                lblTitle.Text = currentScenario.Title;
                lblDescription.Text = currentScenario.Description + "\n\n" + currentScenario.Explanation;
            }
            else
            {
                MessageBox.Show("Soubor scénáře nenalezen!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

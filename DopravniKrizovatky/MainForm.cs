using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace DopravniKrizovatky
{
    public partial class MainForm : Form
    {

        


        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadScenario(string path)
        {
            //string json = File.ReadAllText(path);
            //currentScenario = JsonSerializer.Deserialize<Scenario>(json);

            //lblTitle.Text = currentScenario.Title;
            //lblDescription.Text = currentScenario.Description;
            //listVehicles.Items.Clear();

            //foreach (var v in currentScenario.Vehicles)
            //{
            //    listVehicles.Items.Add($"{v.Id} – {v.Approach} ({v.Direction})");
            //}
        }

        private void btnLearning_Click(object sender, EventArgs e)
        {
            LearningForm learningForm = new LearningForm();
            learningForm.Show();
            this.Hide();
        }

        private void btnPractice_Click(object sender, EventArgs e)
        {
            PracticeForm practiceForm = new PracticeForm();
            practiceForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

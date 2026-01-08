namespace DopravniKrizovatky
{
    partial class PracticeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lstVehicles = new System.Windows.Forms.ListBox();
            this.btnLoadScenario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(497, 326);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Zpět";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(60, 62);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(60, 228);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 2;
            // 
            // lstVehicles
            // 
            this.lstVehicles.FormattingEnabled = true;
            this.lstVehicles.Location = new System.Drawing.Point(344, 95);
            this.lstVehicles.Name = "lstVehicles";
            this.lstVehicles.Size = new System.Drawing.Size(185, 134);
            this.lstVehicles.TabIndex = 3;
            // 
            // btnLoadScenario
            // 
            this.btnLoadScenario.Location = new System.Drawing.Point(12, 326);
            this.btnLoadScenario.Name = "btnLoadScenario";
            this.btnLoadScenario.Size = new System.Drawing.Size(100, 23);
            this.btnLoadScenario.TabIndex = 4;
            this.btnLoadScenario.Text = "Načíst scénář";
            this.btnLoadScenario.UseVisualStyleBackColor = true;
            this.btnLoadScenario.Click += new System.EventHandler(this.btnLoadScenario_Click);
            // 
            // PracticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnLoadScenario);
            this.Controls.Add(this.lstVehicles);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PracticeForm";
            this.Text = "Procvičování";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ListBox lstVehicles;
        private System.Windows.Forms.Button btnLoadScenario;
    }
}
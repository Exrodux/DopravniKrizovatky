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
            this.btnLoadScenario = new System.Windows.Forms.Button();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(450, 310);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "ZPĚT";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(34, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 21);
            this.lblTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(34, 250);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 19);
            this.lblDescription.TabIndex = 2;
            // 
            // btnLoadScenario
            // 
            this.btnLoadScenario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLoadScenario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadScenario.FlatAppearance.BorderSize = 0;
            this.btnLoadScenario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnLoadScenario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnLoadScenario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadScenario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLoadScenario.ForeColor = System.Drawing.Color.White;
            this.btnLoadScenario.Location = new System.Drawing.Point(38, 310);
            this.btnLoadScenario.Name = "btnLoadScenario";
            this.btnLoadScenario.Size = new System.Drawing.Size(120, 35);
            this.btnLoadScenario.TabIndex = 4;
            this.btnLoadScenario.Text = "NAČÍST SCÉNÁŘ";
            this.btnLoadScenario.UseVisualStyleBackColor = false;
            this.btnLoadScenario.Click += new System.EventHandler(this.btnLoadScenario_Click);
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pbMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMap.Location = new System.Drawing.Point(38, 35);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(493, 177);
            this.pbMap.TabIndex = 5;
            this.pbMap.TabStop = false;
            this.pbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMap_Paint);
            this.pbMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMap_MouseClick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblScore.ForeColor = System.Drawing.Color.Gold;
            this.lblScore.Location = new System.Drawing.Point(34, 218);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(107, 25);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "BODY: 100";
            // 
            // PracticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.btnLoadScenario);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PracticeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procvičování křižovatek";
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnLoadScenario;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Label lblScore;
    }
}
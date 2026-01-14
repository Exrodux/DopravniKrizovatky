namespace DopravniKrizovatky
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLearning = new System.Windows.Forms.Button();
            this.btnPractice = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(584, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DOPRAVNÍ KŘIŽOVATKY";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLearning
            // 
            this.btnLearning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLearning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLearning.FlatAppearance.BorderSize = 0;
            this.btnLearning.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.btnLearning.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnLearning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLearning.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLearning.ForeColor = System.Drawing.Color.White;
            this.btnLearning.Location = new System.Drawing.Point(192, 130);
            this.btnLearning.Name = "btnLearning";
            this.btnLearning.Size = new System.Drawing.Size(200, 50);
            this.btnLearning.TabIndex = 1;
            this.btnLearning.Text = "VÝUKA";
            this.btnLearning.UseVisualStyleBackColor = false;
            this.btnLearning.Click += new System.EventHandler(this.btnLearning_Click);
            // 
            // btnPractice
            // 
            this.btnPractice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPractice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPractice.FlatAppearance.BorderSize = 0;
            this.btnPractice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(50)))));
            this.btnPractice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(200)))), ((int)(((byte)(80)))));
            this.btnPractice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPractice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPractice.ForeColor = System.Drawing.Color.White;
            this.btnPractice.Location = new System.Drawing.Point(192, 200);
            this.btnPractice.Name = "btnPractice";
            this.btnPractice.Size = new System.Drawing.Size(200, 50);
            this.btnPractice.TabIndex = 2;
            this.btnPractice.Text = "PROCVIČOVÁNÍ";
            this.btnPractice.UseVisualStyleBackColor = false;
            this.btnPractice.Click += new System.EventHandler(this.btnPractice_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(192, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 50);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "KONEC";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPractice);
            this.Controls.Add(this.btnLearning);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dopravní Křižovatky";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLearning;
        private System.Windows.Forms.Button btnPractice;
        private System.Windows.Forms.Button btnExit;
    }
}
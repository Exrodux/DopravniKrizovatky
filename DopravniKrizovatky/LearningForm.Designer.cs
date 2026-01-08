namespace DopravniKrizovatky
{
    partial class LearningForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnLoadScenario = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(211, 61);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(169, 295);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 13);
            this.lblDescription.TabIndex = 1;
            // 
            // btnLoadScenario
            // 
            this.btnLoadScenario.Location = new System.Drawing.Point(29, 326);
            this.btnLoadScenario.Name = "btnLoadScenario";
            this.btnLoadScenario.Size = new System.Drawing.Size(93, 23);
            this.btnLoadScenario.TabIndex = 2;
            this.btnLoadScenario.Text = "Načíst scénář";
            this.btnLoadScenario.UseVisualStyleBackColor = true;
            this.btnLoadScenario.Click += new System.EventHandler(this.btnLoadScenario_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(497, 326);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Zpět";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(216, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Výuka";
            // 
            // pbMap
            // 
            this.pbMap.Location = new System.Drawing.Point(32, 61);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(489, 155);
            this.pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMap.TabIndex = 5;
            this.pbMap.TabStop = false;
            this.pbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMap_Paint);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(32, 242);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Text = "< Předchozí";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(446, 242);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Další >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // LearningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLoadScenario);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LearningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Výuka";
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnLoadScenario;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}
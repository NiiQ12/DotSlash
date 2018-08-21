namespace SHS
{
    partial class frmManageOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageOperations));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewSchedule = new System.Windows.Forms.Button();
            this.btnMaintenances = new System.Windows.Forms.Button();
            this.btnInstallations = new System.Windows.Forms.Button();
            this.btnCorrections = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.MaximumSize = new System.Drawing.Size(590, 490);
            this.panel1.MinimumSize = new System.Drawing.Size(590, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 490);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "OPERATIONS";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(454, 30);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnBack.Size = new System.Drawing.Size(30, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "⇐";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(495, 30);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnViewSchedule);
            this.panel2.Controls.Add(this.btnMaintenances);
            this.panel2.Controls.Add(this.btnInstallations);
            this.panel2.Controls.Add(this.btnCorrections);
            this.panel2.Location = new System.Drawing.Point(75, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 350);
            this.panel2.TabIndex = 1;
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnViewSchedule.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSchedule.ForeColor = System.Drawing.Color.White;
            this.btnViewSchedule.Location = new System.Drawing.Point(100, 250);
            this.btnViewSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(250, 40);
            this.btnViewSchedule.TabIndex = 13;
            this.btnViewSchedule.Text = "VIEW SCHEDULE";
            this.btnViewSchedule.UseVisualStyleBackColor = false;
            this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);
            // 
            // btnMaintenances
            // 
            this.btnMaintenances.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnMaintenances.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintenances.ForeColor = System.Drawing.Color.White;
            this.btnMaintenances.Location = new System.Drawing.Point(100, 190);
            this.btnMaintenances.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaintenances.Name = "btnMaintenances";
            this.btnMaintenances.Size = new System.Drawing.Size(250, 40);
            this.btnMaintenances.TabIndex = 12;
            this.btnMaintenances.Text = "MAINTENANCES";
            this.btnMaintenances.UseVisualStyleBackColor = false;
            this.btnMaintenances.Click += new System.EventHandler(this.btnMaintenances_Click);
            // 
            // btnInstallations
            // 
            this.btnInstallations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnInstallations.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallations.ForeColor = System.Drawing.Color.White;
            this.btnInstallations.Location = new System.Drawing.Point(100, 70);
            this.btnInstallations.Margin = new System.Windows.Forms.Padding(0);
            this.btnInstallations.Name = "btnInstallations";
            this.btnInstallations.Size = new System.Drawing.Size(250, 40);
            this.btnInstallations.TabIndex = 11;
            this.btnInstallations.Text = "INSTALLATIONS";
            this.btnInstallations.UseVisualStyleBackColor = false;
            this.btnInstallations.Click += new System.EventHandler(this.btnInstallations_Click);
            // 
            // btnCorrections
            // 
            this.btnCorrections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnCorrections.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrections.ForeColor = System.Drawing.Color.White;
            this.btnCorrections.Location = new System.Drawing.Point(100, 130);
            this.btnCorrections.Margin = new System.Windows.Forms.Padding(0);
            this.btnCorrections.Name = "btnCorrections";
            this.btnCorrections.Size = new System.Drawing.Size(250, 40);
            this.btnCorrections.TabIndex = 10;
            this.btnCorrections.Text = "CORRECTIONS";
            this.btnCorrections.UseVisualStyleBackColor = false;
            this.btnCorrections.Click += new System.EventHandler(this.btnCorrections_Click);
            // 
            // frmManageOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageOperations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageOperations";
            this.Load += new System.EventHandler(this.frmManageOperations_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMaintenances;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnInstallations;
        private System.Windows.Forms.Button btnCorrections;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewSchedule;
    }
}
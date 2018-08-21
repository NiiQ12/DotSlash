namespace SHS
{
    partial class frmManageInstallations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageInstallations));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFinalise = new System.Windows.Forms.Button();
            this.dgvInstallations = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxTypesOfInstallations = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallations)).BeginInit();
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
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "INSTALLATIONS";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Black;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(454, 30);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
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
            this.panel2.Controls.Add(this.btnFinalise);
            this.panel2.Controls.Add(this.dgvInstallations);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cbxTypesOfInstallations);
            this.panel2.Location = new System.Drawing.Point(25, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 390);
            this.panel2.TabIndex = 0;
            // 
            // btnFinalise
            // 
            this.btnFinalise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnFinalise.Enabled = false;
            this.btnFinalise.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalise.ForeColor = System.Drawing.Color.White;
            this.btnFinalise.Location = new System.Drawing.Point(174, 351);
            this.btnFinalise.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinalise.Name = "btnFinalise";
            this.btnFinalise.Size = new System.Drawing.Size(200, 30);
            this.btnFinalise.TabIndex = 42;
            this.btnFinalise.Text = "FINALISE";
            this.btnFinalise.UseVisualStyleBackColor = false;
            this.btnFinalise.Click += new System.EventHandler(this.btnFinaliseInstallation_Click);
            // 
            // dgvInstallations
            // 
            this.dgvInstallations.AllowUserToAddRows = false;
            this.dgvInstallations.AllowUserToDeleteRows = false;
            this.dgvInstallations.AllowUserToResizeColumns = false;
            this.dgvInstallations.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgvInstallations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInstallations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstallations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstallations.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvInstallations.Location = new System.Drawing.Point(7, 39);
            this.dgvInstallations.MultiSelect = false;
            this.dgvInstallations.Name = "dgvInstallations";
            this.dgvInstallations.ReadOnly = true;
            this.dgvInstallations.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgvInstallations.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInstallations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstallations.Size = new System.Drawing.Size(526, 303);
            this.dgvInstallations.TabIndex = 39;
            this.dgvInstallations.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstallations_CellEnter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.CausesValidation = false;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(14, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(265, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "SELECT WHICH INSTALLATIONS TO VIEW :";
            // 
            // cbxTypesOfInstallations
            // 
            this.cbxTypesOfInstallations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypesOfInstallations.FormattingEnabled = true;
            this.cbxTypesOfInstallations.Location = new System.Drawing.Point(285, 11);
            this.cbxTypesOfInstallations.Name = "cbxTypesOfInstallations";
            this.cbxTypesOfInstallations.Size = new System.Drawing.Size(248, 21);
            this.cbxTypesOfInstallations.TabIndex = 19;
            this.cbxTypesOfInstallations.SelectedIndexChanged += new System.EventHandler(this.cbxTypesOfInstallations_SelectedIndexChanged);
            // 
            // frmManageInstallations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageInstallations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageInstallations";
            this.Load += new System.EventHandler(this.frmManageInstallations_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstallations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxTypesOfInstallations;
        private System.Windows.Forms.Button btnFinalise;
        private System.Windows.Forms.DataGridView dgvInstallations;
    }
}
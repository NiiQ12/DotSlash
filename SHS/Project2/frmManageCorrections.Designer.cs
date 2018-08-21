namespace SHS
{
    partial class frmManageCorrections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageCorrections));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnServiceTicket = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFinalise = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvCorrections = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxTypesOfCorrections = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrections)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnServiceTicket);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.MaximumSize = new System.Drawing.Size(590, 490);
            this.panel1.MinimumSize = new System.Drawing.Size(590, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 490);
            this.panel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "CORRECTIONS";
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
            // btnServiceTicket
            // 
            this.btnServiceTicket.BackColor = System.Drawing.Color.Black;
            this.btnServiceTicket.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceTicket.ForeColor = System.Drawing.Color.White;
            this.btnServiceTicket.Location = new System.Drawing.Point(276, 30);
            this.btnServiceTicket.Margin = new System.Windows.Forms.Padding(0);
            this.btnServiceTicket.Name = "btnServiceTicket";
            this.btnServiceTicket.Size = new System.Drawing.Size(168, 30);
            this.btnServiceTicket.TabIndex = 36;
            this.btnServiceTicket.Text = "SERVICE TICKET";
            this.btnServiceTicket.UseVisualStyleBackColor = false;
            this.btnServiceTicket.Click += new System.EventHandler(this.btnServiceTicket_Click);
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
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.dgvCorrections);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cbxTypesOfCorrections);
            this.panel2.Location = new System.Drawing.Point(25, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 390);
            this.panel2.TabIndex = 0;
            // 
            // btnFinalise
            // 
            this.btnFinalise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnFinalise.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalise.ForeColor = System.Drawing.Color.White;
            this.btnFinalise.Location = new System.Drawing.Point(68, 350);
            this.btnFinalise.Margin = new System.Windows.Forms.Padding(0);
            this.btnFinalise.Name = "btnFinalise";
            this.btnFinalise.Size = new System.Drawing.Size(168, 30);
            this.btnFinalise.TabIndex = 39;
            this.btnFinalise.Text = "FINALISE";
            this.btnFinalise.UseVisualStyleBackColor = false;
            this.btnFinalise.Click += new System.EventHandler(this.btnFinalise_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(307, 350);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(168, 30);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvCorrections
            // 
            this.dgvCorrections.AllowUserToAddRows = false;
            this.dgvCorrections.AllowUserToDeleteRows = false;
            this.dgvCorrections.AllowUserToResizeColumns = false;
            this.dgvCorrections.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgvCorrections.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCorrections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCorrections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorrections.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvCorrections.Location = new System.Drawing.Point(8, 38);
            this.dgvCorrections.MultiSelect = false;
            this.dgvCorrections.Name = "dgvCorrections";
            this.dgvCorrections.ReadOnly = true;
            this.dgvCorrections.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dgvCorrections.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCorrections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorrections.Size = new System.Drawing.Size(526, 303);
            this.dgvCorrections.TabIndex = 35;
            this.dgvCorrections.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorrections_CellEnter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.CausesValidation = false;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(14, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(260, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "SELECT WHICH CORRECTIONS TO VIEW :";
            // 
            // cbxTypesOfCorrections
            // 
            this.cbxTypesOfCorrections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypesOfCorrections.FormattingEnabled = true;
            this.cbxTypesOfCorrections.Location = new System.Drawing.Point(280, 11);
            this.cbxTypesOfCorrections.Name = "cbxTypesOfCorrections";
            this.cbxTypesOfCorrections.Size = new System.Drawing.Size(253, 21);
            this.cbxTypesOfCorrections.TabIndex = 19;
            this.cbxTypesOfCorrections.SelectedIndexChanged += new System.EventHandler(this.cbxTypesOfCorrections_SelectedIndexChanged);
            // 
            // frmManageCorrections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageCorrections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageCorrections";
            this.Load += new System.EventHandler(this.frmManageCorrections_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxTypesOfCorrections;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnServiceTicket;
        private System.Windows.Forms.DataGridView dgvCorrections;
        private System.Windows.Forms.Button btnFinalise;
    }
}
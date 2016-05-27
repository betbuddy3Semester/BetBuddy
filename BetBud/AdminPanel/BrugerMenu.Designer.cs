namespace AdminPanel
{
    partial class BrugerMenu
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BrugerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Navn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brugernavn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSoeg = new System.Windows.Forms.TextBox();
            this.btnSoeg = new System.Windows.Forms.Button();
            this.btnOpretBruger = new System.Windows.Forms.Button();
            this.btnOpdaterBruger = new System.Windows.Forms.Button();
            this.btnSletBruger = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrugerId,
            this.Navn,
            this.Email,
            this.Brugernavn,
            this.Password,
            this.Alias,
            this.Point});
            this.dataGridView1.Location = new System.Drawing.Point(186, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(842, 275);
            this.dataGridView1.TabIndex = 0;
            // 
            // BrugerId
            // 
            this.BrugerId.HeaderText = "BrugerID";
            this.BrugerId.Name = "BrugerId";
            this.BrugerId.Width = 50;
            // 
            // Navn
            // 
            this.Navn.HeaderText = "Navn";
            this.Navn.Name = "Navn";
            this.Navn.Width = 150;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 200;
            // 
            // Brugernavn
            // 
            this.Brugernavn.HeaderText = "Brugernavn";
            this.Brugernavn.Name = "Brugernavn";
            this.Brugernavn.Width = 150;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // Alias
            // 
            this.Alias.HeaderText = "Alias";
            this.Alias.Name = "Alias";
            // 
            // Point
            // 
            this.Point.HeaderText = "Point";
            this.Point.Name = "Point";
            this.Point.Width = 75;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSletBruger);
            this.panel1.Controls.Add(this.btnOpdaterBruger);
            this.panel1.Controls.Add(this.btnOpretBruger);
            this.panel1.Controls.Add(this.btnSoeg);
            this.panel1.ForeColor = System.Drawing.Color.DarkBlue;
            this.panel1.Location = new System.Drawing.Point(22, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 262);
            this.panel1.TabIndex = 1;
            // 
            // txtSoeg
            // 
            this.txtSoeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoeg.Location = new System.Drawing.Point(186, 29);
            this.txtSoeg.Name = "txtSoeg";
            this.txtSoeg.Size = new System.Drawing.Size(325, 29);
            this.txtSoeg.TabIndex = 2;
            this.txtSoeg.TextChanged += new System.EventHandler(this.txtSoeg_TextChanged);
            // 
            // btnSoeg
            // 
            this.btnSoeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoeg.Location = new System.Drawing.Point(14, 3);
            this.btnSoeg.Name = "btnSoeg";
            this.btnSoeg.Size = new System.Drawing.Size(123, 38);
            this.btnSoeg.TabIndex = 0;
            this.btnSoeg.Text = "Søg";
            this.btnSoeg.UseVisualStyleBackColor = true;
            this.btnSoeg.Click += new System.EventHandler(this.btnSoeg_Click);
            // 
            // btnOpretBruger
            // 
            this.btnOpretBruger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpretBruger.Location = new System.Drawing.Point(14, 69);
            this.btnOpretBruger.Name = "btnOpretBruger";
            this.btnOpretBruger.Size = new System.Drawing.Size(123, 38);
            this.btnOpretBruger.TabIndex = 1;
            this.btnOpretBruger.Text = "Opret";
            this.btnOpretBruger.UseVisualStyleBackColor = true;
            // 
            // btnOpdaterBruger
            // 
            this.btnOpdaterBruger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpdaterBruger.Location = new System.Drawing.Point(14, 134);
            this.btnOpdaterBruger.Name = "btnOpdaterBruger";
            this.btnOpdaterBruger.Size = new System.Drawing.Size(123, 37);
            this.btnOpdaterBruger.TabIndex = 2;
            this.btnOpdaterBruger.Text = "Opdater";
            this.btnOpdaterBruger.UseVisualStyleBackColor = true;
            // 
            // btnSletBruger
            // 
            this.btnSletBruger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSletBruger.Location = new System.Drawing.Point(14, 200);
            this.btnSletBruger.Name = "btnSletBruger";
            this.btnSletBruger.Size = new System.Drawing.Size(123, 37);
            this.btnSletBruger.TabIndex = 3;
            this.btnSletBruger.Text = "Slet";
            this.btnSletBruger.UseVisualStyleBackColor = true;
            // 
            // BrugerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 350);
            this.Controls.Add(this.txtSoeg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BrugerMenu";
            this.Text = "BrugerMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrugerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Navn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brugernavn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSletBruger;
        private System.Windows.Forms.Button btnOpdaterBruger;
        private System.Windows.Forms.Button btnOpretBruger;
        private System.Windows.Forms.Button btnSoeg;
        private System.Windows.Forms.TextBox txtSoeg;
    }
}
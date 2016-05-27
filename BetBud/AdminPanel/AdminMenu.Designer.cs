namespace AdminPanel
{
    partial class AdminMenu
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
            this.Sæson = new System.Windows.Forms.Button();
            this.Bruger = new System.Windows.Forms.Button();
            this.KampeMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sæson
            // 
            this.Sæson.Location = new System.Drawing.Point(157, 80);
            this.Sæson.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Sæson.Name = "Sæson";
            this.Sæson.Size = new System.Drawing.Size(174, 33);
            this.Sæson.TabIndex = 0;
            this.Sæson.Text = "Sæson";
            this.Sæson.UseVisualStyleBackColor = true;
            this.Sæson.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bruger
            // 
            this.Bruger.Location = new System.Drawing.Point(368, 80);
            this.Bruger.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Bruger.Name = "Bruger";
            this.Bruger.Size = new System.Drawing.Size(169, 32);
            this.Bruger.TabIndex = 1;
            this.Bruger.Text = "Bruger";
            this.Bruger.UseVisualStyleBackColor = true;
            this.Bruger.Click += new System.EventHandler(this.Bruger_Click);
            // 
            // KampeMenu
            // 
            this.KampeMenu.Location = new System.Drawing.Point(573, 81);
            this.KampeMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KampeMenu.Name = "KampeMenu";
            this.KampeMenu.Size = new System.Drawing.Size(169, 31);
            this.KampeMenu.TabIndex = 2;
            this.KampeMenu.Text = "Kampe";
            this.KampeMenu.UseVisualStyleBackColor = true;
            // 
            // BrugerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 431);
            this.Controls.Add(this.KampeMenu);
            this.Controls.Add(this.Bruger);
            this.Controls.Add(this.Sæson);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BrugerMenu";
            this.Text = "Admin Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Sæson;
        private System.Windows.Forms.Button Bruger;
        private System.Windows.Forms.Button KampeMenu;
    }
}


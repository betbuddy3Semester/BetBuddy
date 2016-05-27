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
            this.Sæson = new System.Windows.Forms.Button();
            this.Bruger = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sæson
            // 
            this.Sæson.Location = new System.Drawing.Point(69, 98);
            this.Sæson.Name = "Sæson";
            this.Sæson.Size = new System.Drawing.Size(181, 49);
            this.Sæson.TabIndex = 0;
            this.Sæson.Text = "Sæson menu";
            this.Sæson.UseVisualStyleBackColor = true;
            this.Sæson.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bruger
            // 
            this.Bruger.Location = new System.Drawing.Point(69, 153);
            this.Bruger.Name = "Bruger";
            this.Bruger.Size = new System.Drawing.Size(181, 44);
            this.Bruger.TabIndex = 1;
            this.Bruger.Text = "Bruger menu";
            this.Bruger.UseVisualStyleBackColor = true;
            this.Bruger.Click += new System.EventHandler(this.Bruger_Click);
            // 
            // BrugerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 530);
            this.Controls.Add(this.Bruger);
            this.Controls.Add(this.Sæson);
            this.Name = "BrugerMenu";
            this.Text = "Admin Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Sæson;
        private System.Windows.Forms.Button Bruger;
    }
}


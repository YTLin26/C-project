namespace ISB114_Rawdata
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbComport = new System.Windows.Forms.ComboBox();
            this.btSeiralOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comport:";
            // 
            // cbComport
            // 
            this.cbComport.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbComport.FormattingEnabled = true;
            this.cbComport.Location = new System.Drawing.Point(84, 37);
            this.cbComport.Name = "cbComport";
            this.cbComport.Size = new System.Drawing.Size(121, 24);
            this.cbComport.TabIndex = 1;
            // 
            // btSeiralOpen
            // 
            this.btSeiralOpen.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btSeiralOpen.Location = new System.Drawing.Point(211, 37);
            this.btSeiralOpen.Name = "btSeiralOpen";
            this.btSeiralOpen.Size = new System.Drawing.Size(75, 26);
            this.btSeiralOpen.TabIndex = 2;
            this.btSeiralOpen.Text = "Open";
            this.btSeiralOpen.UseVisualStyleBackColor = true;
            this.btSeiralOpen.Click += new System.EventHandler(this.btSeiralOpen_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 100);
            this.Controls.Add(this.btSeiralOpen);
            this.Controls.Add(this.cbComport);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbComport;
        private System.Windows.Forms.Button btSeiralOpen;
    }
}
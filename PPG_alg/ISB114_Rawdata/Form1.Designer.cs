namespace ISB114_Rawdata
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OpenComport_bt = new System.Windows.Forms.Button();
            this.SerialStatus_lb_fixed = new System.Windows.Forms.Label();
            this.LinkStatus_lb = new System.Windows.Forms.Label();
            this.CloseComport_bt = new System.Windows.Forms.Button();
            this.ReadCmd_bt = new System.Windows.Forms.Button();
            this.ReadCmdStatus_lb_fixed = new System.Windows.Forms.Label();
            this.ReadCmdStatus_lb = new System.Windows.Forms.Label();
            this.TrfRawdata_bt = new System.Windows.Forms.Button();
            this.Trf_status_fixed = new System.Windows.Forms.Label();
            this.Trf_status_lb = new System.Windows.Forms.Label();
            this.TransferData_Bar = new System.Windows.Forms.ProgressBar();
            this.TotalSector_lb_fixed = new System.Windows.Forms.Label();
            this.TotalSector_lb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SavePath_lb_fixed = new System.Windows.Forms.Label();
            this.SavePath_lb = new System.Windows.Forms.Label();
            this.SavePath_bt = new System.Windows.Forms.Button();
            this.Trfdata_FinishRate_lb = new System.Windows.Forms.Label();
            this.Trfdata_FinishRate_lbfixed = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.rawdataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetTime_bt = new System.Windows.Forms.Button();
            this.SetTime_lb_fixed = new System.Windows.Forms.Label();
            this.SetTime_lb = new System.Windows.Forms.Label();
            this.BaudRate_lb_fixed = new System.Windows.Forms.Label();
            this.BaudRate_tb = new System.Windows.Forms.TextBox();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenComport_bt
            // 
            this.OpenComport_bt.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OpenComport_bt.Location = new System.Drawing.Point(12, 149);
            this.OpenComport_bt.Name = "OpenComport_bt";
            this.OpenComport_bt.Size = new System.Drawing.Size(117, 31);
            this.OpenComport_bt.TabIndex = 1;
            this.OpenComport_bt.Text = "串口連線";
            this.OpenComport_bt.UseVisualStyleBackColor = true;
            this.OpenComport_bt.Click += new System.EventHandler(this.OpenComport_bt_Click);
            // 
            // SerialStatus_lb_fixed
            // 
            this.SerialStatus_lb_fixed.AutoSize = true;
            this.SerialStatus_lb_fixed.Font = new System.Drawing.Font("新細明體", 12F);
            this.SerialStatus_lb_fixed.Location = new System.Drawing.Point(145, 156);
            this.SerialStatus_lb_fixed.Name = "SerialStatus_lb_fixed";
            this.SerialStatus_lb_fixed.Size = new System.Drawing.Size(49, 16);
            this.SerialStatus_lb_fixed.TabIndex = 2;
            this.SerialStatus_lb_fixed.Text = "Status:";
            // 
            // LinkStatus_lb
            // 
            this.LinkStatus_lb.AutoSize = true;
            this.LinkStatus_lb.Font = new System.Drawing.Font("新細明體", 14F);
            this.LinkStatus_lb.ForeColor = System.Drawing.Color.Red;
            this.LinkStatus_lb.Location = new System.Drawing.Point(208, 156);
            this.LinkStatus_lb.Name = "LinkStatus_lb";
            this.LinkStatus_lb.Size = new System.Drawing.Size(113, 19);
            this.LinkStatus_lb.TabIndex = 3;
            this.LinkStatus_lb.Text = "Disconnection";
            // 
            // CloseComport_bt
            // 
            this.CloseComport_bt.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CloseComport_bt.Location = new System.Drawing.Point(9, 346);
            this.CloseComport_bt.Name = "CloseComport_bt";
            this.CloseComport_bt.Size = new System.Drawing.Size(117, 31);
            this.CloseComport_bt.TabIndex = 6;
            this.CloseComport_bt.Text = "關閉串口";
            this.CloseComport_bt.UseVisualStyleBackColor = true;
            this.CloseComport_bt.Click += new System.EventHandler(this.CloseComport_bt_Click);
            // 
            // ReadCmd_bt
            // 
            this.ReadCmd_bt.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReadCmd_bt.Location = new System.Drawing.Point(12, 200);
            this.ReadCmd_bt.Name = "ReadCmd_bt";
            this.ReadCmd_bt.Size = new System.Drawing.Size(117, 31);
            this.ReadCmd_bt.TabIndex = 18;
            this.ReadCmd_bt.Text = "讀取資料";
            this.ReadCmd_bt.UseVisualStyleBackColor = true;
            this.ReadCmd_bt.Click += new System.EventHandler(this.ReadCmd_bt_Click);
            // 
            // ReadCmdStatus_lb_fixed
            // 
            this.ReadCmdStatus_lb_fixed.AutoSize = true;
            this.ReadCmdStatus_lb_fixed.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReadCmdStatus_lb_fixed.Location = new System.Drawing.Point(146, 207);
            this.ReadCmdStatus_lb_fixed.Name = "ReadCmdStatus_lb_fixed";
            this.ReadCmdStatus_lb_fixed.Size = new System.Drawing.Size(49, 16);
            this.ReadCmdStatus_lb_fixed.TabIndex = 19;
            this.ReadCmdStatus_lb_fixed.Text = "Status:";
            // 
            // ReadCmdStatus_lb
            // 
            this.ReadCmdStatus_lb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ReadCmdStatus_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReadCmdStatus_lb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReadCmdStatus_lb.ForeColor = System.Drawing.Color.Red;
            this.ReadCmdStatus_lb.Location = new System.Drawing.Point(212, 198);
            this.ReadCmdStatus_lb.Name = "ReadCmdStatus_lb";
            this.ReadCmdStatus_lb.Size = new System.Drawing.Size(98, 25);
            this.ReadCmdStatus_lb.TabIndex = 20;
            this.ReadCmdStatus_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrfRawdata_bt
            // 
            this.TrfRawdata_bt.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TrfRawdata_bt.Location = new System.Drawing.Point(12, 254);
            this.TrfRawdata_bt.Name = "TrfRawdata_bt";
            this.TrfRawdata_bt.Size = new System.Drawing.Size(117, 31);
            this.TrfRawdata_bt.TabIndex = 30;
            this.TrfRawdata_bt.Text = "傳送資料";
            this.TrfRawdata_bt.UseVisualStyleBackColor = true;
            this.TrfRawdata_bt.Click += new System.EventHandler(this.trf_rawdata_bt_Click);
            // 
            // Trf_status_fixed
            // 
            this.Trf_status_fixed.AutoSize = true;
            this.Trf_status_fixed.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Trf_status_fixed.Location = new System.Drawing.Point(146, 261);
            this.Trf_status_fixed.Name = "Trf_status_fixed";
            this.Trf_status_fixed.Size = new System.Drawing.Size(49, 16);
            this.Trf_status_fixed.TabIndex = 31;
            this.Trf_status_fixed.Text = "Status:";
            // 
            // Trf_status_lb
            // 
            this.Trf_status_lb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Trf_status_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Trf_status_lb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Trf_status_lb.ForeColor = System.Drawing.Color.Black;
            this.Trf_status_lb.Location = new System.Drawing.Point(212, 252);
            this.Trf_status_lb.Name = "Trf_status_lb";
            this.Trf_status_lb.Size = new System.Drawing.Size(98, 25);
            this.Trf_status_lb.TabIndex = 32;
            this.Trf_status_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TransferData_Bar
            // 
            this.TransferData_Bar.Location = new System.Drawing.Point(148, 326);
            this.TransferData_Bar.Name = "TransferData_Bar";
            this.TransferData_Bar.Size = new System.Drawing.Size(162, 21);
            this.TransferData_Bar.TabIndex = 36;
            // 
            // TotalSector_lb_fixed
            // 
            this.TotalSector_lb_fixed.AutoSize = true;
            this.TotalSector_lb_fixed.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TotalSector_lb_fixed.Location = new System.Drawing.Point(146, 298);
            this.TotalSector_lb_fixed.Name = "TotalSector_lb_fixed";
            this.TotalSector_lb_fixed.Size = new System.Drawing.Size(85, 16);
            this.TotalSector_lb_fixed.TabIndex = 37;
            this.TotalSector_lb_fixed.Text = "Total sector:";
            // 
            // TotalSector_lb
            // 
            this.TotalSector_lb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalSector_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalSector_lb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TotalSector_lb.ForeColor = System.Drawing.Color.Blue;
            this.TotalSector_lb.Location = new System.Drawing.Point(236, 289);
            this.TotalSector_lb.Name = "TotalSector_lb";
            this.TotalSector_lb.Size = new System.Drawing.Size(74, 25);
            this.TotalSector_lb.TabIndex = 38;
            this.TotalSector_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SavePath_lb_fixed
            // 
            this.SavePath_lb_fixed.AutoSize = true;
            this.SavePath_lb_fixed.Font = new System.Drawing.Font("新細明體", 12F);
            this.SavePath_lb_fixed.Location = new System.Drawing.Point(4, 48);
            this.SavePath_lb_fixed.Name = "SavePath_lb_fixed";
            this.SavePath_lb_fixed.Size = new System.Drawing.Size(73, 16);
            this.SavePath_lb_fixed.TabIndex = 40;
            this.SavePath_lb_fixed.Text = "Save Path:";
            // 
            // SavePath_lb
            // 
            this.SavePath_lb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SavePath_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SavePath_lb.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SavePath_lb.ForeColor = System.Drawing.Color.Black;
            this.SavePath_lb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SavePath_lb.Location = new System.Drawing.Point(83, 44);
            this.SavePath_lb.Name = "SavePath_lb";
            this.SavePath_lb.Size = new System.Drawing.Size(299, 25);
            this.SavePath_lb.TabIndex = 41;
            this.SavePath_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SavePath_bt
            // 
            this.SavePath_bt.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SavePath_bt.Location = new System.Drawing.Point(388, 41);
            this.SavePath_bt.Name = "SavePath_bt";
            this.SavePath_bt.Size = new System.Drawing.Size(85, 31);
            this.SavePath_bt.TabIndex = 42;
            this.SavePath_bt.Text = "選擇路徑";
            this.SavePath_bt.UseVisualStyleBackColor = true;
            this.SavePath_bt.Click += new System.EventHandler(this.SavePath_bt_Click);
            // 
            // Trfdata_FinishRate_lb
            // 
            this.Trfdata_FinishRate_lb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Trfdata_FinishRate_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Trfdata_FinishRate_lb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Trfdata_FinishRate_lb.ForeColor = System.Drawing.Color.Black;
            this.Trfdata_FinishRate_lb.Location = new System.Drawing.Point(316, 326);
            this.Trfdata_FinishRate_lb.Name = "Trfdata_FinishRate_lb";
            this.Trfdata_FinishRate_lb.Size = new System.Drawing.Size(60, 21);
            this.Trfdata_FinishRate_lb.TabIndex = 43;
            this.Trfdata_FinishRate_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Trfdata_FinishRate_lbfixed
            // 
            this.Trfdata_FinishRate_lbfixed.AutoSize = true;
            this.Trfdata_FinishRate_lbfixed.Font = new System.Drawing.Font("新細明體", 11F);
            this.Trfdata_FinishRate_lbfixed.Location = new System.Drawing.Point(382, 328);
            this.Trfdata_FinishRate_lbfixed.Name = "Trfdata_FinishRate_lbfixed";
            this.Trfdata_FinishRate_lbfixed.Size = new System.Drawing.Size(19, 15);
            this.Trfdata_FinishRate_lbfixed.TabIndex = 44;
            this.Trfdata_FinishRate_lbfixed.Text = "%";
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawdataToolStripMenuItem,
            this.decordToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(504, 24);
            this.Menu.TabIndex = 45;
            this.Menu.Text = "menuStrip1";
            // 
            // rawdataToolStripMenuItem
            // 
            this.rawdataToolStripMenuItem.Name = "rawdataToolStripMenuItem";
            this.rawdataToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.rawdataToolStripMenuItem.Text = "Rawdata";
            this.rawdataToolStripMenuItem.Click += new System.EventHandler(this.rawdataToolStripMenuItem_Click);
            // 
            // decordToolStripMenuItem
            // 
            this.decordToolStripMenuItem.Name = "decordToolStripMenuItem";
            this.decordToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.decordToolStripMenuItem.Text = "Decord";
            this.decordToolStripMenuItem.Click += new System.EventHandler(this.decordToolStripMenuItem_Click);
            // 
            // SetTime_bt
            // 
            this.SetTime_bt.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetTime_bt.Location = new System.Drawing.Point(12, 95);
            this.SetTime_bt.Name = "SetTime_bt";
            this.SetTime_bt.Size = new System.Drawing.Size(117, 31);
            this.SetTime_bt.TabIndex = 46;
            this.SetTime_bt.Text = "對時";
            this.SetTime_bt.UseVisualStyleBackColor = true;
            this.SetTime_bt.Click += new System.EventHandler(this.SetTime_bt_Click);
            // 
            // SetTime_lb_fixed
            // 
            this.SetTime_lb_fixed.AutoSize = true;
            this.SetTime_lb_fixed.Font = new System.Drawing.Font("新細明體", 12F);
            this.SetTime_lb_fixed.Location = new System.Drawing.Point(146, 102);
            this.SetTime_lb_fixed.Name = "SetTime_lb_fixed";
            this.SetTime_lb_fixed.Size = new System.Drawing.Size(49, 16);
            this.SetTime_lb_fixed.TabIndex = 47;
            this.SetTime_lb_fixed.Text = "Status:";
            // 
            // SetTime_lb
            // 
            this.SetTime_lb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SetTime_lb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SetTime_lb.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SetTime_lb.ForeColor = System.Drawing.Color.Red;
            this.SetTime_lb.Location = new System.Drawing.Point(212, 98);
            this.SetTime_lb.Name = "SetTime_lb";
            this.SetTime_lb.Size = new System.Drawing.Size(98, 25);
            this.SetTime_lb.TabIndex = 48;
            this.SetTime_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaudRate_lb_fixed
            // 
            this.BaudRate_lb_fixed.AutoSize = true;
            this.BaudRate_lb_fixed.Font = new System.Drawing.Font("新細明體", 12F);
            this.BaudRate_lb_fixed.Location = new System.Drawing.Point(333, 158);
            this.BaudRate_lb_fixed.Name = "BaudRate_lb_fixed";
            this.BaudRate_lb_fixed.Size = new System.Drawing.Size(68, 16);
            this.BaudRate_lb_fixed.TabIndex = 49;
            this.BaudRate_lb_fixed.Text = "Baudrate:";
            // 
            // BaudRate_tb
            // 
            this.BaudRate_tb.Location = new System.Drawing.Point(404, 156);
            this.BaudRate_tb.Name = "BaudRate_tb";
            this.BaudRate_tb.Size = new System.Drawing.Size(88, 22);
            this.BaudRate_tb.TabIndex = 51;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 409);
            this.Controls.Add(this.BaudRate_tb);
            this.Controls.Add(this.BaudRate_lb_fixed);
            this.Controls.Add(this.SetTime_lb);
            this.Controls.Add(this.SetTime_lb_fixed);
            this.Controls.Add(this.SetTime_bt);
            this.Controls.Add(this.Trfdata_FinishRate_lbfixed);
            this.Controls.Add(this.Trfdata_FinishRate_lb);
            this.Controls.Add(this.SavePath_bt);
            this.Controls.Add(this.SavePath_lb);
            this.Controls.Add(this.SavePath_lb_fixed);
            this.Controls.Add(this.TotalSector_lb);
            this.Controls.Add(this.TotalSector_lb_fixed);
            this.Controls.Add(this.TransferData_Bar);
            this.Controls.Add(this.Trf_status_lb);
            this.Controls.Add(this.Trf_status_fixed);
            this.Controls.Add(this.TrfRawdata_bt);
            this.Controls.Add(this.ReadCmdStatus_lb);
            this.Controls.Add(this.ReadCmdStatus_lb_fixed);
            this.Controls.Add(this.ReadCmd_bt);
            this.Controls.Add(this.CloseComport_bt);
            this.Controls.Add(this.LinkStatus_lb);
            this.Controls.Add(this.SerialStatus_lb_fixed);
            this.Controls.Add(this.OpenComport_bt);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Form1";
            this.Text = "ISB114_Rawdata";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenComport_bt;
        private System.Windows.Forms.Label SerialStatus_lb_fixed;
        private System.Windows.Forms.Label LinkStatus_lb;
        private System.Windows.Forms.Button CloseComport_bt;
        private System.Windows.Forms.Button ReadCmd_bt;
        private System.Windows.Forms.Label ReadCmdStatus_lb_fixed;
        private System.Windows.Forms.Label ReadCmdStatus_lb;
        private System.Windows.Forms.Button TrfRawdata_bt;
        private System.Windows.Forms.Label Trf_status_fixed;
        private System.Windows.Forms.Label Trf_status_lb;
        private System.Windows.Forms.ProgressBar TransferData_Bar;
        private System.Windows.Forms.Label TotalSector_lb_fixed;
        private System.Windows.Forms.Label TotalSector_lb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SavePath_lb_fixed;
        private System.Windows.Forms.Label SavePath_lb;
        private System.Windows.Forms.Button SavePath_bt;
        private System.Windows.Forms.Label Trfdata_FinishRate_lb;
        private System.Windows.Forms.Label Trfdata_FinishRate_lbfixed;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem rawdataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decordToolStripMenuItem;
        private System.Windows.Forms.Button SetTime_bt;
        private System.Windows.Forms.Label SetTime_lb_fixed;
        private System.Windows.Forms.Label SetTime_lb;
        private System.Windows.Forms.Label BaudRate_lb_fixed;
        private System.Windows.Forms.TextBox BaudRate_tb;
    }
}


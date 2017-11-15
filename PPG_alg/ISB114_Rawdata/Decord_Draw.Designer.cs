namespace ISB114_Rawdata
{
    partial class Decord_Draw
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Acc_cht = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Ppg_cht = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AccCht_lb = new System.Windows.Forms.Label();
            this.PpgCht_lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Acc_cht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ppg_cht)).BeginInit();
            this.SuspendLayout();
            // 
            // Acc_cht
            // 
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.AxisX.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.Name = "ChartArea1";
            this.Acc_cht.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.Acc_cht.Legends.Add(legend1);
            this.Acc_cht.Location = new System.Drawing.Point(46, 72);
            this.Acc_cht.Name = "Acc_cht";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "X";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Y";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Z";
            this.Acc_cht.Series.Add(series1);
            this.Acc_cht.Series.Add(series2);
            this.Acc_cht.Series.Add(series3);
            this.Acc_cht.Size = new System.Drawing.Size(977, 265);
            this.Acc_cht.TabIndex = 1;
            this.Acc_cht.Text = "chart1";
            // 
            // Ppg_cht
            // 
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea2.AxisX.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea2.Name = "ChartArea1";
            this.Ppg_cht.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Ppg_cht.Legends.Add(legend2);
            this.Ppg_cht.Location = new System.Drawing.Point(46, 435);
            this.Ppg_cht.Name = "Ppg_cht";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.LabelForeColor = System.Drawing.Color.White;
            series4.Legend = "Legend1";
            series4.Name = "PPG1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.LabelForeColor = System.Drawing.Color.White;
            series5.Legend = "Legend1";
            series5.Name = "PPG2";
            this.Ppg_cht.Series.Add(series4);
            this.Ppg_cht.Series.Add(series5);
            this.Ppg_cht.Size = new System.Drawing.Size(977, 299);
            this.Ppg_cht.TabIndex = 2;
            this.Ppg_cht.Text = "chart2";
            // 
            // AccCht_lb
            // 
            this.AccCht_lb.AutoSize = true;
            this.AccCht_lb.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccCht_lb.Location = new System.Drawing.Point(422, 25);
            this.AccCht_lb.Name = "AccCht_lb";
            this.AccCht_lb.Size = new System.Drawing.Size(174, 33);
            this.AccCht_lb.TabIndex = 3;
            this.AccCht_lb.Text = "Accelerometer";
            this.AccCht_lb.Click += new System.EventHandler(this.AccCht_lb_Click);
            // 
            // PpgCht_lb
            // 
            this.PpgCht_lb.AutoSize = true;
            this.PpgCht_lb.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PpgCht_lb.Location = new System.Drawing.Point(484, 387);
            this.PpgCht_lb.Name = "PpgCht_lb";
            this.PpgCht_lb.Size = new System.Drawing.Size(60, 33);
            this.PpgCht_lb.TabIndex = 4;
            this.PpgCht_lb.Text = "PPG";
            this.PpgCht_lb.Click += new System.EventHandler(this.PpgCht_lb_Click);
            // 
            // Decord_Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 760);
            this.Controls.Add(this.PpgCht_lb);
            this.Controls.Add(this.AccCht_lb);
            this.Controls.Add(this.Ppg_cht);
            this.Controls.Add(this.Acc_cht);
            this.Name = "Decord_Draw";
            this.Text = "Decord_Draw";
            ((System.ComponentModel.ISupportInitialize)(this.Acc_cht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ppg_cht)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Acc_cht;
        private System.Windows.Forms.DataVisualization.Charting.Chart Ppg_cht;
        private System.Windows.Forms.Label AccCht_lb;
        private System.Windows.Forms.Label PpgCht_lb;

    }
}
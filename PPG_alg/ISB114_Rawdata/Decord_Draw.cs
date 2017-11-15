using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace ISB114_Rawdata
{
public partial class Decord_Draw : Form
{
    // Declare max/min
    double max_acc_x = 0.0, max_acc_y = 0.0, max_acc_z = 0.0, max_ch1_ppg = 0.0, max_ch2_ppg = 0.0;
    double min_acc_x = 0.0, min_acc_y = 0.0, min_acc_z = 0.0, min_ch1_ppg = 0.0, min_ch2_ppg = 0.0;
    bool debug_test = false;

    public Decord_Draw()
    {
        InitializeComponent();
        ulong i;           // a counter to a for loop below
        ulong loop_num = 0;    // for debug

        // for debug
        //if ((RAWDATA.PPG_ch1.Count > 0) || (RAWDATA.PPG_ch2.Count > 0))
        if(debug_test)
        {
            int num = 0;

            // Initailize both the chart

            Acc_cht.Series["X"].Points.Clear();
            Acc_cht.Series["Y"].Points.Clear();
            Acc_cht.Series["Z"].Points.Clear();

            Ppg_cht.Series["PPG1"].Points.Clear();
            Ppg_cht.Series["PPG2"].Points.Clear();

            // Config the chart
            ChartArea ACC_chart = Acc_cht.ChartAreas[0];
            ACC_chart.AxisX.Interval = 0.1;//1 / Constants.SPR;                                                  // acc sampling rate = 100 Hz

            /** for debug **/
            ACC_chart.AxisX.Maximum = 10;                               // acc sampling rate = 100 Hz
            ACC_chart.AxisX.Minimum = 0.0;
            ACC_chart.AxisY.Maximum = 5;
            ACC_chart.AxisY.Minimum = 0;
            ACC_chart.AxisX.Title = "sec";
            ACC_chart.AxisY.Title = "Val";

            loop_num = (ulong)RAWDATA.Acc_x.Count;

            // for debug
            loop_num = 20;

            for (i = 0; i < loop_num; i++)
            {
                Acc_cht.Series["X"].Points.AddXY(Convert.ToDouble(i) / 2, num);
                num = Math.Abs(num - 1);
                //Acc_cht.Series["Y"].Points.AddXY(i, 2);
                //Acc_cht.Series["Z"].Points.AddXY(i, 3);
            }

            /** End of the ACC PART **/


            /** PPG PART **/

            // Config the chart
            ChartArea PPG_chart = Ppg_cht.ChartAreas[0];
            PPG_chart.AxisX.Interval = 1 / Constants.SPR;                                                  // ppg sampling rate = 100 Hz

            /** for debug **/
            PPG_chart.AxisX.Maximum = 20;                             // ppg sampling rate = 100 Hz
            PPG_chart.AxisX.Minimum = 0.0;
            PPG_chart.AxisY.Maximum = 5;
            PPG_chart.AxisY.Minimum = 0;

            PPG_chart.AxisX.Interval = 60;//PPG_chart.AxisX.Maximum / Constants.axisX_interval_num;


            PPG_chart.AxisX.Title = "sec";
            PPG_chart.AxisY.Title = "Val";

            loop_num = (ulong)RAWDATA.PPG_ch1.Count;

            // for debug
            loop_num = 20;

            for (i = 0; i < loop_num; i++)
            {
                Ppg_cht.Series["PPG1"].Points.AddXY(i, 1);
                //Ppg_cht.Series["PPG2"].Points.AddXY(i, 2);
            }

            /** End of the PPG PART **/
        }
        else
        {
            //StreamReader sr;
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.InitialDirectory = ".\\";
            //dialog.Filter = "Text Files (*.txt)|*.txt|Comma-Delimited Files (*.csv)|*.csv|All Files (*.*)|*.*";
            //dialog.CheckFileExists = true;
            //dialog.CheckPathExists = false;
            //DialogResult result = dialog.ShowDialog();
            //if (result == DialogResult.OK) {
            //    //dialog.FileName;
            //    sr = new StreamReader(dialog.FileName);
            //    while (!sr.EndOfStream)
            //    {

            //        string[] parts = sr.ReadLine().Split(new string[] { "\r\n", "\n", " ", "\t" }, StringSplitOptions.None);
            //        RAWDATA.Acc_x.Add(Convert.ToDouble(parts[3]));
            //        RAWDATA.Acc_y.Add(Convert.ToDouble(parts[4]));
            //        RAWDATA.Acc_z.Add(Convert.ToDouble(parts[5]));

            //        RAWDATA.PPG_ch1.Add(Convert.ToInt32(parts[1]));
            //        RAWDATA.PPG_ch2.Add(Convert.ToInt32(parts[2]));
            //    }

            //    sr.Close();

            //}

            //StreamReader sr = new StreamReader(@"C:\ISB1142016112521816.txt");

            i = 0;

            
            // Initailize both the chart
            Acc_cht.Series["X"].Points.Clear();
            Acc_cht.Series["Y"].Points.Clear();
            Acc_cht.Series["Z"].Points.Clear();

            Ppg_cht.Series["PPG1"].Points.Clear();
            Ppg_cht.Series["PPG2"].Points.Clear();


            //-- ACC PART

            // Find the max
            max_acc_x = RAWDATA.Acc_x.Max();
            max_acc_y = RAWDATA.Acc_y.Max();
            max_acc_z = RAWDATA.Acc_z.Max();


            // Find the min
            min_acc_x = RAWDATA.Acc_x.Min();
            min_acc_y = RAWDATA.Acc_y.Min();
            min_acc_z = RAWDATA.Acc_z.Min();

            // Config the acc chart
            ChartArea ACC_chart = Acc_cht.ChartAreas[0];

            ACC_chart.AxisX.Maximum = RAWDATA.Acc_x.Count / Constants.SPR;                                 // acc sampling rate = 100 Hz
            ACC_chart.AxisX.Minimum = 0.0;
            ACC_chart.AxisY.Maximum = Math.Max(max_acc_x, Math.Max(max_acc_y, max_acc_z));
            ACC_chart.AxisY.Minimum = Math.Min(min_acc_x, Math.Min(min_acc_y, min_acc_z));
            ACC_chart.AxisX.Interval = Constants.axisX_interval;//Convert.ToInt32(ACC_chart.AxisX.Maximum / Constants.axisX_interval_num)/10*10;
            ACC_chart.AxisX.MinorGrid.Interval = 30;
            ACC_chart.AxisX.Title = "sec";
            ACC_chart.AxisY.Title = "Val";

            loop_num = (ulong)RAWDATA.Acc_x.Count;

            // Plot !
            for (i = 0; i < loop_num; i++)
            {
                Acc_cht.Series["X"].Points.AddXY(Convert.ToDouble(i)/Constants.SPR, RAWDATA.Acc_x[Convert.ToInt32(i)]);
                Acc_cht.Series["Y"].Points.AddXY(Convert.ToDouble(i)/Constants.SPR, RAWDATA.Acc_y[Convert.ToInt32(i)]);
                Acc_cht.Series["Z"].Points.AddXY(Convert.ToDouble(i)/Constants.SPR, RAWDATA.Acc_z[Convert.ToInt32(i)]);
            }

            //-- End of the ACC PART

            //-- PPG PART
            // Find the max
            max_ch1_ppg = RAWDATA.PPG_ch1.Max();
            max_ch2_ppg = RAWDATA.PPG_ch2.Max();


            // Find the min
            min_ch1_ppg = RAWDATA.PPG_ch1.Min();
            min_ch2_ppg = RAWDATA.PPG_ch2.Min();

            // Config the chart
            ChartArea PPG_chart = Ppg_cht.ChartAreas[0];
            //PPG_chart.AxisX.Interval = 1 / 100;//Constants.SPR;                                                // ppg sampling rate = 100 Hz
            PPG_chart.AxisX.Maximum = RAWDATA.PPG_ch1.Count / Constants.SPR;                             // ppg sampling rate = 100 Hz
            PPG_chart.AxisX.Minimum = 0.0;
            PPG_chart.AxisY.Maximum = Math.Max(max_ch1_ppg, max_ch2_ppg);
            PPG_chart.AxisY.Minimum = Math.Min(min_ch1_ppg, min_ch2_ppg);

            PPG_chart.AxisX.Interval = Constants.axisX_interval;//PPG_chart.AxisX.Maximum / Constants.axisX_interval_num;
            PPG_chart.AxisX.MinorGrid.Interval = 30;
            PPG_chart.AxisX.Title = "sec";
            PPG_chart.AxisY.Title = "Val";

            loop_num = (ulong)RAWDATA.PPG_ch1.Count;

            // Plot !

            for (i = 0; i < loop_num; i++)
            {
                Ppg_cht.Series["PPG1"].Points.AddXY(Convert.ToDouble(i)/Constants.SPR, RAWDATA.PPG_ch1[Convert.ToInt32(i)]);
                Ppg_cht.Series["PPG2"].Points.AddXY(Convert.ToDouble(i)/Constants.SPR, RAWDATA.PPG_ch2[Convert.ToInt32(i)]);
            }

            //-- End of the PPG PART

        }
    }

    private void AccCht_lb_Click(object sender, EventArgs e)
    {

    }

    private void PpgCht_lb_Click(object sender, EventArgs e)
    {

    }
}
}

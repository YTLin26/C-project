using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;              // for SerialPort class
using System.Threading;
using System.IO;
using System.Diagnostics; 

namespace ISB114_Rawdata
{
    public partial class Form1 : Form
    {
        
        //Serial Ports
        public string com_choose;
        public bool b_oc; // Open comport
        static SerialPort sp;

        // Serial Console
        static List<Byte> tempList = new List<Byte>(); // the data get from serial port
        static byte[] temp_buf = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        static int Timeout_cnt_sec = 0;
        static int SPTimeout_cnt = 0;
        static double total_sector = 0; 
        static DialogResult result;

        //
        Size rawdataformSize = new Size();

        Thread readThread = new Thread(Read);
        static ManualResetEvent allDone = new ManualResetEvent(false);

        static byte receiveByte;

        public Form1()
        {
            InitializeComponent();
            TransferData_Bar.Maximum = 100;
            TransferData_Bar.Minimum = 0;
            TransferData_Bar.Value = 0;
            TransferData_Bar.Step = 1;
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            readThread.Abort();
        }

        //Step2: Open comport
        private void OpenComport_bt_Click(object sender, EventArgs e)
        {
            if (BaudRate_tb.Text == "")
            {
                result = MessageBox.Show("填寫Baudrate", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else
            {
                //Form2: Choose comport
                Form2 form2 = new Form2();
                form2.ShowDialog();
                com_choose = form2.com;

                if (form2.b_com)
                {
                    b_oc = true;
                    OpenComport_bt.Enabled = false;
                    CloseComport_bt.Enabled = true;
                    SetTime_bt.Enabled = true;
                    ReadCmd_bt.Enabled = true;

                    string baudrate_s = BaudRate_tb.Text.ToString();
                    int baudrate = int.Parse(baudrate_s);

                    sp = new SerialPort(com_choose, baudrate, Parity.None, 8, StopBits.One);
                    //sp = new SerialPort(com_choose, 230400, Parity.None, 8, StopBits.One);

                    if (!sp.IsOpen)
                    {
                        sp.Open();
                        timer1.Start();
                        LinkStatus_lb.Text = "Connection";
                        System.Diagnostics.Debug.Print("Connection");

                        tempList.Clear();

                        readThread.Start();
                        Flag.Thread_startflag = true;
                        Flag.Serial_startflag = true;
                    }

                    //sp.ReadTimeout = 1000;
                    try
                    {
                        System.Threading.Thread.Sleep(10);
                        sp.DiscardInBuffer();
                        sp.DiscardOutBuffer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Open() error: " + ex.Message);
                    }
                }
            }
        }

        /*-------------------------- ReadComport data --------------------------*/
        public static void Read()
        {
            //CMD_rsp_parameter cmd_rsp = new CMD_rsp_parameter();
            int time_stamp = 0;
            while (Flag.Thread_startflag)
            {
                //allDone.WaitOne();
                while (Flag.Serial_startflag)
                {
                    if (sp.BytesToRead > 0)
                    {
                        receiveByte = (byte)sp.ReadByte();
                        tempList.Add(receiveByte);
                        if (time_stamp == 65535)
                            time_stamp = 0;
                        else
                            time_stamp++;

                        //System.Diagnostics.Debug.Print(receiveByte.ToString("X"));
                        ////-- File_Info_cmd rsp
                        if (tempList.Count == 20 && tempList[0] == 0x7e && tempList[1] == 0x05 && tempList[14] == 0xff && tempList[15] == 0xff && tempList[16] == 0xff && Flag.TrfFlashData == false)
                        {
                            CMD_rsp_parameter.FileInfo.read_position_H = tempList[2];
                            CMD_rsp_parameter.FileInfo.read_position_L = tempList[3];
                            CMD_rsp_parameter.FileInfo.num_H = tempList[4];
                            CMD_rsp_parameter.FileInfo.num_L = tempList[5];
                            //CMD_rsp_parameter.FileInfo.num_H = 0x02;
                            //CMD_rsp_parameter.FileInfo.num_L = 0x8A;
                            CMD_rsp_parameter.FileInfo.Total_sector_H = tempList[6];
                            CMD_rsp_parameter.FileInfo.Total_sector_L = tempList[7];
                            CMD_rsp_parameter.FileInfo.CRC_H = tempList[18];
                            CMD_rsp_parameter.FileInfo.CRC_L = tempList[19];
                            total_sector = (double)(CMD_rsp_parameter.FileInfo.num_H << 8 | CMD_rsp_parameter.FileInfo.num_L);
                            Flag.Ready_trf_flag = true;
                            Flag.Cmd_InqFileInfo_Rsp = true;
                            System.Diagnostics.Debug.Print("Ready to transfer");
                            tempList.Clear();
                        }

                        //-- Transfer Complete Cmd Respond
                        if (tempList.Count == 20 && Flag.Cmd_TrfFinish_Rsp == false && tempList[0] == 0x7e && tempList[1] == 0x07 && Flag.TrfFlashData == false)
                        {
                            if (tempList[2] == 0x01)
                            {
                                Flag.Cmd_TrfFinish_Rsp = true;
                                tempList.Clear();
                            }
                            else
                                tempList.Clear();
                        }

                        //-- To check the response of Align Time packet from the firmware 
                        if (tempList.Count == 20 && tempList[0] == 0x7e && tempList[1] == 0x00 && tempList[2] == 0x01 && Flag.TrfFlashData == false)
                        {
                            // decode
                            CMD_rsp_parameter.SetRTCTime.Year_H = tempList[3];
                            CMD_rsp_parameter.SetRTCTime.Year_L = tempList[4];
                            CMD_rsp_parameter.SetRTCTime.Mon = tempList[5];
                            CMD_rsp_parameter.SetRTCTime.Day = tempList[6];
                            CMD_rsp_parameter.SetRTCTime.Wek = tempList[7];
                            CMD_rsp_parameter.SetRTCTime.Hur = tempList[8];
                            CMD_rsp_parameter.SetRTCTime.Min = tempList[9];
                            CMD_rsp_parameter.SetRTCTime.Sec = tempList[10];

                            Flag.Cmd_SetRTCTime_Rsp = true;
                            tempList.Clear();
                        }

                        //-- Download rawdata
                        if (Flag.TrfFlashData == true && tempList.Count() == 20)
                        {
                            Flag.SPTimeout_flag = false;
                            SPTimeout_cnt = 0;
                            //Pre 4102 byte
                            if (tempList[0] == 0x7e && tempList[1] == 0x06)
                            {
                                tempList[2] = CMD_rsp_parameter.TrfData.current_sector_H;
                                tempList[3] = CMD_rsp_parameter.TrfData.current_sector_L;
                                //CMD_rsp_parameter.TrfData.current_sector_L++;
                            }
                            for (int i = 0; i < 20; i++)
                            {
                                try
                                {
                                    BinaryWriter bw = new BinaryWriter(CMD_rsp_parameter.TrfData.filename);
                                    bw.Write(tempList[i]);
                                }
                                catch (Exception ex)
                                {
                                }
                                CMD_rsp_parameter.TrfData.fourkcount += 1;
                                /*---------- full a sector ----------*/
                                if (CMD_rsp_parameter.TrfData.fourkcount == 4102)  
                                {
                                    if (CMD_rsp_parameter.TrfData.current_sector_L == 0xff)
                                    {
                                        CMD_rsp_parameter.TrfData.current_sector_L = 0;
                                        CMD_rsp_parameter.TrfData.current_sector_H++;
                                    }
                                    else
                                    {
                                        CMD_rsp_parameter.TrfData.current_sector_L++;
                                    }

                                    CMD_rsp_parameter.TrfData.fullsector += 1;
                                    CMD_rsp_parameter.TrfData.fourkcount = 0;
                                    /* --------- Transfer all sector -----------*/
                                    if (CMD_rsp_parameter.TrfData.fullsector == (((UInt16)CMD_rsp_parameter.FileInfo.num_H << 8) | (UInt16)CMD_rsp_parameter.FileInfo.num_L))
                                    {
                                        CMD_rsp_parameter.Trf_Complete.Complete_cmd_flag = true;
                                        Flag.TrfFlashData = false;
                                        CMD_rsp_parameter.TrfData.filename.Close();
                                        /*----- Send Complete Cmd -----*/
                                        UDF_CMD.Cmd_TrfComplete[2] = CMD_rsp_parameter.FileInfo.read_position_H;
                                        UDF_CMD.Cmd_TrfComplete[3] = CMD_rsp_parameter.FileInfo.read_position_L;
                                        UDF_CMD.Cmd_TrfComplete[4] = CMD_rsp_parameter.FileInfo.num_H;
                                        UDF_CMD.Cmd_TrfComplete[5] = CMD_rsp_parameter.FileInfo.num_L;
                                        sp.Write(UDF_CMD.Cmd_TrfComplete, 0, UDF_CMD.Cmd_TrfComplete.Length);
                                        break;
                                    }
                                    /*---------- Send next 4K Cmd ----------*/
                                    if (CMD_rsp_parameter.TrfData.fullsector == 1000)
                                        Thread.Sleep(500);
                                    Thread.Sleep(1);
                                    temp_buf = UDF_CMD.Cmd_TrfFlashData;
                                    int temp = CMD_rsp_parameter.FileInfo.read_position_H  << 8 | CMD_rsp_parameter.FileInfo.read_position_L;
                                    int temp2 = temp + CMD_rsp_parameter.TrfData.fullsector;
                                    temp_buf[2] = (byte)(temp2 >> 8);
                                    temp_buf[3] = (byte)temp2;
                                    sp.Write(temp_buf, 0, temp_buf.Length);
                                    Flag.SPTimeout_flag = false;
                                    break;
                                }
                            }
                            tempList.Clear();
                        }
                        /*////--Read 9 axis
                        if (tempList.Count == 45 && Flag.Readrawdata_flag == false)
                        {
                            if (tempList[6] == 0x8C && tempList[7] == 0xFD && tempList[8] == 0x00 &&
                                tempList[12] == 0x0D && tempList[13] == 0x05 && tempList[14] == 0x00 && tempList[17] == 0x12 &&
                                tempList[39] == 0x0D && tempList[40] == 0x05 && tempList[41] == 0x1A)
                            {
                                //-- Acc
                                //-- X
                                BT40.Acc[0] = (double)(short)((tempList[19] << 8 | tempList[18]));
                                //-- Y
                                BT40.Acc[1] = (double)(short)((tempList[21] << 8 | tempList[20]));
                                //-- Z
                                BT40.Acc[2] = (double)(short)((tempList[23] << 8 | tempList[22]));

                                //-- Gyro
                                //-- X
                                BT40.Gyro[0] = (double)(short)((tempList[25] << 8 | tempList[24]));
                                //-- Y
                                BT40.Gyro[1] = (double)(short)((tempList[27] << 8 | tempList[26]));
                                //-- Z
                                BT40.Gyro[2] = (double)(short)((tempList[29] << 8 | tempList[28]));

                                //-- Mag
                                //-- X
                                BT40.Mag[0] = (double)(short)((tempList[31] << 8 | tempList[30]));
                                //-- Y
                                BT40.Mag[1] = (double)(short)((tempList[33] << 8 | tempList[32]));
                                //-- Z
                                BT40.Mag[2] = (double)(short)((tempList[35] << 8 | tempList[34]));

                                //-- 32768:8G = Input:?G
                                //-- X_g
                                BT40.Acc_g[0] = (BT40.Acc[0] * 8 / 32768);
                                //-- Y_g
                                BT40.Acc_g[1] = (BT40.Acc[1] * 8 / 32768);
                                //-- Z_g
                                BT40.Acc_g[2] = (BT40.Acc[2] * 8 / 32768);


                                //-- X_deg
                                BT40.Gyro_deg[0] = (BT40.Gyro[0] * 500 / 32768);
                                //-- Y_deg
                                BT40.Gyro_deg[1] = (BT40.Gyro[1] * 500 / 32768);
                                //-- Z_deg
                                BT40.Gyro_deg[2] = (BT40.Gyro[2] * 500 / 32768);

                                //-- X_gauss
                                BT40.Mag_gauss[0] = (BT40.Mag[0] / 430);
                                //-- Y_gauss
                                BT40.Mag_gauss[1] = (BT40.Mag[1] / 430);
                                //-- Z_gauss
                                BT40.Mag_gauss[2] = (BT40.Mag[2] / 285);

                                //-- Data done 
                                Flag.ReadAccDone_flag = true;

                                //-- Repeat sampling start
                                Flag.ReadAcc_startflag = true;
                                //2016.06.05

                                try
                                {
                                    string filename = "C:\\Users\\admin\\Desktop\\BT40_raw\\BT40_raw2\\Sensor.txt";
                                    StreamWriter sw = new StreamWriter(filename, false);

                                    sw.Write(time_stamp + " ");
                                    sw.Write(BT40.Acc_g[0].ToString() + " " + BT40.Acc_g[1].ToString() + " " + BT40.Acc_g[2].ToString() + " ");
                                    sw.Write(BT40.Gyro_deg[0].ToString() + " " + BT40.Gyro_deg[1].ToString() + " " + BT40.Gyro_deg[2].ToString() + " ");
                                    sw.Write(BT40.Mag_gauss[0].ToString() + " " + BT40.Mag_gauss[1].ToString() + " " + BT40.Mag_gauss[2].ToString() + " ");
                                    sw.Write("\r\n");
                                    sw.Dispose();
                                    //2016.06.05
                                }
                                catch (Exception ex)
                                {
                                }


                            }
                            else
                            {
                                //-- Repeat sampling start
                                Flag.ReadAcc_startflag = true;
                            }
                        }*/
                    }
                    //else
                    //{
                    //    if(Flag.TrfFlashData == true && !Flag.SPTimeout_flag)
                    //    {
                    //        Thread.Sleep(100);
                    //        SPTimeout_cnt++;
                    //        if (SPTimeout_cnt == 10)
                    //        {
                    //            Flag.SPTimeout_flag = true;
                    //            result = MessageBox.Show("Timeout!", "資料重新傳送", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        }
                    //        if(result == DialogResult.OK)
                    //        {
                    //            /*---------- Send next 4K Cmd ----------*/
                    //            temp_buf = UDF_CMD.Cmd_TrfFlashData;
                    //            int temp = CMD_rsp_parameter.FileInfo.read_position_H << 8 | CMD_rsp_parameter.FileInfo.read_position_L;
                    //            int temp2 = temp + CMD_rsp_parameter.TrfData.fullsector;
                    //            temp_buf[2] = (byte)(temp2 >> 8);
                    //            temp_buf[3] = (byte)temp2;
                    //            sp.Write(temp_buf, 0, temp_buf.Length);
                    //            Flag.SPTimeout_flag = false;
                    //            SPTimeout_cnt = 0;
                    //        }
                    //    }
                    //}
                }
            }
        }

        //Step3: Read transfer data info
        private void ReadCmd_bt_Click(object sender, EventArgs e)
        {
            tempList.Clear();
            ReadCmd_bt.Enabled = false;
            //Ask the data info
            sp.Write(UDF_CMD.Cmd_InqFileInfo, 0, UDF_CMD.Cmd_InqFileInfo.Length);
            System.Threading.Thread.Sleep(10);
            //Count timeout
            while (!Flag.Cmd_InqFileInfo_Rsp)
            {
                Thread.Sleep(1000);
                Timeout_cnt_sec++;
                if(Timeout_cnt_sec == 5)
                {
                    Flag.CmdTimeout_flag = true;
                    break;
                }
            }
            if (!Flag.CmdTimeout_flag) 
            {
                TotalSector_lb.Text = (CMD_rsp_parameter.FileInfo.num_H << 8 | CMD_rsp_parameter.FileInfo.num_L).ToString();
                tempList.Clear();
                ReadCmdStatus_lb.Text = "Press Trf_bt";
                TrfRawdata_bt.Enabled = true;
            }
            else //Timeout
            {
                tempList.Clear();
                ReadCmdStatus_lb.Text = "Timeout!";
                ReadCmd_bt.Enabled = true;
            }
            Timeout_cnt_sec = 0;
            Flag.CmdTimeout_flag = false;
        }

        /*---------------- Handle Flag state --------------------*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Flag.TrfFlashData)
            {
                
                double temp1 = (double)CMD_rsp_parameter.TrfData.fullsector;// +(double)CMD_rsp_parameter.TrfData.fourkcount;
                //UInt16 temp = (UInt16)(CMD_rsp_parameter.TrfData.current_sector_H << 8 | CMD_rsp_parameter.TrfData.current_sector_L);
                
                double temp3 = (temp1 / total_sector) * 100;
                TransferData_Bar.Value = (int)Math.Floor(temp3);

                Trfdata_FinishRate_lb.Text = temp3.ToString("#0.00");
                //Trfdata_FinishRate_lb.Text = temp1.ToString("#0.0");
            }

            if (CMD_rsp_parameter.Trf_Complete.Complete_cmd_flag)
            {
                int t = 100;
                TransferData_Bar.Value = 100;
                Trfdata_FinishRate_lb.Text = t.ToString();
            }
            if (Flag.Cmd_TrfFinish_Rsp)
            {
                Trf_status_lb.Text = "Finished!";
                Flag.TrfFlashData = false;
            }
        }

        //Step4: Transfer data command
        private void trf_rawdata_bt_Click(object sender, EventArgs e)
        {
            tempList.Clear();
            byte temp1 = CMD_rsp_parameter.FileInfo.read_position_H;
            byte temp2 = CMD_rsp_parameter.FileInfo.read_position_L;
            byte temp3 = CMD_rsp_parameter.FileInfo.CRC_H;
            byte temp4 = CMD_rsp_parameter.FileInfo.CRC_L;
            ReadCmd_bt.Enabled = false;
            TrfRawdata_bt.Enabled = false;

            UDF_CMD.Cmd_TrfFlashData[2] = temp1;
            UDF_CMD.Cmd_TrfFlashData[3] = temp2;
            UDF_CMD.Cmd_TrfFlashData[18] = temp3;
            UDF_CMD.Cmd_TrfFlashData[19] = temp4;

            if (tempList.Count() > 0)
                tempList.Clear();

            sp.Write(UDF_CMD.Cmd_TrfFlashData, 0, UDF_CMD.Cmd_TrfFlashData.Length);
            Trf_status_lb.Text = "Transfering";
            Flag.TrfFlashData = true;
        }
        
        //Step5: Close Comport
        private void CloseComport_bt_Click(object sender, EventArgs e)
        {
            b_oc = false;
            OpenComport_bt.Enabled = true;
            CloseComport_bt.Enabled = false;

            System.Threading.Thread.Sleep(50);
            sp.Dispose();
            sp.Close();
            timer1.Stop();
            readThread.Abort();
            LinkStatus_lb.Text = "Disconnection";
            ReadCmdStatus_lb.Text = "";
            Trf_status_lb.Text = "";
            TotalSector_lb.Text = "";
            SetTime_lb.Text = "";
            TransferData_Bar.Value = 0;
            ReadCmd_bt.Enabled = false;
            TrfRawdata_bt.Enabled = false;
            Trfdata_FinishRate_lb.Text = "";
            decordToolStripMenuItem.Enabled = true;
            SetTime_bt.Enabled = false;
            Flag.Serial_startflag = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ShowData_bt.Enabled = false;
            OpenComport_bt.Enabled = false;
            ReadCmd_bt.Enabled = false;
            TrfRawdata_bt.Enabled = false;
            CloseComport_bt.Enabled = false;
            rawdataToolStripMenuItem.Enabled = false;    // it should be set false (rawdataToolStripMenuItem.Enabled = false;), but now in order to debug
            decordToolStripMenuItem.Enabled = false;
            SetTime_bt.Enabled = false;

        }

        // Step1: Select saving path
        private void SavePath_bt_Click(object sender, EventArgs e)
        {
            System.DateTime currentTime = new System.DateTime();
            FolderBrowserDialog path = new FolderBrowserDialog();

            path.ShowDialog();
            SavePath_lb.Text = path.SelectedPath;

            currentTime = System.DateTime.Now;
            string time = currentTime.Year.ToString() + currentTime.Month.ToString() + currentTime.Day.ToString() + currentTime.Hour.ToString() + currentTime.Minute.ToString() + currentTime.Second.ToString();
            string path_temp = path.SelectedPath + "\\ISB114_" + time;
            RAWDATA.SavePath = path.SelectedPath;
            RAWDATA.SaveTime = time;
            CMD_rsp_parameter.TrfData.filename = File.Open(path_temp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            OpenComport_bt.Enabled = true;
        }

        private void pPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void Decord_Draw()
        {
            string path = RAWDATA.SavePath + "\\ISB114_" + RAWDATA.SaveTime;
            //FileStream file = CMD_rsp_parameter.TrfData.filename;
            FileStream file = new FileStream(path, FileMode.Open);
            //FileStream file = new FileStream("ISB114_20161118222635", FileMode.Open);
            BinaryReader bw = new BinaryReader(file);
            int count1 = 0;
            int FourKCount = 0;
            byte[] tempbuf = new byte[4102];
            double timmer = 0;

            while (true)
            {
                byte data = bw.ReadByte();
                tempbuf[count1] = data;
                count1++;

                if(count1 == 4102)
                {
                    for (int i = 0; i < 8; i++)//一段內容 512byte Header 7e 06 xx xx time(6byte), 真正內容總共為502 byte (12byte PPG1(3byte LOW-HIGH)PPG2 ACC)
                    {
                        //if (tempbuf[i * 512 + 4] == 0xAA && tempbuf[i * 512 + 5] == 0xAA)
                        for(int j = 0; j < 42; j++)
                        {
                            RAWDATA.PPG_ch1.Add((int)tempbuf[i * 512 + j * 12 + 12    ] | ((int)tempbuf[i * 512 + j * 12 + 12 + 1] << 8) | ((int)tempbuf[i * 512 + j * 12 + 12 + 2] << 16));
                            RAWDATA.PPG_ch2.Add((int)tempbuf[i * 512 + j * 12 + 12 + 3] | ((int)tempbuf[i * 512 + j * 12 + 12 + 4] << 8) | ((int)tempbuf[i * 512 + j * 12 + 12 + 5] << 16));
                            
                            short temp = (short)((UInt16)tempbuf[i * 512 + j * 12 + 12 + 6 ] | (UInt16)tempbuf[i * 512 + j * 12 + 12 + 7 ] << 8);
                            RAWDATA.Acc_x.Add((double)temp *8 /32768);
                                  temp = (short)((UInt16)tempbuf[i * 512 + j * 12 + 12 + 8 ] | (UInt16)tempbuf[i * 512 + j * 12 + 12 + 9 ] << 8);
                            RAWDATA.Acc_y.Add((double)temp *8 /32768);
                                  temp = (short)((UInt16)tempbuf[i * 512 + j * 12 + 12 + 10] | (UInt16)tempbuf[i * 512 + j * 12 + 12 + 11] << 8);
                            RAWDATA.Acc_z.Add((double)temp *8 /32768);
                            RAWDATA.Time_stamp.Add((double)timmer);
                            timmer++;
                        }
                    }
                    /*----- Write to file -----*/
                    for (int i = 0; i < 336; i++)   //42*8 = 336
                    {
                        string filename = RAWDATA.SavePath + "\\ISB114" + RAWDATA.SaveTime + ".txt";
                        //string filename = "C:\\Users\\LIN\\Desktop\\Sensor.txt"; 
                        StreamWriter sw = new StreamWriter(filename, true);

                        sw.Write(RAWDATA.Time_stamp[i + FourKCount*336] + "\t");
                        sw.Write(RAWDATA.PPG_ch1[i + FourKCount * 336].ToString() + "\t" + RAWDATA.PPG_ch2[i + FourKCount * 336].ToString() + "\t" + RAWDATA.Acc_x[i + FourKCount * 336].ToString("0.000") + "\t" + RAWDATA.Acc_y[i + FourKCount * 336].ToString("0.000") + "\t" + RAWDATA.Acc_z[i + FourKCount * 336].ToString("0.000") + "\t");
                        sw.Write("\r\n");
                        sw.Dispose();
                    }
                    FourKCount++;
                    count1 = 0;
                    /*----- Is all sector has been decorded-----*/
                    if(FourKCount == (((UInt16)CMD_rsp_parameter.FileInfo.num_H << 8) | (UInt16)CMD_rsp_parameter.FileInfo.num_L))
                    {
                        Flag.DecordFinish_Rsp = true;
                        break;
                    }
                 
                }
            }
        }
        private void decordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Decord_Draw();
            while(!Flag.DecordFinish_Rsp);
            Trf_status_lb.Text = "Done!";
            rawdataToolStripMenuItem.Enabled = true;
            decordToolStripMenuItem.Enabled = false;
        }

        private void rawdataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open
            Decord_Draw RawDataForm = new Decord_Draw();
            RawDataForm.ShowDialog();
            
        }

        private void SetTime_bt_Click(object sender, EventArgs e)
        {
            tempList.Clear();

            // Get the date and time
            TimeSpan span = DateTime.Now.Subtract(new DateTime(2000, 1, 1, 0, 0, 0));
            UInt32 totalSeconds = (UInt32)span.TotalSeconds;

            // Drag total seconds into packet
            byte total_sec_4 = (byte)(totalSeconds >> 24);
            byte total_sec_3 = (byte)(totalSeconds >> 16);
            byte total_sec_2 = (byte)(totalSeconds >> 8);
            byte total_sec_1 = (byte)(totalSeconds);

            UDF_CMD.Cmd_SetRTCTime[10] = total_sec_4;
            UDF_CMD.Cmd_SetRTCTime[11] = total_sec_3;
            UDF_CMD.Cmd_SetRTCTime[12] = total_sec_2;
            UDF_CMD.Cmd_SetRTCTime[13] = total_sec_1;

            // Send the packet
            sp.Write(UDF_CMD.Cmd_SetRTCTime, 0, UDF_CMD.Cmd_SetRTCTime.Length);

            while (!Flag.Cmd_SetRTCTime_Rsp)     // wait for the response flag
            {
                Thread.Sleep(1000);
                Timeout_cnt_sec++;
                if(Timeout_cnt_sec == 5)
                {
                    Flag.CmdTimeout_flag = true;
                    break;
                }
            }

            // check if the response is correct !
            if (!Flag.CmdTimeout_flag)
            {
                SetTime_lb.Text = "對時成功";
                Flag.Cmd_SetRTCTime_Rsp = false;
            }
            else
            {
                SetTime_lb.Text = "TimeOut!";
            }
            Timeout_cnt_sec = 0;
            Flag.CmdTimeout_flag = false;
        }

        
    }
}

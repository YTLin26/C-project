using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISB114_Rawdata
{
    class Constants
    {
        public const double SPR = 100.0;
        public const double axisX_interval = 60;
    }

    class Protocal
    {
    }
    class Flag
    {
        public static Boolean Thread_startflag = false;
        public static Boolean Serial_startflag = false;
        public static Boolean Ready_trf_flag = false;
        public static Boolean Cmd_InqFileInfo_Rsp = false;
        public static Boolean TrfFlashData = false;
        public static Boolean Cmd_TrfFinish_Rsp = false;
        public static Boolean DecordFinish_Rsp = false;
        public static Boolean CmdTimeout_flag = false;
        public static Boolean Cmd_SetRTCTime_Rsp = false;
        public static Boolean SPTimeout_flag = false;
    }
    class UDF_CMD
    {
        public static byte[] Cmd_SetRTCTime   = new byte[] {0x7e, 0x10, 0xff, 0xff, 0xff, 0xff, 0x01, 0x04, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
        public static byte[] Cmd_InqFileInfo  = new byte[] {0x7e, 0x15, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x4d, 0x2a };
        public static byte[] Cmd_TrfFlashData = new byte[] {0x7e, 0x16, 0xff, 0xff, 0x00, 0x01, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
        public static byte[] Cmd_TrfComplete  = new byte[] {0x7e, 0x17, 0xff, 0xff, 0xff, 0xff, 0x01, 0x04, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x6c, 0xee };
        
    }
    class CMD_rsp_parameter
    {
        public class FileInfo
        {
            public static byte read_position_H;
            public static byte read_position_L;
            public static byte num_H;
            public static byte num_L;
            public static byte Total_sector_H;
            public static byte Total_sector_L;
            public static byte CRC_H;
            public static byte CRC_L;
        }
        public class TrfData
        {
            public static double finish_rate;
            public static bool head_flag = false;
            public static UInt16 fourkcount = 0;
            public static UInt16 fullsector = 0;
            public static List<Byte> rawdata = new List<Byte>();
            public static bool trf_complete_flag = false;

            public static byte current_sector_H = 0;
            public static byte current_sector_L = 0;

            public static FileStream filename;// = File.Open("C:\\Users\\LIN\\Desktop\\ISB114_Rawdata\\ISB114_Rawdata\\Sensor1", FileMode.OpenOrCreate, FileAccess.ReadWrite);

        }
        public class Trf_Complete
        {
            public static bool Complete_cmd_flag = false;
            public static bool Reset_cmd_flag = false;
        }
        // public string filename = "C:\\Users\\admin\\Desktop\\BT40_raw\\BT40_raw2\\Sensor.txt";

        public class SetRTCTime
        {
            public static byte Year_H = 0;
            public static byte Year_L = 0;
            public static byte Mon = 0;
            public static byte Day = 0;
            public static byte Wek = 0;
            public static byte Hur = 0;
            public static byte Min = 0;
            public static byte Sec = 0;
        }
    }
    class RAWDATA
    {
        public static List<double> Acc_x = new List<double>();
        public static List<double> Acc_y = new List<double>();
        public static List<double> Acc_z = new List<double>();
        public static List<int> PPG_ch1 = new List<int>();
        public static List<int> PPG_ch2 = new List<int>();
        public static List<double> Time_stamp = new List<double>();
        public static string SavePath = "";
        public static string SaveTime = "";
    }
}

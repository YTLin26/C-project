using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;              // for SerialPort class

namespace ISB114_Rawdata
{
    public partial class Form2 : Form
    {
        //Serial Ports
        public string com;
        public bool b_com = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] serialPorts = SerialPort.GetPortNames();
            cbComport.DataSource = serialPorts;
        }

        private void btSeiralOpen_Click(object sender, EventArgs e)
        {
            com = cbComport.SelectedItem.ToString();
            b_com = true;
            this.Close();
        }
    }
}

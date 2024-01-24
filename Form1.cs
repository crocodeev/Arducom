using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;

namespace Arducom
{
    public partial class Form1 : Form
    {

        SerialPort port;

        public Form1()
        {
            InitializeComponent();
        }


        public void SetPortList()
        {

            List<COMPortInfo> ports = COMPortInfo.GetCOMPortsInfo();

            foreach (var item in ports)
            {
                Console.WriteLine(string.Format("{0} {1}", item.Name, item.Description));
            }

            foreach (var item in ports)
            {
                comboBox1.Items.Add(item.Name + " " + item.Description);
            }
        }

        private void UpdatePortList() {
            comboBox1.Items.Clear();
            SetPortList();
        }

        private void Form_Load(Object sender, EventArgs e) {

            SetPortList();
        }

        private void UpdateComboBox(Object sender, EventArgs e)
        {

            UpdatePortList();
        }

        private void  SelectPort(Object sender, EventArgs e)
        {
           
            CreatePort();
        }

        private void CreatePort() {

            string portName = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(' ')[0];

            try
            {
                if (port != null && port.IsOpen)
                {
                    port.Close();
                }

                port = new SerialPort(portName, 9600);
                
                port.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SendKey(Object sender, EventArgs e) { 

            Button button = (Button)sender;

            Console.WriteLine(button.Text);

         
            port.Write(button.Text);
        }

    }

}

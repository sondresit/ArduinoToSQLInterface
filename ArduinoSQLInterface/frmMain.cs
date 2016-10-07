using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;


namespace ArduinoSQLInterface
{
    public partial class frmMain : Form
    {

        private string optionsTxtFile = ""; //Name of the options.txt file.
        private string[] optionsArray;
        private int port;
        private string udpIP;
        private bool anySelected;

        public frmMain()
        {
            InitializeComponent();
            optionsArray = new string[5] { "", "", "", "", "" };
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //Finds the default system folder for application data.
                var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                //States the specifed application folder for the application.
                var pathWithName = systemPath + @"\ArduinoToSQLInterface";
                //States the specified application options file.
                var optionFile = pathWithName + "options.txt";
                //In-between-storage of content for optionFile
                optionsTxtFile = optionFile;
                //Check if options file is created.
                if (File.Exists(optionFile))
                {
                    ReadFromFile();
                    //Reads settings from file.
                    //Checks whether options have file has been initialized, if so, the program gets the path of the monitored folder.
                    if (optionsArray[0] == "1")
                    {


                    }
                }
                else
                {
                    //if the options file doesnt exists, create file and create default settings.
                    Directory.CreateDirectory(pathWithName);
                    File.WriteAllText(optionFile, ("0\r\n" + "0\r\n" + "0\r\n" + "0\r\n" + "0\r\n"));
                    rbtnAny.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (anySelected == false)
            {
                string input = txtChaPort.Text;

                //Check if input is within 65535
                Int32.TryParse(input, out port);
                if (port >= 1 && port <= 65535)
                {
                    string message = "";
                    message = "Port {0} assigned.\r\n";
                    rtxtMessages.AppendText(String.Format(message, port));
                    
                }
                else
                {
                    MessageBox.Show("Value can only be between 1 and 65535");
                }
            }
        }


        private void btnActivate_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("Starting listening on port...\r\n");
            ListenToPort();
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("Deactivating port listening...\r\n");
        }

        private void rtxtMessages_TextChanged(object sender, EventArgs e)
        {
            //ScrollToCaret follows the next as it's appended to rtxtMessages
            //rtxtMessages.SelectionStart = rtxtMessages.Text.Length;
            rtxtMessages.ScrollToCaret();
        }

        private void UDPClient()
        {
            //UdpClient udpc = new UdpClient();
        }

        private void ReadFromFile()
        {
            if (File.Exists(optionsTxtFile))
            {
                optionsArray = File.ReadAllLines(optionsTxtFile);

            }
        }

        private void WriteToFile()
        {
            optionsArray[0] = "1";
            optionsArray[1] = Convert.ToString(port);
            optionsArray[2] = udpIP;
            optionsArray[3] = Convert.ToString(anySelected);

            // File.WriteAllLines(optionsFile, options);
            using (StreamWriter file = new StreamWriter(optionsTxtFile))
            {
                foreach (string line in optionsArray)
                {
                    file.WriteLine(line);
                }
            }
        }

        private void ListenToPort()
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
            byte[] data = udpClient.Receive(ref ep);

            for (int i = 0; i < data.Length; i++)
            {
                rtxtMessages.AppendText(String.Format(Convert.ToString(data[i]), "\r\n"));
            }
        }
        
        private void ListenToPort(string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            byte[] data = udpClient.Receive(ref ep);

            for (int i = 0; i < data.Length; i++)
            {
                rtxtMessages.AppendText(String.Format(Convert.ToString(data[i]), "\r\n"));
            }
        }
    

        private void rbtnAny_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = false;
            anySelected = false;
        }

        private void rbtnIP_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = true;
            anySelected = true;
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            if (rbtnIP.Enabled == true)
            {
                ValidateIPv4(txtIP.Text);
            }

        }

        private void ValidateIPv4(string ipString)
        {
            
            if (ipString.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Length == 4)
            {
                IPAddress ipAddr;
                if (IPAddress.TryParse(ipString, out ipAddr))
                {
                    rtxtMessages.AppendText("IP set to " + ipAddr.ToString() + "\r\n");
                    udpIP = ipString;
                    WriteToFile();
                }
            }
            else
            {
                MessageBox.Show("Not an IP");
            }

        }

        private void InitializeGUI()
        {

        }
    }
}

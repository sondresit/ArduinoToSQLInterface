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

        private string optionsTxtFile = "";                                     //Name of the options.txt file.
        private string[] optionsArray;                                          //The array to a configuration
        private int port;                                                       //Spesific Port
        private string udpIP;                                                   //Spesific IP
        private bool anySelected;                                               //if true, recieve data from any IP

        public frmMain()
        {
            InitializeComponent();
            optionsArray = new string[5] { "", "", "", "", "" };                //Initialze the array.
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                
                var systemPath = Environment.GetFolderPath                      //Finds the default system folder for application data.
                    (Environment.SpecialFolder.CommonApplicationData);
                var pathWithName = systemPath + @"\ArduinoToSQLInterface";      //States the specifed application folder for the application.
                var optionFile = pathWithName + "options.txt";                  //States the specified application options file.
                optionsTxtFile = optionFile;                                    //In-between-storage of content for optionFile
                                                                                
                if (File.Exists(optionFile))                                    //Check if options file is created.
                {
                    ReadFromFile();                                             //Reads settings from file.
                    if (optionsArray[0] == "1")                                 //Checks whether options have file has been initialized, if so, the program gets the path of the monitored folder.
                    {

                    }
                }
                else
                {
                    Directory.CreateDirectory(pathWithName);
                    File.WriteAllText(optionFile,                               //If the options file doesnt exists, create file and create default settings.
                        ("0\r\n" + "0\r\n" + "0\r\n" + "0\r\n" + "0\r\n"));
                    rbtnAny.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)                // THIS IS THE BUTTON FOR THE PORT SELECTION! NOT THE GOD DAMN IP!!!
        {
                string input = txtChaPort.Text;                                 //The port number from the GUI

                Int32.TryParse(input, out port);                                //Check that input is an integer
                if (port >= 1 && port <= 65535)                                 //Check that input is within 65535
                {
                    string message = "";                                        //Init message to user
                    message = "Port {0} assigned.\r\n";                         //Message to user
                    rtxtMessages.AppendText(String.Format(message, port));      //Message to user which port is configured
                }
                else
                {
                    MessageBox.Show("Value can only be between 1 and 65535");   // Message to user if any error in the input occurs
                }
            
        }


        private void btnActivate_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("Starting listening on port...\r\n");       //Dunno how long this will take, so message the user that work is in progress first.
            ListenToPort();                                                     //Start configuration of port-listening
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("Deactivating port listening...\r\n");      //Dunno how long this will take, so message the user that work is in progress first.
        }

        private void rtxtMessages_TextChanged(object sender, EventArgs e)
        {
            //ScrollToCaret follows the next as it's appended to rtxtMessages
            //rtxtMessages.SelectionStart = rtxtMessages.Text.Length;
            rtxtMessages.ScrollToCaret();                                       //Makes sure that the box continues to scroll downward as text is displayed
        }

        private void UDPClient()
        {
            //UdpClient udpc = new UdpClient();
        }

        private void ReadFromFile()
        {
            if (File.Exists(optionsTxtFile))                                    //Checks if the options file actually excists.
            {
                optionsArray = File.ReadAllLines(optionsTxtFile);               //Read all lines of the file to the array.

            }
        }

        private void WriteToFile()
        {
            optionsArray[0] = "1";                                              // If "1" the options.txt file is initialized.
            optionsArray[1] = Convert.ToString(port);                           //The port which the user has selected
            optionsArray[2] = udpIP;                                            //The IP which the user wants to listen to for traffic
            optionsArray[3] = Convert.ToString(anySelected);                    //If "true" then recieve traffic from any IP

            // File.WriteAllLines(optionsFile, options);
            using (StreamWriter file = new StreamWriter(optionsTxtFile))        //Open the options file
            {
                foreach (string line in optionsArray)                           //write every line into the file
                {
                    file.WriteLine(line); 
                }
            }
        }

        private void ListenToPort()                                             //Listen to port, any IP.
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
            byte[] data = udpClient.Receive(ref ep);

            for (int i = 0; i < data.Length; i++)
            {
                rtxtMessages.AppendText(String.Format(Convert.ToString(data[i]), "\r\n"));
            }
        }
        
        private void ListenToPort(string ip)                                    //Listen to port, spesific IP.
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
            txtIP.Enabled = false;                                              //If rbtnAny is selected, disable the textbox as it is not needed for the action
            anySelected = false;                                                //If rbtnAny i selected is false
        }

        private void rbtnIP_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = true;                                               //If rbtnIP is selected, enable the textbox.
            anySelected = true;                                                 //If rbtnIP is selected any selected is true.
        }

        private void btnIP_Click(object sender, EventArgs e)                    //THIS IS THE BUTTON FOR THE ASSIGN IP!!!
        {
            
            if (rbtnIP.Enabled == true)                                         //check that a spesified IP is to be assigned
            { 
                if (ValidateIPv4(txtIP.Text) == true)                           //Check that the IP is in a valid format
                {
                    rtxtMessages.AppendText("IP set to " + udpIP + "\r\n");     //If IP is OK, print message to user.
                    WriteToFile();                                              //Write the IP to file, so its stored for convinience.
                }
            }
        }

        private bool ValidateIPv4(string ipString)
        {
            
            if (ipString.Split(new char[] { '.' }, 
                StringSplitOptions.RemoveEmptyEntries).Length == 4)  
            {
                IPAddress ipAddr;
                if (IPAddress.TryParse(ipString, out ipAddr))                   //Checks if the input is an actuall IP address.
                {
                    udpIP = ipString;                                           //If the check is true, set the input string as a global variable for further use.
                    return true;                                                //Return true
                }
            }
            else
            {
                MessageBox.Show("Not an IP");                                   //If the check fails, return message to user that the input is not an IP.
                return false;
            }
            return false;

        }

        private void InitializeGUI()
        {

        }
    }
}

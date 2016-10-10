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
using System.Threading;


namespace ArduinoSQLInterface
{
    public partial class frmMain : Form
    {

        private int port;                                                       //Spesific Port
        private string udpIP;                                                   //Spesific IP
        private bool anySelected;
        private bool listeningActive = false;
        Thread thdUDPServer;

        public frmMain()
        {
            InitializeComponent();
            
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        private void btnAssign_Click(object sender, EventArgs e)                // THIS IS THE BUTTON FOR THE PORT SELECTION! NOT THE GOD DAMN IP!!!
        {
            string portNumber;                                                  //Initialze variable for the port
            portNumber = txtChaPort.Text;                                       //Set the value in the textbox to variable
            Validation val = new Validation();
            if (val.CheckPortNumber(portNumber) == true)                        //Call method to check if the value is within range
            {
                string message = "";                                            //Init message to user
                message = "Port {0} assigned.\r\n";                             //Message to user
                rtxtMessages.AppendText(String.Format(message, portNumber));    //Message to user which port is configured
                port = Convert.ToInt32(portNumber);                             //Set variable "port" equal to the port number so it can be saved.
                txtCurrPort.Text = Convert.ToString(port);
            }
            else
            {
                MessageBox.Show("Value not an integer between 1 and 65535");
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("Initializing port listening...\r\n");       //Dunno how long this will take, so message the user that work is in progress first.
            listeningActive = true;
            if (rbtnAny.Checked)
            {
                
                thdUDPServer = new Thread(() => ListenToPort(port));
                thdUDPServer.Start();                                             //Start configuration of port-listening
                DeactivateButtons();
                rtxtMessages.AppendText("Listening commenced...\r\n");
            }
            if (rbtnIP.Checked)
            {
                thdUDPServer = new Thread(() => ListenToPort(udpIP, port));
                thdUDPServer.Start();
                DeactivateButtons();
                rtxtMessages.AppendText("Listening commenced...\r\n");
            }
            
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            listeningActive = false;
            rtxtMessages.AppendText("Aborting port listening...\r\n");      //Dunno how long this will take, so message the user that work is in progress first.
            ActivateButtons();
            thdUDPServer.Abort();
            rtxtMessages.AppendText("Port listening aborted...\r\n");

        }

        private void rtxtMessages_TextChanged(object sender, EventArgs e)
        {
            //rtxtMessages.SelectionStart = rtxtMessages.Text.Length;
            rtxtMessages.ScrollToCaret();                                       //Makes sure that the box continues to scroll downward as text is displayed
        }

        private void UDPClient()
        {
            //UdpClient udpc = new UdpClient();
        }


        //http://stackoverflow.com/questions/19786668/c-sharp-udp-socket-client-and-server
        private void ListenToPort(int portNumber)                                             //Listen to port, any IP.
        {

            UdpClient udpClient = new UdpClient(portNumber);
            while (listeningActive == true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                AppendTextBox(RemoteIpEndPoint.Address.ToString()
                                        + ":" + returnData.ToString());
                //Does this one actually stop when thdUDP.Abort() is called?
            }
        }

        private void ListenToPort(string ip, int portNumber)                                    //Listen to port, spesific IP.
        {
            UdpClient udpClient = new UdpClient(portNumber);
            while (listeningActive == true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(ip), 0);
                byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                AppendTextBox(RemoteIpEndPoint.Address.ToString()
                                        + ":" + returnData.ToString());
                //Does this one actually stop when thdUDP.Abort() is called?
            }
        }

        private void rbtnAny_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = false;                                              //If rbtnAny is selected, disable the textbox as it is not needed for the action
            anySelected = true;                                                 //If rbtnAny i selected is false
        }

        private void rbtnIP_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = true;                                               //If rbtnIP is selected, enable the textbox.
            anySelected = false;                                                //If rbtnIP is selected any selected is true.
        }

        private void btnIP_Click(object sender, EventArgs e)                    //THIS IS THE BUTTON FOR THE ASSIGN IP!!!
        {
            if (rbtnIP.Checked == true)                                         //check that a spesified IP is to be assigned
            {
                Validation val = new Validation();
                if (val.ValidateIPv4(txtIP.Text) == true)                       //Check that the IP is in a valid format
                {
                    rtxtMessages.AppendText("IP set to " + udpIP + "\r\n");     //If IP is OK, print message to user.
                                                                                
                    udpIP = txtIP.Text;                                         //If the check is true, set the input string as a global variable for further use.
                    anySelected = false;                                        
                }
                else
                {
                    MessageBox.Show                                             //If the check fails, return message to user that the input is not an IP.
                        ("Not an IP. Format needs to be XXX.XXX.XXX.XXX where X is an integer");                               
                }
            }
            if (rbtnAny.Checked == true)
            {
                anySelected = true;
            }
        }

        private void InitializeGUI()
        {
            txtCurrPort.Text = Convert.ToString(3306);
            txtIP.Text = "192.168.12.29";
            udpIP = "192.168.12.29";
            port = 3306;
            rbtnAny.Checked = true;
        }

        private void ActivateButtons()
        {
            btnActivate.Enabled = true;
            btnAssign.Enabled = true;
            btnIP.Enabled = true;
        }
        private void DeactivateButtons()
        {
            btnActivate.Enabled = false;
            btnAssign.Enabled = false;
            btnIP.Enabled = false;
        }

        private void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            rtxtMessages.Text += value + "\r\n";
        }
    }
}

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


namespace ArduinoSQLInterface
{
    public partial class frmMain : Form
    {

        private string optionsTxtFile = ""; //Name of the options.txt file.
        private string[] optionsArray;

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
                    //Reads settings from file.
                    //Checks whether options have file has been initialized, if so, the program gets the path of the monitored folder.
                    if (optionsArray[4] == "1")
                    {


                    }
                }
                else
                {
                    //if the options file doesnt exists, create file and create default settings.
                    Directory.CreateDirectory(pathWithName);
                    File.WriteAllText(optionFile, ("0\r\n" + "0\r\n" + "0\r\n" + "0\r\n" + "0\r\n"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("\r\n Port {0} assigned");
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("\r\n Starting listening on port {0]...");
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            rtxtMessages.AppendText("\r\n Deactivating port listening...");
        }

        private void rtxtMessages_TextChanged(object sender, EventArgs e)
        {
            //ScrollToCaret follows the next as it's appended to rtxtMessages
            //rtxtMessages.SelectionStart = rtxtMessages.Text.Length;
            rtxtMessages.ScrollToCaret();
        }
    }
}

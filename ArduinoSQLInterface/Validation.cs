using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ArduinoSQLInterface
{
    class Validation
    {
        public Validation()
        {

        }
        public bool ValidateIPv4(string ipString)
        {

            if (ipString.Split(new char[] { '.' },
                StringSplitOptions.RemoveEmptyEntries).Length == 4)
            {
                IPAddress ipAddr;
                if (IPAddress.TryParse(ipString, out ipAddr))                   //Checks if the input is an actuall IP address.
                {
                    return true;                                                //Return true
                }
            }
            else
            {
                
                return false;
            }
            return false;

        }
        public bool CheckPortNumber(string input)
        {
            int port;
            Int32.TryParse(input, out port);                                    //Check that input is an integer
            if (port >= 1 && port <= 65535)                                     //Check that input is within 65535
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

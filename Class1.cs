using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPTestDemo
{
    public class WPTestClient
    {
        // Service endpoint templates
        private string wpSite = "%s://%s";

        /**
         * WPTestClient
         * Constructor for the class.
         * <param name="incomingHost">String containing the host address for the test site</param>
         * <param name="incomingProtocol">String containing the protocol to use for URIs</param>
         */
        WPTestClient(string incomingHost, string incomingProtocol)
        {
            wpSite = String.Format(wpSite, incomingHost, incomingProtocol);
        }
    }
}

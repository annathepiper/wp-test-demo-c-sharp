using NUnit.Framework;

namespace WPTestDemo
{
    public class BaseTest
    {
        // Use these for the WP Test Client
        private static string protocol;
        private static string host;

        // Use these for test default values
        public static string getPostId;
        public static string getPostTitle;

        // For generating the instance of the WP Test Client
        public WPTestClient wpTC;

        [SetUp]
        public void SetUp()
        {
            // Let's set the properties
            protocol = Properties.Settings.Default.protocol;
            host = Properties.Settings.Default.host;
            getPostId = Properties.Settings.Default.getPostId;
            getPostTitle = Properties.Settings.Default.getPostTitle;

            // We also need a WPTestClient object for all the tests to use
            wpTC = new WPTestClient(protocol, host);
        }
    }
}

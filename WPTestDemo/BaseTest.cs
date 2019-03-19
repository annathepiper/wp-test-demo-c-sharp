using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Master class for the TestNG suite. Does necessary setup work for all classes.
    /// </summary>
    public class BaseTest
    {
        // Use these for the WP Test Client
        private static string protocol;
        private static string host;

        /// <summary>
        /// Default post ID to use for tests
        /// </summary>
        public static string getPostId;

        /// <summary>
        /// Default post title to use for tests
        /// </summary>
        public static string getPostTitle;

        /// <summary>
        /// Default category ID to use for tests
        /// </summary>
        public static string getCategoryId;

        /// <summary>
        /// Default category name to use for tests
        /// </summary>
        public static string getCategoryName;

        /// <summary>
        /// For generating the instance of the WP Test Client
        /// </summary>
        public WPTestClient wpTC;

        /// <summary>
        /// Setup method for all test classes
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Let's set the properties
            protocol = Properties.Settings.Default.protocol;
            host = Properties.Settings.Default.host;
            getPostId = Properties.Settings.Default.getPostId;
            getPostTitle = Properties.Settings.Default.getPostTitle;
            getCategoryId = Properties.Settings.Default.getCategoryId;
            getCategoryName = Properties.Settings.Default.getCategoryName;

            // We also need a WPTestClient object for all the tests to use
            wpTC = new WPTestClient(protocol, host);
        }
    }
}

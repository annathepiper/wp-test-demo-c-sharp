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
        /// Default tag ID to use for tests
        /// </summary>
        public static string getTagId;

        /// <summary>
        /// Default tag name to use for tests
        /// </summary>
        public static string getTagName;

        /// <summary>
        /// Default category ID to use for tests
        /// </summary>
        public static string getCategoryId;

        /// <summary>
        /// Default category name to use for tests
        /// </summary>
        public static string getCategoryName;

        /// <summary>
        /// Default comment ID to use for tests
        /// </summary>
        public static string getCommentId;

        /// <summary>
        /// Default comment content to use for tests
        /// </summary>
        public static string getCommentContent;

        /// <summary>
        /// Default page ID to use for tests
        /// </summary>
        public static string getPageId;

        /// <summary>
        /// Default page title to use for tests
        /// </summary>
        public static string getPageTitle;

        /// <summary>
        /// Default taxonomy tag to use for tests
        /// </summary>
        public static string getTaxonomyTag;

        /// <summary>
        /// Default taxonomy name to use for tests
        /// </summary>
        public static string getTaxonomyName;

        /// <summary>
        /// Default media ID for Windows to use for tests
        /// </summary>
        public static string getMediaIdWindows;

        /// <summary>
        /// Default media title to use for tests
        /// </summary>
        public static string getMediaTitle;

        /// <summary>
        /// Default user ID to use for tests
        /// </summary>
        public static string getUserId;

        /// <summary>
        /// Default user name to use for tests
        /// </summary>
        public static string getUserName;

        /// <summary>
        /// Default post type tag to use for tests
        /// </summary>
        public static string getPostTypeTag;

        /// <summary>
        /// Default post type name to use for tests
        /// </summary>
        public static string getPostTypeName;

        /// <summary>
        /// Default post status tag to use for tests
        /// </summary>
        public static string getPostStatusTag;

        /// <summary>
        /// Default post status name to use for tests
        /// </summary>
        public static string getPostStatusName;

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
            getTagId = Properties.Settings.Default.getTagId;
            getTagName = Properties.Settings.Default.getTagName;
            getCommentId = Properties.Settings.Default.getCommentId;
            getCommentContent = Properties.Settings.Default.getCommentContent;
            getPageId = Properties.Settings.Default.getPageId;
            getPageTitle = Properties.Settings.Default.getPageTitle;
            getTaxonomyTag = Properties.Settings.Default.getTaxonomyTag;
            getTaxonomyName = Properties.Settings.Default.getTaxonomyName;
            getMediaIdWindows = Properties.Settings.Default.getMediaIdWindows;
            getMediaTitle = Properties.Settings.Default.getMediaTitle;
            getUserId = Properties.Settings.Default.getUserId;
            getUserName = Properties.Settings.Default.getUserName;
            getPostTypeTag = Properties.Settings.Default.getPostTypeTag;
            getPostTypeName = Properties.Settings.Default.getPostTypeName;
            getPostStatusTag = Properties.Settings.Default.getPostStatusTag;
            getPostStatusName = Properties.Settings.Default.getPostStatusName;

            // We also need a WPTestClient object for all the tests to use
            wpTC = new WPTestClient(protocol, host);
        }
    }
}

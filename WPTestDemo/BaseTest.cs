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
        /// Default string to use as a non-existent ID in tests
        /// </summary>
        public static string getNonExistentId;

        /// <summary>
        /// Default string to use as the expected message when an item doesn't
        /// exist in the tests
        /// </summary>
        public static string getNonExistentMessage;
        
        /// <summary>
        /// Default string to use as the error code when an item doesn't exist
        /// in the tests
        /// </summary>
        public static string getNonExistentCode;

        /// <summary>
        /// Default string to use for a non-existent tag in tests
        /// </summary>
        public static string getNonExistentTag;

        /// <summary>
        /// Default string to use for an invalid ID in the tests
        /// </summary>
        public static string getInvalidId;

        /// <summary>
        /// Default response message to expect when an item is invalid in the tests
        /// </summary>
        public static string getInvalidMessage;

        /// <summary>
        /// Default response code to expect when an item is invalid in the tests
        /// </summary>
        public static string getInvalidCode;

        /// <summary>
        /// Default string to use for an invalid tag in the tests
        /// </summary>
        public static string getInvalidTag;

        /// <summary>
        /// Default message to expect when a particular test term does not exist
        /// </summary>
        public static string getTermNonExistentMessage;

        /// <summary>
        /// Default error code to expect when a particular test term does not exist
        /// </summary>
        public static string getTermNonExistentCode;

        /// <summary>
        /// Default error message to expect when a comment doesn't exist
        /// </summary>
        public static string getCommentNonExistentMessage;

        /// <summary>
        /// Default error code to expect when a comment doesn't exist
        /// </summary>
        public static string getCommentNonExistentCode;

        /// <summary>
        /// Default error message to expect when a taxonomy doesn't exist
        /// </summary>
        public static string getTaxonomyNonExistentMessage;

        /// <summary>
        /// Default error code to expect when a taxonomy doesn't exist
        /// </summary>
        public static string getTaxonomyNonExistentCode;

        /// <summary>
        /// Default error message to expect when a user doesn't exist
        /// </summary>
        public static string getUserNonExistentMessage;

        /// <summary>
        /// Default error code to expect when a user doesn't exist
        /// </summary>
        public static string getUserNonExistentCode;

        /// <summary>
        /// Default error message to expect when a post type doesn't exist
        /// </summary>
        public static string getPostTypeNonExistentMessage;

        /// <summary>
        /// Default error code to expect when a post type doesn't exist
        /// </summary>
        public static string getPostTypeNonExistentCode;

        /// <summary>
        /// Default error message to expect when a post status doesn't exist
        /// </summary>
        public static string getPostStatusNonExistentMessage;

        /// <summary>
        /// Default error code to expect when a post status doesn't exist
        /// </summary>
        public static string getPostStatusNonExistentCode;

        /// <summary>
        /// For generating the instance of the WP Test Client
        /// </summary>
        public WPTestClient wpTC;

        /// <summary>
        /// For generating an instance of WPTestLib
        /// </summary>
        public WPTestLib wpLib;

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

            // Items specifically pertaining to negative test cases
            getNonExistentId = Properties.Settings.Default.getNonExistentId;
            getNonExistentMessage = Properties.Settings.Default.getNonExistentMessage;
            getNonExistentCode = Properties.Settings.Default.getNonExistentCode;
            getNonExistentTag = Properties.Settings.Default.getNonExistentTag;
            getInvalidId = Properties.Settings.Default.getInvalidId;
            getInvalidMessage = Properties.Settings.Default.getInvalidMessage;
            getInvalidCode = Properties.Settings.Default.getInvalidCode;
            getInvalidTag = Properties.Settings.Default.getInvalidTag;
            getTermNonExistentMessage = Properties.Settings.Default.getTermNonExistentMessage;
            getTermNonExistentCode = Properties.Settings.Default.getTermNonExistentCode;
            getCommentNonExistentMessage = Properties.Settings.Default.getCommentNonExistentMessage;
            getCommentNonExistentCode = Properties.Settings.Default.getCommentNonExistentCode;
            getTaxonomyNonExistentMessage = Properties.Settings.Default.getTaxonomyNonExistentMessage;
            getTaxonomyNonExistentCode = Properties.Settings.Default.getTaxonomyNonExistentCode;
            getUserNonExistentMessage = Properties.Settings.Default.getUserNonExistentMessage;
            getUserNonExistentCode = Properties.Settings.Default.getUserNonExistentCode;
            getPostTypeNonExistentMessage = Properties.Settings.Default.getPostTypeNonExistentMessage;
            getPostTypeNonExistentCode = Properties.Settings.Default.getPostTypeNonExistentCode;
            getPostStatusNonExistentMessage = Properties.Settings.Default.getPostStatusNonExistentMessage;
            getPostStatusNonExistentCode = Properties.Settings.Default.getPostStatusNonExistentCode;

            // We also need a WPTestClient object for all the tests to use
            wpTC = new WPTestClient(protocol, host);

            // And a WPTestLib instance
            wpLib = new WPTestLib();
        }
    }
}

using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to post types on the Wordpress test site.
    /// </summary>
    class TestPostTypes : BaseTest
    {
        ///<summary>
        ///Verify that the GetPostTypes endpoint actually returns data. There
        ///should be a JObject of length == 4.
        ///</summary>
        [Test]
        public void TestGetPostTypesReturnsPostTypes()
        {
            JObject responseObject = wpTC.GetPostTypes();
            Assert.AreEqual(responseObject.Count, 4, "GetPostTypes endpoint not returning expected JSONObject length.");
            Assert.NotNull(responseObject, "GetPostTypes endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a post type by a specific tag off the GetPostTypes endpoint.
        ///</summary>
        [Test]
        public void TestGetPostTypeByTag()
        {
            JObject response = wpTC.GetPostTypeByTag(getPostTypeTag);
            string postTypeName = response.GetValue("name").ToString();
            Assert.NotNull(response, "GetPostTypes endpoint returned a null object. Post type may not exist.");
            Assert.AreEqual(response["slug"].ToString(), getPostTypeTag, "GetPostTypes endpoint didn't return correct post type slug.");
            Assert.AreEqual(postTypeName, getPostTypeName, "Retrieved post type from GetPostTypes endpoint does not have expected name.");
        }
        /// <summary>
        /// Verify that the Get Post Type by Tag endpoint exhibits expected error
        /// behavior if you throw it a post type tag that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetPostTypeTagThatDoesNotExist()
        {
            JObject response = wpTC.GetPostTypeByTag(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getPostTypeNonExistentCode, getPostTypeNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Post Type by Tag endpoint throws expected error
        /// behavior if given invalid data for its post type tag.
        /// </summary>
        [Test]
        public void TestGetPostTypeTagBadId()
        {
            JObject response = wpTC.GetPostTypeByTag(getInvalidTag);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Post Type by Tag endpoint throws error behavior
        /// when using int.MaxValue as a post type tag.
        /// </summary>
        [Test]
        public void TestGetPostTypeTagMaxInt()
        {
            JObject response = wpTC.GetPostTypeByTag(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getPostTypeNonExistentCode, getPostTypeNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Post Type by Tag endpoint throws error behavior
        /// when using int.MinValue as a post type tag.
        /// </summary>
        [Test]
        public void TestGetPostTypeTagMinInt()
        {
            JObject response = wpTC.GetPostTypeByTag(int.MinValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getPostTypeNonExistentCode, getPostTypeNonExistentMessage);
        }
    }
}

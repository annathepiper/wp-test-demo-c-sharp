using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to post types on the Wordpress test site.
    /// </summary>
    class TestPostStatuses : BaseTest
    {
        ///<summary>
        ///Verify that the GetPostStatuses endpoint actually returns data. There
        ///should be a JObject of length == 1.
        ///</summary>
        [Test]
        public void TestGetPostStatusesReturnsPostStatuses()
        {
            JObject responseObject = wpTC.GetPostStatuses();
            Assert.AreEqual(responseObject.Count, 1, "GetPostStatuses endpoint not returning expected JSONObject length.");
            Assert.NotNull(responseObject, "GetPostStatuses endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a post status by a specific tag off the GetPostStatuses endpoint.
        ///</summary>
        [Test]
        public void TestGetPostStatusByTag()
        {
            JObject response = wpTC.GetPostStatusByTag(getPostStatusTag);
            string postStatusName = response.GetValue("name").ToString();
            Assert.NotNull(response, "GetPostStatuses endpoint returned a null object. Post status may not exist.");
            Assert.AreEqual(response["slug"].ToString(), getPostStatusTag, "GetPostStatuses endpoint didn't return correct post status slug.");
            Assert.AreEqual(postStatusName, getPostStatusName, "Retrieved post status from GetPostStatuses endpoint does not have expected name.");
        }
    }
}

using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    class TestPages: BaseTest
    {
        ///<summary>
        ///Verify that the GetPages endpoint actually returns data. There should be a JArray of length > 0.
        ///</summary>
        [Test]
        public void TestGetPagesReturnsPages()
        {
            JArray responseArray = wpTC.GetPages();
            Assert.True(responseArray.Count > 0, "GetPages endpoint not returning at least one object in JArray.");
            Assert.NotNull(responseArray, "GetPages endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a page by a specific ID off the GetPages endpoint.
        ///</summary>
        [Test]
        public void TestGetPageById()
        {
            JObject response = wpTC.GetPageById(getPageId);
            JToken renderedTitle = response.GetValue("title");
            Assert.NotNull(response, "GetPages endpoint returned a null object. Page may not exist.");
            Assert.AreEqual(response["id"].ToString(), getPageId, "GetPages endpoint didn't return correct ID number.");
            Assert.AreEqual(renderedTitle["rendered"].ToString(), getPageTitle, "Retrieved page from GetPages endpoint does not have expected title.");
        }
    }
}

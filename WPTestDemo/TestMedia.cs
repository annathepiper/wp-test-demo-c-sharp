using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    class TestMedia: BaseTest
    {
        ///<summary>
        ///Verify that the GetMedia endpoint actually returns data. There should be a JArray of length > 0.
        ///</summary>
        [Test]
        public void TestGetMediaReturnsMedia()
        {
            JArray responseArray = wpTC.GetMedia();
            Assert.True(responseArray.Count > 0, "GetMedia endpoint not returning at least one object in JArray.");
            Assert.NotNull(responseArray, "GetMedia endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a media item by a specific ID off the GetMedia endpoint.
        ///</summary>
        [Test]
        public void TestGetMediaById()
        {
            JObject response = wpTC.GetMediaById(getMediaIdWindows);
            JToken renderedTitle = response.GetValue("title");
            Assert.NotNull(response, "GetMedia endpoint returned a null object. Media may not exist.");
            Assert.AreEqual(response["id"].ToString(), getMediaIdWindows, "GetMedia endpoint didn't return correct ID number.");
            Assert.AreEqual(renderedTitle["rendered"].ToString(), getMediaTitle, "Retrieved media from GetMedia endpoint does not have expected title.");
        }
    }
}

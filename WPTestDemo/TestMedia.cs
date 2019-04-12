using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to media on the Wordpress test site.
    /// </summary>
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

        /// <summary>
        /// Verify that the Get Media by Id endpoint exhibits expected error
        /// behavior if you throw it a media ID that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetMediaIdThatDoesNotExist()
        {
            JObject response = wpTC.GetMediaById(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getNonExistentCode, getNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Media by Id endpoint throws expected error behavior if given invalid data for its media ID.
        /// </summary>
        [Test]
        public void TestGetMediaIdBadId()
        {
            JObject response = wpTC.GetMediaById(getInvalidId);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Media by Id endpoint throws error behavior when using int.MaxValue as a media ID.
        /// </summary>
        [Test]
        public void TestGetMediaIdMaxInt()
        {
            JObject response = wpTC.GetMediaById(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getNonExistentCode, getNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Media by Id endpoint throws error behavior when using int.MinValue as a media ID.
        /// </summary>
        [Test]
        public void TestGetMediaIdMinInt()
        {
            JObject response = wpTC.GetMediaById(int.MinValue.ToString());
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }
    }
}

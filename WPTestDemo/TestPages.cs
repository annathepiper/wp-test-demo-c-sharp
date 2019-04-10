using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to pages on the Wordpress test site.
    /// </summary>
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

        /// <summary>
        /// Verify that the Get Page by Id endpoint exhibits expected error
        /// behavior if you throw it a page ID that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetPageIdThatDoesNotExist()
        {
            JObject response = wpTC.GetPageById(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getNonExistentCode, getNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Page by Id endpoint throws expected error behavior if given invalid data for its page ID.
        /// </summary>
        [Test]
        public void TestGetPageIdBadId()
        {
            JObject response = wpTC.GetPageById(getInvalidId);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Page by Id endpoint throws error behavior when using int.MaxValue as a page ID.
        /// </summary>
        [Test]
        public void TestGetPageIdMaxInt()
        {
            JObject response = wpTC.GetPageById(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getNonExistentCode, getNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Page by Id endpoint throws error behavior when using int.MinValue as a page ID.
        /// </summary>
        [Test]
        public void TestGetPageIdMinInt()
        {
            JObject response = wpTC.GetPageById(int.MinValue.ToString());
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }
    }
}

using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to tags on the Wordpress test site.
    /// </summary>
    class TestTags: BaseTest
    {
        ///<summary>
        ///Verify that the GetTags endpoint actually returns data. There should be a JArray of length > 0.
        ///</summary>
        [Test]
        public void TestGetTagsReturnsTags()
        {
            JArray responseArray = wpTC.GetTags();
            Assert.True(responseArray.Count > 0, "GetTags endpoint not returning at least one object in JArray.");
            Assert.NotNull(responseArray, "GetTagss endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a tag by a specific ID off the GetTags endpoint.
        ///</summary>
        [Test]
        public void TestGetTagById()
        {
            JObject response = wpTC.GetTagById(getTagId);
            string tagName = response.GetValue("name").ToString();
            Assert.NotNull(response, "GetTags endpoint returned a null object. Tag may not exist.");
            Assert.AreEqual(response["id"].ToString(), getTagId, "GetTags endpoint didn't return correct ID number.");
            Assert.AreEqual(tagName, getTagName, "Retrieved tag from GetTags endpoint does not have expected name.");
        }

        /// <summary>
        /// Verify that the Get Tag by Id endpoint exhibits expected error
        /// behavior if you throw it a tag ID that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetTagIdThatDoesNotExist()
        {
            JObject response = wpTC.GetTagById(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getTermNonExistentCode, getTermNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Tag by Id endpoint throws expected error behavior if given invalid data for its tag ID.
        /// </summary>
        [Test]
        public void TestGetTagIdBadId()
        {
            JObject response = wpTC.GetTagById(getInvalidId);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Tag by Id endpoint throws error behavior when using int.MaxValue as a tag ID.
        /// </summary>
        [Test]
        public void TestGetTagIdMaxInt()
        {
            JObject response = wpTC.GetTagById(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getTermNonExistentCode, getTermNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Tag by Id endpoint throws error behavior when using int.MinValue as a tag ID.
        /// </summary>
        [Test]
        public void TestGetTagIdMinInt()
        {
            JObject response = wpTC.GetTagById(int.MinValue.ToString());
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }
    }
}

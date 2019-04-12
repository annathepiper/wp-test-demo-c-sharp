using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to comments on the Wordpress test site.
    /// </summary>
    class TestComments: BaseTest
    {
        ///<summary>
        ///Verify that the GetComments endpoint actually returns data. There should be a JArray of length > 0.
        ///</summary>
        [Test]
        public void TestGetCommentsReturnsComments()
        {
            JArray responseArray = wpTC.GetComments();
            Assert.True(responseArray.Count > 0, "GetComments endpoint not returning at least one object in JArray.");
            Assert.NotNull(responseArray, "GetComments endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a comment by a specific ID off the GetComments endpoint.
        ///</summary>
        [Test]
        public void TestGetCommentById()
        {
            JObject response = wpTC.GetCommentById(getCommentId);
            JToken renderedContent = response.GetValue("content");
            Assert.NotNull(response, "GetComments endpoint returned a null object. Comment may not exist.");
            Assert.AreEqual(response["id"].ToString(), getCommentId, "GetComments endpoint didn't return correct ID number.");
            Assert.True(renderedContent["rendered"].ToString().Contains(getCommentContent), "Retrieved comment from GetComment endpoint does not have expected content.");
        }

        /// <summary>
        /// Verify that the Get Comment by Id endpoint exhibits expected error
        /// behavior if you throw it a comment ID that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetCommentIdThatDoesNotExist()
        {
            JObject response = wpTC.GetCommentById(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getCommentNonExistentCode, getCommentNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Comment by Id endpoint throws expected error behavior if given invalid data for its comment ID.
        /// </summary>
        [Test]
        public void TestGetCommentIdBadId()
        {
            JObject response = wpTC.GetCommentById(getInvalidId);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Comment by Id endpoint throws error behavior when using int.MaxValue as a comment ID.
        /// </summary>
        [Test]
        public void TestGetCommentIdMaxInt()
        {
            JObject response = wpTC.GetCommentById(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getCommentNonExistentCode, getCommentNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Comment by Id endpoint throws error behavior when using int.MinValue as a comment ID.
        /// </summary>
        [Test]
        public void TestGetCommentIdMinInt()
        {
            JObject response = wpTC.GetCommentById(int.MinValue.ToString());
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }
    }
}

using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace WPTestDemo
{
    ///<summary>
    ///Test cases related to posts on the Wordpress test site.
    ///</summary>
    public class TestPosts : BaseTest
    {
        ///<summary>
        ///Verify that the GetPosts endpoint actually returns data. There should be a JArray of length > 0.
        ///</summary>
        [Test]
        public void TestGetPostsReturnsPosts()
        {
            JArray responseArray = wpTC.GetPosts();
            Assert.True(responseArray.Count > 0, "GetPosts endpoint not returning at least one object in JArray.");
            Assert.NotNull(responseArray, "GetPosts endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a post by a specific ID off the GetPosts endpoint.
        ///</summary>
        [Test]
        public void TestGetPostById()
        {
            JObject response = wpTC.GetPostById(getPostId);
            JToken renderedTitle = response.GetValue("title");
            Assert.NotNull(response, "GetPosts endpoint returned a null object. Post may not exist.");
            Assert.AreEqual(response["id"].ToString(), getPostId, "GetPosts endpoint didn't return correct ID number.");
            Assert.AreEqual(renderedTitle["rendered"].ToString(), getPostTitle, "Retrieved post from GetPosts endpoint does not have expected title.");
        }

        /// <summary>
        /// Verify that the Get Post by Id endpoint exhibits expected error
        /// behavior if you throw it a post ID that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetPostIdThatDoesNotExist()
        {
            JObject response = wpTC.GetPostById(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getNonExistentCode, getNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Post by Id endpoint throws expected error behavior if given invalid data for its post ID.
        /// </summary>
        [Test]
        public void TestGetPostIdBadId()
        {
            JObject response = wpTC.GetPostById(getInvalidId);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Post by Id endpoint throws error behavior when using Integer.MAX_VALUE as a post ID.
        /// </summary>
        [Test]
        public void TestGetPostIdMaxInt()
        {
            JObject response = wpTC.GetPostById(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getNonExistentCode, getNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Post by Id endpoint throws error behavior when using Integer.MIN_VALUE as a post ID.
        /// </summary>
        [Test]
        public void TestGetPostIdMinInt()
        {
            JObject response = wpTC.GetPostById(int.MinValue.ToString());
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }
    }
}

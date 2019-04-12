using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to users on the Wordpress test site.
    /// </summary>
    class TestUsers: BaseTest
    {
        ///<summary>
        ///Verify that the GetUsesrs endpoint actually returns data. There should be a JArray of length > 0.
        ///</summary>
        [Test]
        public void TestGetUsersReturnsUsers()
        {
            JArray responseArray = wpTC.GetUsers();
            Assert.True(responseArray.Count > 0, "GetUsers endpoint not returning at least one object in JArray.");
            Assert.NotNull(responseArray, "GetUsers endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a user by a specific ID off the GetUsers endpoint.
        ///</summary>
        [Test]
        public void TestGetUserById()
        {
            JObject response = wpTC.GetUserById(getUserId);
            string userName = response.GetValue("name").ToString();
            Assert.NotNull(response, "GetUsers endpoint returned a null object. User may not exist.");
            Assert.AreEqual(response["id"].ToString(), getUserId, "GetUsers endpoint didn't return correct ID number.");
            Assert.AreEqual(userName, getUserName, "Retrieved user from GetUsers endpoint does not have expected name.");
        }

        /// <summary>
        /// Verify that the Get User by Id endpoint exhibits expected error
        /// behavior if you throw it a user ID that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetUserIdThatDoesNotExist()
        {
            JObject response = wpTC.GetUserById(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getUserNonExistentCode, getUserNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get User by Id endpoint throws expected error behavior if given invalid data for its user ID.
        /// </summary>
        [Test]
        public void TestGetUserIdBadId()
        {
            JObject response = wpTC.GetUserById(getInvalidId);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get User by Id endpoint throws error behavior when using int.MaxValue as a user ID.
        /// </summary>
        [Test]
        public void TestGetUserIdMaxInt()
        {
            JObject response = wpTC.GetUserById(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getUserNonExistentCode, getUserNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get User by Id endpoint throws error behavior when using int.MinValue as a user ID.
        /// </summary>
        [Test]
        public void TestGetUserIdMinInt()
        {
            JObject response = wpTC.GetUserById(int.MinValue.ToString());
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }
    }
}

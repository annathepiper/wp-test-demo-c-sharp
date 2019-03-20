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
    }
}

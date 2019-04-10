using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// This class is a helper library with methods used by the test classes.
    /// </summary>
    public class WPTestLib
    {
        /// <summary>
        /// Helper method to take a JSON response object, expected error code,
        /// and expected error message, and make sure the response contains the
        /// appropriate data to reflect that the tested-for item does not exist.
        /// </summary>
        /// <param name="response">JObject response to test</param>
        /// <param name="errorCode">Expected error code</param>
        /// <param name="errorMessage">Expected error message</param>
        public void VerifyResponseItemDoesNotExist(JObject response, string errorCode, string errorMessage)
        {
            Assert.AreEqual(response["code"].ToString(), errorCode, "Target endpoint thinks target item ID actually exists.");
            Assert.AreEqual(response["message"].ToString(), errorMessage, "Target endpoint didn't throw the expected error message.");
            JToken responseData = response["data"];
            Assert.NotNull(responseData, "Target endpoint didn't include data object in response.");
            Assert.AreEqual(responseData["status"].ToString(), "404", "Target endpoint didn't return expected error code.");
        }

        /// <summary>
        /// Helper method to take a JSONObject response, an errorCode String,
        /// and an errorMessage String, and verify that the response contains
        /// appropriate data to reflect that the tested-for item is invalid.
        /// </summary>
        /// <param name="response">JObject response data to test</param>
        /// <param name="errorCode">String containing the expected error code</param>
        /// <param name="errorMessage">String containing the expected error message</param>
        public void VerifyResponseItemIsInvalid(JObject response, string errorCode, string errorMessage)
        {
            Assert.AreEqual(response["code"].ToString(), errorCode, "Target endpoint thinks target item ID is actually valid.");
            Assert.AreEqual(response["message"].ToString(), errorMessage, "Target endpoint didn't throw the expected error message.");
            JToken responseData = response["data"];
            Assert.NotNull(responseData, "Target endpoint didn't include data object in response.");
            Assert.AreEqual(responseData["status"].ToString(), "404", "Target endpoint didn't return expected error code.");
        }
    }
}

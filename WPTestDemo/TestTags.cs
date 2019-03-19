using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
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
    }
}

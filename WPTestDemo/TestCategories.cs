using NUnit.Framework;
using Newtonsoft.Json.Linq;

///<summary>
///Test cases related to categories on the Wordpress test site.
///</summary>
namespace WPTestDemo
{
    ///<summary>
    ///Test cases related to categories on the Wordpress test site.
    ///</summary>
    public class TestCategories : BaseTest
    {
        ///<summary>
        ///Verify that the GetCategories endpoint actually returns data. There should be a JArray of length > 0.
        ///</summary>
        [Test]
        public void TestGetCategoriesReturnsCategories()
        {
            JArray responseArray = wpTC.GetCategories();
            Assert.True(responseArray.Count > 0, "GetCategories endpoint not returning at least one object in JArray.");
            Assert.NotNull(responseArray, "GetCategories endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a category by a specific ID off the GetCategories endpoint.
        ///</summary>
        [Test]
        public void TestGetCategoryById()
        {
            JObject response = wpTC.GetCategoryById(getCategoryId);
            string categoryName = response.GetValue("name").ToString();
            Assert.NotNull(response, "GetCategories endpoint returned a null object. Category may not exist.");
            Assert.AreEqual(response["id"].ToString(), getCategoryId, "GetCategories endpoint didn't return correct ID number.");
            Assert.AreEqual(categoryName, getCategoryName, "Retrieved category from GetCategories endpoint does not have expected name.");
        }

        /// <summary>
        /// Verify that the Get Category by Id endpoint exhibits expected error
        /// behavior if you throw it a category ID that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetCategoryIdThatDoesNotExist()
        {
            JObject response = wpTC.GetCategoryById(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getTermNonExistentCode, getTermNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Category by Id endpoint throws expected error behavior if given invalid data for its category ID.
        /// </summary>
        [Test]
        public void TestGetCategoryIdBadId()
        {
            JObject response = wpTC.GetCategoryById(getInvalidId);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Category by Id endpoint throws error behavior when using int.MaxValue as a category ID.
        /// </summary>
        [Test]
        public void TestGetCategoryIdMaxInt()
        {
            JObject response = wpTC.GetCategoryById(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getTermNonExistentCode, getTermNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Category by Id endpoint throws error behavior when using int.MinValue as a category ID.
        /// </summary>
        [Test]
        public void TestGetCategoryIdMinInt()
        {
            JObject response = wpTC.GetCategoryById(int.MinValue.ToString());
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }
    }
}

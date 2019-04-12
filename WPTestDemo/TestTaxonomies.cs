using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace WPTestDemo
{
    /// <summary>
    /// Test cases related to taxonomies on the Wordpress test site.
    /// </summary>
    class TestTaxonomies: BaseTest
    {
        ///<summary>
        ///Verify that the GetTaxonomies endpoint actually returns data. There
        ///should be a JObject of length == 2.
        ///</summary>
        [Test]
        public void TestGetTaxonomiesReturnsTaxonomies()
        {
            JObject responseObject = wpTC.GetTaxonomies();
            Assert.AreEqual(responseObject.Count, 2, "GetTaxonomies endpoint not returning expected JSONObject length.");
            Assert.NotNull(responseObject, "GetTaxonomies endpoint returned a null response.");
        }

        ///<summary>
        ///Verify that you can get a taxonomy by a specific tag off the GetTaxonomies endpoint.
        ///</summary>
        [Test]
        public void TestGetTaxonomyByTag()
        {
            JObject response = wpTC.GetTaxonomyByTag(getTaxonomyTag);
            string taxonomyName = response.GetValue("name").ToString();
            Assert.NotNull(response, "GetTaxonomies endpoint returned a null object. Taxonomy may not exist.");
            Assert.AreEqual(response["slug"].ToString(), getTaxonomyTag, "GetTaxonomies endpoint didn't return correct taxonomy slug.");
            Assert.AreEqual(taxonomyName, getTaxonomyName, "Retrieved taxonomy from GetTaxonomies endpoint does not have expected name.");
        }

        /// <summary>
        /// Verify that the Get Taxonomy by Tag endpoint exhibits expected error
        /// behavior if you throw it a taxonomy tag that doesn't actually exist.
        /// </summary>
        [Test]
        public void TestGetTaxonomyTagThatDoesNotExist()
        {
            JObject response = wpTC.GetTaxonomyByTag(getNonExistentId);
            wpLib.VerifyResponseItemDoesNotExist(response, getTaxonomyNonExistentCode, getTaxonomyNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Taxonomy by Tag endpoint throws expected error behavior if given invalid data for its taxonomy tag.
        /// </summary>
        [Test]
        public void TestGetTaxonomyTagBadId()
        {
            JObject response = wpTC.GetTaxonomyByTag(getInvalidTag);
            wpLib.VerifyResponseItemIsInvalid(response, getInvalidCode, getInvalidMessage);
        }

        /// <summary>
        /// Verify that the Get Taxonomy by Tag endpoint throws error behavior when using int.MaxValue as a taxonomy tag.
        /// </summary>
        [Test]
        public void TestGetTaxonomyTagMaxInt()
        {
            JObject response = wpTC.GetTaxonomyByTag(int.MaxValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getTaxonomyNonExistentCode, getTaxonomyNonExistentMessage);
        }

        /// <summary>
        /// Verify that the Get Taxonomy by Tag endpoint throws error behavior when using int.MinValue as a taxonomy tag.
        /// </summary>
        [Test]
        public void TestGetTaxonomyTagMinInt()
        {
            JObject response = wpTC.GetTaxonomyByTag(int.MinValue.ToString());
            wpLib.VerifyResponseItemDoesNotExist(response, getTaxonomyNonExistentCode, getTaxonomyNonExistentMessage);
        }
    }
}

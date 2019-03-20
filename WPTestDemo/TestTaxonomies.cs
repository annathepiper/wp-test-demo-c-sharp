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
            Assert.True(responseObject.Count == 2, "GetTaxonomies endpoint not returning expected JSONObject length.");
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
    }
}

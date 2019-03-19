using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WPTestDemo
{
    ///<summary>
    ///Helper client the tests use to interact with the WordPress API endpoints.
    ///Uses RestSharp to do the actual GET, POST, etc. calls.
    ///</summary>
    public class WPTestClient
    {
        // Service endpoint templates
        private string wpSite = "{0}://{1}/wp-json/wp/v2/";

        /// <summary>
        /// Client to do calls to the Wordpress API endpoints
        /// </summary>
        public IRestClient Client;

        ///<summary>
        ///Constructor for the class.
        ///</summary>
        ///<param name="incomingHost">
        ///String containing the host address for the test site
        ///</param>
        ///<param name="incomingProtocol">
        ///String containing the protocol to use for URIs
        ///</param>
        public WPTestClient(string incomingHost, string incomingProtocol)
        {
            wpSite = String.Format(wpSite, incomingHost, incomingProtocol);
            Client = new RestClient(wpSite);
        }

        ///<summary>
        ///Gets a JArray of posts on the test WordPress site.
        ///</summary>
        public JArray GetPosts()
        {
            var request = new RestRequest("/posts", DataFormat.Json);
            var response = Client.Get(request);
            JArray responseArray = JArray.Parse(response.Content);
            return responseArray;
        }

        /// <summary>
        /// Get a specific post on the test WordPress site by post ID.
        /// </summary>
        /// <param name="postId">String containing the post ID to work with</param>
        /// <returns>JObject from the Get call</returns>
        public JObject GetPostById(string postId)
        {
            var request = new RestRequest("/posts/{postId}", DataFormat.Json).
                AddParameter("postId", postId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            JObject responseJson = JObject.Parse(response.Content);
            return responseJson;
        }

        /// <summary>
        /// Gets a JArray of categories on the test WordPress site.
        /// </summary>
        public JArray GetCategories()
        {
            var request = new RestRequest("/categories", DataFormat.Json);
            var response = Client.Get(request);
            JArray responseArray = JArray.Parse(response.Content);
            return responseArray;
        }

        /// <summary>
        /// Get a specific category on the test WordPress site by category ID.
        /// </summary>
        /// <param name="categoryId">String containing the category ID to work with</param>
        /// <returns>JObject from the Get call</returns>
        public JObject GetCategoryById(string categoryId)
        {
            var request = new RestRequest("/categories/{categoryId}", DataFormat.Json).
                AddParameter("categoryId", categoryId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            JObject responseJson = JObject.Parse(response.Content);
            return responseJson;
        }

        /// <summary>
        /// Get a JArray of comments on the test WordPress site.
        /// </summary>
        public JArray GetComments()
        {
            var request = new RestRequest("/comments", DataFormat.Json);
            var response = Client.Get(request);
            JArray responseArray = JArray.Parse(response.Content);
            return responseArray;
        }

        /// <summary>
        /// Get a specific comment on the test WordPress site by comment ID.
        /// </summary>
        /// <param name="commentId">String containing the comment ID to work with</param>
        /// <returns>JObject containing the comment data</returns>
        public JObject GetCommentById(string commentId)
        {
            var request = new RestRequest("/comments/{commentId}", DataFormat.Json).
                AddParameter("commentId", commentId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            JObject responseJson = JObject.Parse(response.Content);
            return responseJson;
        }
    }
}

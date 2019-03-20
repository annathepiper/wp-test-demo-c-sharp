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
            return JArray.Parse(response.Content);
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
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Gets a JArray of categories on the test WordPress site.
        /// </summary>
        public JArray GetCategories()
        {
            var request = new RestRequest("/categories", DataFormat.Json);
            var response = Client.Get(request);
            return JArray.Parse(response.Content);
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
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a JArray of tags on the test WordPress site.
        /// </summary>
        public JArray GetTags()
        {
            var request = new RestRequest("/tags", DataFormat.Json);
            var response = Client.Get(request);
            return JArray.Parse(response.Content);
        }

        /// <summary>
        /// Get a specific tag on the test WordPress site by tag ID.
        /// </summary>
        /// <param name="tagId">String containing the tag ID to work with</param>
        /// <returns>JObject from the Get call</returns>
        public JObject GetTagById(string tagId)
        {
            var request = new RestRequest("/tags/{tagId}", DataFormat.Json).
                AddParameter("tagId", tagId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a JArray of pages on the test WordPress site.
        /// </summary>
        public JArray GetPages()
        {
            var request = new RestRequest("/pages", DataFormat.Json);
            var response = Client.Get(request);
            return JArray.Parse(response.Content);
        }

        /// <summary>
        /// Get a specific page on the test WordPress site by page ID.
        /// </summary>
        /// <param name="pageId">String containing the ID of the page to work with</param>
        /// <returns>JObject containing the page data</returns>
        public JObject GetPageById(string pageId)
        {
            var request = new RestRequest("/pages/{pageId}", DataFormat.Json).
                AddParameter("pageId", pageId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a JArray of comments on the test WordPress site.
        /// </summary>
        public JArray GetComments()
        {
            var request = new RestRequest("/comments", DataFormat.Json);
            var response = Client.Get(request);
            return JArray.Parse(response.Content);
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
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a JObject of taxonomies on the test WordPress site.
        /// </summary>
        /// <returns></returns>
        public JObject GetTaxonomies()
        {
            var request = new RestRequest("/taxonomies", DataFormat.Json);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a specific taxonomy on the test WordPress site by its tag
        /// </summary>
        /// <param name="taxonomyTag">String containing the tag for the taxonomy to work with</param>
        /// <returns>JObject containing the taxonomy data</returns>
        public JObject GetTaxonomyByTag(string taxonomyTag)
        {
            var request = new RestRequest("/taxonomies/{taxonomyTag}", DataFormat.Json).
                AddParameter("taxonomyTag", taxonomyTag, ParameterType.UrlSegment);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);

        }

        /// <summary>
        /// Get a JSONArray of media on the test WordPress site.
        /// </summary>
        public JArray GetMedia()
        {
            var request = new RestRequest("/media", DataFormat.Json);
            var response = Client.Get(request);
            return JArray.Parse(response.Content);
        }

        /// <summary>
        /// Get a specific media item on the test WordPress site by its ID.
        /// </summary>
        /// <param name="mediaId">String containing the ID of the media item to work with</param>
        /// <returns>JObject containing the media data</returns>
        public JObject GetMediaById(string mediaId)
        {
            var request = new RestRequest("/media/{mediaId}", DataFormat.Json).
                AddParameter("mediaId", mediaId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a JArray of users on the test WordPress site.
        /// </summary>
        public JArray GetUsers()
        {
            var request = new RestRequest("/users", DataFormat.Json);
            var response = Client.Get(request);
            return JArray.Parse(response.Content);
        }

        /// <summary>
        /// Get a specific user on the test WordPress site by their ID.
        /// </summary>
        /// <param name="userId">String containing the ID of the user to work with</param>
        /// <returns>JObject containing the user data</returns>
        public JObject GetUserById(string userId)
        {
            var request = new RestRequest("/users/{userId}", DataFormat.Json).
                AddParameter("userId", userId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a JObject of post types on the test WordPress site.
        /// </summary>
        /// <returns></returns>
        public JObject GetPostTypes()
        {
            var request = new RestRequest("/types", DataFormat.Json);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);
        }

        /// <summary>
        /// Get a specific post type on the test WordPress site by its tag.
        /// </summary>
        /// <param name="postTypeTag">String containing the tag for the post type to work with</param>
        /// <returns>JObject containing the post type data</returns>
        public JObject GetPostTypeByTag(string postTypeTag)
        {
            var request = new RestRequest("/types/{postTypeTag}", DataFormat.Json).
                AddParameter("postTypeTag", postTypeTag, ParameterType.UrlSegment);
            var response = Client.Get(request);
            return JObject.Parse(response.Content);
        }
    }
}

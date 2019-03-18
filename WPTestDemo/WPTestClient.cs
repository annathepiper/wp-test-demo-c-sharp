using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WPTestDemo
{
    /** <summary>Helper client the tests use to interact with the WordPress API endpoints. Uses RestSharp to do the actual GET, POST, etc. calls.</summary>
     */
    public class WPTestClient
    {
        // Service endpoint templates
        private string wpSite = "{0}://{1}/wp-json/wp/v2/";

        // Client to do the actual calls
        public IRestClient Client;

        /**
         * <summary>Constructor for the class.</summary>
         * <param name="incomingHost">String containing the host address for the test site</param>
         * <param name="incomingProtocol">String containing the protocol to use for URIs</param>
         */
        public WPTestClient(string incomingHost, string incomingProtocol)
        {
            wpSite = String.Format(wpSite, incomingHost, incomingProtocol);
            Client = new RestClient(wpSite);
        }

        /**
         * <summary>Gets a JArray of posts on the test WordPress site.</summary>
         */
        public JArray getPosts()
        {
            var request = new RestRequest("/posts", DataFormat.Json);
            var response = Client.Get(request);
            JArray responseArray = JArray.Parse(response.Content);
            return responseArray;
        }

        public JObject getPostById(string postId)
        {
            var request = new RestRequest("/posts/{postId}", DataFormat.Json).
                AddParameter("postId", postId, ParameterType.UrlSegment);
            var response = Client.Get(request);
            JObject responseJson = JObject.Parse(response.Content);
            return responseJson;
        }
    }
}

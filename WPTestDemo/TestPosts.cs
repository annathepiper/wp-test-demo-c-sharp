using NUnit.Framework;
using WPTestDemo;
using Newtonsoft.Json.Linq;

/**
 * <summary>Test cases related to posts on the Wordpress test site.</summary>
 */
public class TestPosts: BaseTest
{
    /**
     * <summary>Verify that the GetPosts endpoint actually returns data. There should be a JArray of length > 0.</summary>
     */
    [Test]
	public void TestGetPostsReturnsPosts()
	{
        JArray responseArray = wpTC.getPosts();
        Assert.True(responseArray.Count > 0, "GetPosts endpoint not returning at least one object in JArray.");
        Assert.NotNull(responseArray, "GetPosts endpoint returned a null response.");
	}

    /**
     * <summary>Verify that you can get a post by a specific ID off the GetPosts endpoint.</summary>
     */
    [Test]
    public void TestGetPostById()
    {
        JObject response = wpTC.getPostById(getPostId);
        JToken renderedTitle = response.GetValue("title");
        Assert.NotNull(response, "GetPosts endpoint returned a null object. Post may not exist.");
        Assert.AreEqual(response["id"].ToString(), getPostId, "GetPosts endpoint didn't return correct ID number.");
        Assert.AreEqual(renderedTitle["rendered"].ToString(), getPostTitle, "Retrieved post from GetPosts endpoint does not have expected title.");
    }
}

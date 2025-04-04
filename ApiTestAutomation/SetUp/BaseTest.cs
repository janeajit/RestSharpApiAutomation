using NUnit.Framework;

namespace ApiTestAutomation
{
    /// <summary>
    /// Base test class for setup and utilities
    /// </summary>
    [TestFixture]
    public class BaseTest
    {
        protected ApiClient Api;
        protected static Random Random = new Random();
        protected string BaseUrl = "https://practice.expandtesting.com/notes/api";

        [SetUp]
        public void SetUp()
        {
            Api = new ApiClient(BaseUrl);
        }

        protected static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => chars[Random.Next(chars.Length)]).ToArray());
        }
    }
}


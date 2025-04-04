using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ApiTestAutomation
{
	[TestFixture]
	public class TestFile
	{
		private RestClient Client;
		private string baseUrl = "https://practice.expandtesting.com/notes/api";

        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [SetUp]
        public void SetUp()
		{
			Client = new RestClient(baseUrl);
		}

		[Test]
		public async Task Test_GetUsers()
		{
			var request = new RestRequest("users/profile", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("x-auth-token","d9d7c722c2294cc7851f4caef5ad2b275ac1bb1b192a45fdbf80a3c192863489");
            var response = await Client.ExecuteAsync(request);
			Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
		}

		[Test]
		public async Task Test_RegisterUser()
		{
            var name = GenerateRandomString(4);
            var request = new RestRequest("/users/register", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("name", name);
            request.AddParameter("email", name+"@gmail.com");
            request.AddParameter("password", "Password1234$");

			var response = await Client.ExecuteAsync(request);
			Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

        }

        [Test]
        public async Task Test_LoginUser()
        {
            var request = new RestRequest("/users/login", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("email", "test1234@gmial.com");
            request.AddParameter("password", "Password1234$");

            var response = await Client.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

        }

    }
}


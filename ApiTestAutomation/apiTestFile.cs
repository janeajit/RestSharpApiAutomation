using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.Common;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace ApiTestAutomation
{
    public class UserTests : BaseTest
    {
        [Test]
        public async Task Test_GetUsers()
        {
            var headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "x-auth-token", "d9d7c722c2294cc7851f4caef5ad2b275ac1bb1b192a45fdbf80a3c192863489" }
            };

            var response = await Api.SendRequestAsync("users/profile", Method.Get, headers);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            ApiResponse responseObject = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            Assert.That(responseObject.Success, Is.EqualTo(true));
            _test.Log(Status.Info, "Request Data: " + JsonConvert.SerializeObject(response));
        }

        [Test]
        public async Task Test_RegisterUser()
        {
            var name = GenerateRandomString(4);
            var headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/x-www-form-urlencoded" }
            };

            var parameters = new Dictionary<string, string>
            {
                { "name", name },
                { "email", $"{name}@gmail.com" },
                { "password", "Password1234$" }
            };

            var response = await Api.SendRequestAsync("/users/register", Method.Post, headers, parameters);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            _test.Log(Status.Info, "Request Data: " + JsonConvert.SerializeObject(parameters));
        }

        [Test]
        public async Task Test_LoginUser()
        {
            var headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/x-www-form-urlencoded" }
            };

            var parameters = new Dictionary<string, string>
            {
                { "email", "test890@gmail.com" },
                { "password", "Password1234$" }
            };

            var response = await Api.SendRequestAsync("/users/login", Method.Post, headers, parameters);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            _test.Log(Status.Info, "Request Data: " + JsonConvert.SerializeObject(parameters));
        }
    }
}

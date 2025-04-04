using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
        protected static ExtentReports _extent;
        protected ExtentTest _test;

        [OneTimeSetUp]
        public void Setup()
        {
            var sparkReporter = new ExtentSparkReporter("TestResults.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        [SetUp]
        public void SetUp()
        {
            Api = new ApiClient(BaseUrl);
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void AfterTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                _test.Fail("Test failed!");
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _extent.Flush();
        }

        protected static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => chars[Random.Next(chars.Length)]).ToArray());
        }
    }
}


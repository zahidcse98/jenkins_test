using NUnit.Framework;
using OpenQA.Selenium;
using NUnit.Allure;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace ExampleProject.Selenium
{
    [AllureNUnit]
    [AllureSuite("Basic Auth Test")]
    internal class BasicAuthTest : BaseTest
    {
        INetwork networkInterceptor = null;
        private static readonly By basicAuth = By.XPath(string.Format(preciseTextXpath, "Basic Auth"));
        private static readonly By successAuth = By.XPath(string.Format(partialTextXpath, "Congratulations! You must have the proper credentials"));

        [SetUp]
        public void Authorize()
        {
            NetworkAuthenticationHandler handler = new NetworkAuthenticationHandler()
            {
                //add credentials
                UriMatcher = d => d.Host.Contains("herokuapp"),
                Credentials = new PasswordCredentials("admin", "admin")
            };

            networkInterceptor = driver.Manage().Network;
            networkInterceptor.AddAuthenticationHandler(handler);
            //start monitoring
            networkInterceptor.StartMonitoring();
        }

        [Test]
        public void SuccessfulBasicAuthTest()
        {
            ClickBasicAuthLink();
            ValidateSuccessMessagge();
        }

        [AllureStep("Clicking the basicAuth link")]
        private void ClickBasicAuthLink()
        {
            driver.FindElement(basicAuth).Click();
        }

        [AllureStep("Showing the successMessage")]
        private void ValidateSuccessMessagge()
        {
            Assert.True(driver.FindElement(successAuth).Displayed, "Message is not displayed");
        }

        //stop monitoring
        public void TearItDown()
        {
            networkInterceptor.StopMonitoring();
        }
    }
}

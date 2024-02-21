using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace unit5_final_task.Accuweather.Hooks
{
    [Binding]
    internal class Hooks
    {
        private readonly Browser browser = AqualityServices.Browser;
        private static readonly JsonSettingsFile settings = new("config.json");


        [BeforeScenario]
        public void Setup()
        {
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
            
        }

        [When(@"I go back to the Main Page")]
        public void GoBackToTheMainPage()
        {
            browser.GoBack();
            /*WebDriverWait wait = new WebDriverWait(AqualityServices.Browser.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("body")));*/
        }



        [AfterScenario]
        public void TearDown()
        {
            browser.Quit();
        }
    }

   
}
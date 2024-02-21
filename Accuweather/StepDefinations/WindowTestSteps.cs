using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using unit5_final_task.Accuweather.Pages;

namespace unit5_final_task.Accuweather.StepDefinations
{
    [Binding]
    internal class WindowTestSteps
    {

        WindowTest windowTestSteps = new();

        [Then("The Alert Box Examples Page Is opened in a new tab")]
        public void WindowPageIsDisplayed()
        {
            //windowTestSteps.State.WaitForDisplayed();
            Assert.IsTrue(windowTestSteps.promptBtnDisplayed(), "Alert Box Examples Page Is not Displayed!!");

        }

        [When("I Click Show Prompt Box btn")]
        public void WindowLinkIsShown()
        {
            windowTestSteps.ClickPromptOpenBtn();
        }

        private bool checkAlertBoxIsDisplayed()
        {
            try
            {
                IAlert alert = AqualityServices.Browser.Driver.SwitchTo().Alert();
                Logger.Instance.Info("Alert is displayed");
                return true;
            }
            catch (NoAlertPresentException)
            {
                Logger.Instance.Info("Alert is displayed");
                return false;
            }
        }

        /*[When("I Wait Until the alert is displayed")]
        public void MakeSureAlertBoxIsDisplayed()
        {
            Assert.IsTrue(checkAlertBoxIsDisplayed(), "Alert prompt box is not displayed!!");
            

        }*/

        [Then("I Put SomeValue into the input box and accept the alert")]
        public void InputSomeValueAndAcceptAlert()
        {

            AqualityServices.Browser.HandleAlert(AlertAction.Accept, "somevalue");
            Assert.IsTrue(windowTestSteps.SuccessMessageIsShow(), "Alert message is not shown with input value!!");
        }


        /*[When("I consent data usage")]
        public void AcceptPolicy()
        {
            mainPage.AcceptPolicy();
        }

        [When(@"I Input '(.*)' in the search field")]
        public void SearchCity(string city)
        {
            mainPage.searchCity(city);
        }

        [When("I click on the first search result")]
        public void ClickOnFirstResult()
        {
            mainPage.ClickOnFirstResult();
        }

        [Then ("the search results list is displayed")]
        public void SearchResultIsDisplayed()
        {
            Assert.IsTrue(mainPage.IsSearchResultListIsDisplayed(), "Search Result is not Displayed");
        }

        [When("I click on the search field")]
        public void ClickingTheSearchBox()
        {
            mainPage.ClickTheSearchBox();
        }

        [Then("the use your current location label is displayed")]
        public void UseYourCurrentLocationLabelIsDisplayed()
        {
            Assert.IsTrue(mainPage.IsUseYourCurrentLocationDisplayed(), "Use your current location label is not displayed");
        }

        [Then("Main Page is Opened")]
        public void IsMainPageIsOpened()
        {
            
            Assert.IsTrue(mainPage.IsHomePageOpened(), "HomePage is not opened.");
        }

        [When("I choose first city in Recent locations")]
        public void ChooseFirstCityOfRecentLocations()
        {
            mainPage.ClickFirstCityOfRecentLocations();
        }*/

    }
}
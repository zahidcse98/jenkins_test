using NUnit.Framework;
using TechTalk.SpecFlow;
using unit5_final_task.Accuweather.Pages;

namespace unit5_final_task.Accuweather.StepDefinations
{
    [Binding]
    internal class MainPageSteps
    {
        
        MainPage mainPage = new();

        [When("I consent data usage")]
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
        }

    }
}
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements.Interfaces;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using unit5_final_task.Accuweather.Hooks;

namespace unit5_final_task.Accuweather.Pages
{
    internal class MainPage : Form
    {
        private const string pageName = "Windows Example Test";
        private ILink alertNewWindowJSLink => ElementFactory.GetLink(By.Id("goalerts"), "Alerts In A New Window From JavaScript Link");
        private ILabel mainPageH1elem => ElementFactory.GetLabel(By.XPath(string.Format(LocatorConstants.PreciseTextLocator,
            "Windows Links and Examples")), "Main Page Heading");


        public MainPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, pageName)), "Windows Example Test | Homepage") { }

        public void OpenNewWindowJSLink()
        {
            alertNewWindowJSLink.Click();
        }

        public bool MainPageH1Showed()
        {
            return mainPageH1elem.State.IsDisplayed;
        }

        public bool WindowLinkIsOpend()
        {
            return alertNewWindowJSLink.State.IsDisplayed;
        }


        /*public void ClickTheSearchBox()
        {
            searchTextBox.Click();
        }
        public void searchCity(string city)
        {
            searchTextBox.ClearAndType(city);
        }*/

        /*public bool IsSearchResultListIsDisplayed()
        {
            string visibilityAttributeValue = GetTheSearchResultListVisibilityAttribute();
            if(visibilityAttributeValue == "visible")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void ClickOnFirstResult()
        {
            searchResultElement.Click();
        }

        public bool IsUseYourCurrentLocationDisplayed()
        {
            useYourCurrentLocationBtn.State.WaitForDisplayed();
            return useYourCurrentLocationBtn.State.IsDisplayed;
        }

        public string GetTheSearchResultListVisibilityAttribute()
        {
            string script = @"
                var divElement = document.querySelector('.search-results');

                // Check if the element is found
                if (divElement) {
                    // Get the visibility CSS attribute value
                    var visibilityAttributeValue = window.getComputedStyle(divElement).getPropertyValue('visibility');
    
                    // Log the visibility attribute value to the console
                    return visibilityAttributeValue;
                }
            ";
            
            string visibilityAttributeValueOfSearchResultsDivElement = AqualityServices.Browser.ExecuteScript<string>(script);
            return visibilityAttributeValueOfSearchResultsDivElement;
        }

        public bool IsHomePageOpened()
        {
            *//*WebDriverWait wait = new WebDriverWait(AqualityServices.Browser.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.TagName("body")));*/

            /*string script = @"
                (function isHomeBodyTagExists() {
                    return document.querySelector('body.home') !== null;
                })();
            ";*/

            /*string isHomePageOpened = AqualityServices.Browser.ExecuteScript<string>(script);
            if(isHomePageOpened == "true")
            {
                return true;
            }
            else { return false;}*//*

            if (AqualityServices.Browser.Driver.Title.Equals(pageName))
            {
                return true;
            } else
            {
                return false;
            }
        }

       public void ClickFirstCityOfRecentLocations()
        {
            firstCityOfRecentLocations.Click();
        }*/
        
    }
}
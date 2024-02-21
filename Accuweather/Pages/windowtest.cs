using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections;

namespace unit5_final_task.Accuweather.Pages
{
    internal class WindowTest : Form
    {
        private const string pageName = "Test Page For JavaScript Alerts";
        private IButton promptOpenBtn => ElementFactory.GetButton(By.Id("promptexample"), "Prompt Opening Btn");

        private ILabel successMessage => ElementFactory.GetLabel(By.XPath(string.Format(LocatorConstants.PartialTextLocator,
            "You clicked OK")), "Success message with input value.");
        public WindowTest() : base(By.XPath(string.Format(LocatorConstants.PartialTextLocator, pageName)), "Test Page For JavaScript Alerts | Page") { }

        public void ClickPromptOpenBtn()
        {
            promptOpenBtn.WaitAndClick();
            //promptOpenBtn.Click();
        }

        public bool promptBtnDisplayed()
        {
            promptOpenBtn.State.WaitForDisplayed();
            return promptOpenBtn.State.IsDisplayed;
        }

        public bool SuccessMessageIsShow()
        {
            return successMessage.State.IsDisplayed;
        }
        
    }
}
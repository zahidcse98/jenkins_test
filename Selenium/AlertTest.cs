using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;


namespace ExampleProject.Selenium
{
    [AllureNUnit]
    internal class AlertsTest : BaseTest
    {
        private static readonly By jsAlertLink = By.XPath(string.Format(preciseTextXpath, "JavaScript Alerts"));
        private static readonly By clickForJSAlertBtn = By.XPath("//button[@onclick='jsAlert()']");
        private static readonly By clickForJSConfirmBtn = By.XPath("//button[@onclick='jsConfirm()']");
        private static readonly By successMessageFieldforAlertBtn = By.XPath(string.Format(preciseTextXpath, "You successfully clicked an alert"));
        private static readonly By successMessageFieldforConfirmBtnPositive = By.XPath(string.Format(preciseTextXpath, "You clicked: Ok"));
        private static readonly By successMessageFieldforConfirmBtnNegative = By.XPath(string.Format(preciseTextXpath, "You clicked: Cancel"));
        


        [Test]
        public void AlertTest()
        {
            // testing js alert
            ClickJsAlertLink();
            ClickJSAlertBtn();
            VerifyAlertisPresentandAccept();
            // Improvised code for Handleing Alert()
            
        }

        [AllureStep("Clicking AlertLink")]
        private void ClickJsAlertLink()
        {
            driver.FindElement(jsAlertLink).Click();
        }
        [AllureStep]
        private void ClickJSAlertBtn()
        {
            driver.FindElement(clickForJSAlertBtn).Click();
        }

        [AllureStep("Verify the alert is present and accept the alert")]
        private void VerifyAlertisPresentandAccept()
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }

        [TearDown]
        public void TearItDown()
        {
            driver.Quit();
        }

        [Test] 
        public void ConfirmTest()
        {

            ClickJsAlertLink();
            ClickJSConfirmBtn();
            AcceptAlert();
            ShowingAcceptSuccessMessage();
            
        }

        [AllureStep]
        private void ClickJSConfirmBtn()
        {
            driver.FindElement(clickForJSConfirmBtn).Click();
        }

        [AllureStep]
        private void AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        [AllureStep]
        private void ShowingAcceptSuccessMessage()
        {
            Assert.True(driver.FindElement(successMessageFieldforAlertBtn).Displayed, "success message is not Found");
        }

        [TearDown]
        public void TearItDown2()
        {
            driver.Quit();
        }

}
}

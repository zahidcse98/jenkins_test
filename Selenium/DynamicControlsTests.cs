using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace ExampleProject.Selenium
{
    [AllureNUnit]
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By dynamicControl = By.XPath(string.Format(preciseTextXpath, "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format(preciseTextXpath, "Enable"));
        private static readonly By inputField = By.XPath("//*[@id='input-example']//input");
        private static readonly string randomValue = Guid.NewGuid().ToString();

        [Test]
        public void DynamicControlsTest()
        {

            ClickDynamicControlLink();
            ClickEnableBtn();
            ConfirmInputEnabled();
            SendRandomValueInput();
            ShowSuccessMessage();
            //input randomly generated text
            
            //assert input text
            
        }

        [AllureStep("Click the allure dynamic control link")]
        private void ClickDynamicControlLink()
        {
            driver.FindElement(dynamicControl).Click();
        }

        [AllureStep("CLick enable btn")]
        private void ClickEnableBtn()
        {
            driver.FindElement(enableBtn).Click();
        }

        [AllureStep("Confirm that the input is enabled")]
        private void ConfirmInputEnabled()
        {
            var inputElement = driver.FindElement(By.XPath("//*[@id='input-example']//input"));
            Assert.True(IsEnabled(inputElement), "input is not enabled!");
        }

        [AllureStep("Send random value to the input")]
        private void SendRandomValueInput()
        {
            var inputElement = driver.FindElement(inputField);
            inputElement.SendKeys(randomValue);
        }

        [AllureStep("Showing the success message")]
        private void ShowSuccessMessage()
        {
            Assert.AreEqual(driver.FindElement(inputField).GetAttribute("value"), randomValue);
        }

        [AllureStep("Check if the input element is enabled")]
        private bool IsEnabled(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

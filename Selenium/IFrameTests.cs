using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ExampleProject.Selenium
{
    internal class IFrameTests : BaseTest
    {
        private static readonly By framesBtn = By.XPath(string.Format(preciseTextXpath, "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format(preciseTextXpath, "iFrame"));
        private static readonly By editBtn = By.XPath(string.Format(preciseTextXpath, "Edit"));
        private static readonly By undoBtn = By.XPath(string.Format(preciseTextXpath, "Undo"));
        private static readonly By textField = By.Id("tinymce");

        private static readonly string textIsNotDisplayedMsg = "Text is not displayed";
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";
        private static readonly string iframeId = "mce_0_ifr";

        [Test]
        public void IFrameTest()
        {
            driver.FindElement(framesBtn).Click();
            driver.FindElement(iframeBtn).Click();
            //switch to iframe
            driver.SwitchTo().Frame(iframeId);
            //input text to the textfield
            driver.FindElement(textField).SendKeys(randomValue);
            Assert.True(driver.FindElement(By.XPath(string.Format(preciseTextXpath, initText + randomValue))).Displayed,
                    textIsNotDisplayedMsg);
            //switch back to default content
            driver.SwitchTo().DefaultContent();
            driver.FindElement(editBtn).Click();
            driver.FindElement(undoBtn).Click();

            //switch to Iframe
            driver.SwitchTo().Frame(iframeId);
            //assert text is not displayed
            Assert.IsTrue(driver.FindElement(By.XPath(string.Format(preciseTextXpath, initText))).Displayed, textIsNotDisplayedMsg);
        }
    }
}
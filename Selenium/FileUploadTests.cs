using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;

namespace ExampleProject.Selenium
{
    [AllureNUnit]
    internal class FileUploadTests : BaseTest
    {
        private static readonly By fileUploadBtn = By.XPath(string.Format(preciseTextXpath, "File Upload"));
        private static readonly By chooseFileBtn = By.Id("file-upload");
        private static readonly By fileSubmitField = By.Id("file-submit");
        private static readonly By uploadedFileField = By.Id("uploaded-files");
        private static readonly string fileName = "basic.txt";
        private static readonly string filePath = relativePathFolder + fileName;

    [Test]
   public void FileUploadTest()
        {
            ClickUploadFileLink();
            SelectFileToUpload();
            ClickSubmitBtn();
            ShowingSuccessMessage();
        }

        [AllureStep("Click Upload file link")]
        private void ClickUploadFileLink()
        {
            driver.FindElement(fileUploadBtn).Click();
        }

        [AllureStep("Select file to upload")]
        private void SelectFileToUpload()
        {
            FileInfo fileToUpload = new(filePath);
            //upload a new file
            driver.FindElement(chooseFileBtn).SendKeys(fileToUpload.FullName);
        }

        [AllureStep("Click file submit button")]
        private void ClickSubmitBtn()
        {
            driver.FindElement(fileSubmitField).Click();
        }

        [AllureStep("Show the success message")]
        private void ShowingSuccessMessage()
        {
            Assert.AreEqual(driver.FindElement(uploadedFileField).Text, fileName);
        }
    }
}

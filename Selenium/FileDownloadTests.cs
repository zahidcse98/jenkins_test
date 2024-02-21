using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace ExampleProject.Selenium
{
    [AllureNUnit]
    internal class FileDownloadTests : BaseTest
    {
        private static readonly string fileName = "test.txt";
        
        private static readonly By fileDownloadBtn = By.XPath(string.Format(preciseTextXpath, "File Download"));
        private static readonly By fileNameField = By.XPath(string.Format(preciseTextXpath, fileName));

        private static readonly string filePath = relativePathFolder + fileName;
        private static readonly FileInfo downloadedFile = new(Path.GetFullPath(filePath));

        [Test]
        public void FileDownloadTest()
        {
            ClickFileDownloadLink();
            ConfirmDownloadFileShown();
            ClickDownloadingFile();
            ShowSuccessMessage();

        }

        [AllureStep("Click FileDownload Link")]
        private void ClickFileDownloadLink()
        {
            driver.FindElement(fileDownloadBtn).Click();
        }

        [AllureStep("Confirm that the correct file is displayed")]
        private void ConfirmDownloadFileShown()
        {
            Assert.True(driver.FindElement(fileNameField).Displayed, "File is not displayed");
        }

        [AllureStep("Click the download file link")]
        private void ClickDownloadingFile()
        {
            driver.FindElement(fileNameField).Click();
        }
        [AllureStep("Showing SuccessMessage")]
        private void ShowSuccessMessage()
        {
            Assert.True(ISFileDownloaded(filePath), "file is not downloaded");
        }
        private bool ISFileDownloaded(string filePath)
        {
            var newfile = new FileInfo(Path.GetFullPath(filePath));
            return newfile.Exists;
        }
        //delete the downloaded file
        [TearDown]
        public void deleteFile()
        {
            if (downloadedFile.Exists)
                downloadedFile.Delete();
        }
    }
}

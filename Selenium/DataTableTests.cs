using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace ExampleProject.Selenium
{
    [AllureNUnit]
    internal class DataTableTests : BaseTest
    {
        private static readonly By sortableDataTables = By.XPath(string.Format(preciseTextXpath, "Sortable Data Tables"));
        private static readonly By dueColumn = By.XPath("//*[@id='table1']//td[4]");
        private static readonly double expectedSum = 251.00;
        private double result = 0.00;
        private static readonly string currencyRegex = "[^\\d.]";


        [Test]
        public void DataTableTest()
        {
            //assert due sum
            ClickDataTablesLink();
            result = CalculateResult();
            ShowSuccessMessage(result);
        }

        [AllureStep("Click the allure datatable link:")]
        private void ClickDataTablesLink()
        {
            driver.FindElement(sortableDataTables).Click();

        }

        [AllureStep("Calculating the sums")]
        private double CalculateResult()
        {
            var dueListElements = driver.FindElements(dueColumn);
            var acctualSum = 0.00;
            foreach (WebElement element in dueListElements)
            {
                acctualSum += Convert.ToDouble(Regex.Replace(element.Text, currencyRegex, "").Replace(",", "."));

            }

            return acctualSum;
        }

        [AllureStep("Showing SuccessMessage")]
        private void ShowSuccessMessage(double acctualSum)
        {
            Assert.AreEqual(expectedSum, acctualSum, "sum is not correct!!");
        }
    }
}

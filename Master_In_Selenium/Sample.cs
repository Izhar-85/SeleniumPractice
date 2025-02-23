using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using System;
using AventStack.ExtentReports.Reporter;

namespace Master_In_Selenium
{
    [TestFixture]
    public class Sample
    {
        private IWebDriver driver;
        private static ExtentReports extent;
        private ExtentTest test;

        [OneTimeSetUp]
        public void SetupExtent()
        {
            extent = ExtentReportSetup.GetExtentReport();
        }

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void GoogleSearchTest()
        {
            try
            {
                test.Info("Opening Google");
                driver.Navigate().GoToUrl("https://www.google.com");

                test.Info("Verifying Title");
                Assert.That(driver.Title, Is.EqualTo("Google"));

                test.Pass("Test Passed Successfully!");
            }
            catch (Exception e)
            {
                test.Fail("Test Failed: " + e.Message);
                throw;
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test Failed");
            }
            else
            {
                test.Pass("Test Passed");
            }
            driver.Quit();
        }

        [OneTimeTearDown]
        public void TearDownExtent()
        {
            extent.Flush(); // Generates the report
        }
    }
}

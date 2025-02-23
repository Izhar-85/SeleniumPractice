using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace Data_Driven_Testing
{
    public class DataDrivenWithDifferentDataSets
    {
        private IWebDriver driver;

        [SetUp]
        public void Open_the_browser_and_hit_the_URL()
        {
            driver = new ChromeDriver();
            driver.Url = "https://testautomationpractice.blogspot.com/";
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Close_browser()
        {
            driver.Quit();
        }

        [Test]
        [TestCase("Izhar", "izhar123@gmail.com", "657865684")]
        [TestCase("Raman", "raman123@gmail.com", "56464486")]
        [TestCase("Mohit", "mohit123@gmail.com", "4564764688")]
        public void Data_driven_testing_using_RowData(string nfname, string femail, string fmobno)
        {
            Actions actions = new Actions(driver);
            actions.Click(driver.FindElement(By.Id("name")))
           .SendKeys(nfname + Keys.Tab)
           .SendKeys(femail + Keys.Tab)
           .SendKeys(fmobno + Keys.Tab)
           .Build()
           .Perform();
            Thread.Sleep(3000);
        }

        [Test, TestCaseSource(nameof(ComplexTestCases))]
        public void Data_driven_testing_using_DynamicData(string nfname, string femail, string fmobno)
        {
            Actions actions = new Actions(driver);
            actions.Click(driver.FindElement(By.Id("name")))
           .SendKeys(nfname + Keys.Tab)
           .SendKeys(femail + Keys.Tab)
           .SendKeys(fmobno + Keys.Tab)
           .Build()
           .Perform();
            Thread.Sleep(3000);
        }
        public static IEnumerable<TestCaseData> ComplexTestCases
        {
            get
            {
                yield return new TestCaseData(new object[] { "Izhar", "izhar123@gmail.com", "657865684" });
                yield return new TestCaseData(new object[] { "Mohit", "mohit123@gmail.com", "4564764688" });
            }
        }

        [Test, TestCaseSource(nameof(ReadExcel))]
        public void Data_driven_testing_using_ExcelData(string nfname, string femail, string fmobno)
        {
            Actions actions = new Actions(driver);
            actions.Click(driver.FindElement(By.Id("name")))
           .SendKeys(nfname + Keys.Tab)
           .SendKeys(femail + Keys.Tab)
           .SendKeys(fmobno + Keys.Tab)
           .Build()
           .Perform();
            Thread.Sleep(3000);
        }

        public static IEnumerable<object[]> ReadExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(@"D:\Selenium\data.xlsx")))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row; //get row count
                for (int row = 1; row <= rowCount; row++)
                {
                    yield return new object[] 
                    {
                         worksheet.Cells[row, 1].Value?.ToString().Trim(), // First name
                         worksheet.Cells[row, 2].Value?.ToString().Trim(), // Last name
                         worksheet.Cells[row, 3].Value?.ToString().Trim() // Enrollment date
                    };
                }
            }
        }
    }
}
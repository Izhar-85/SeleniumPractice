using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace Master_In_Selenium
{
    public class ExtentReportSetup
    {
        public static ExtentReports? extent;
        public static ExtentTest? test;

        public static ExtentReports GetExtentReport()
        {
            if (extent == null)
            {
                string reportPath = AppDomain.CurrentDomain.BaseDirectory + "TestReport.html";
                var htmlReporter = new ExtentSparkReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }
    }
}

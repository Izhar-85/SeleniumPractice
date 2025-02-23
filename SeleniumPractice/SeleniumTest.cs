using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPractice
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void GetElementbyIDAndSendTextUsingSendKey()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.hyrtutorials.com/p/css-selectors-practice.html";
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("firstName")).SendKeys("Hyy, I'm Izhar Khan");
            Thread.Sleep(3000);
            string s = (string)((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementById('firstName').value");
            Console.WriteLine(s);   
            driver.Quit();
        }

        [TestMethod]
        public void GetElementbyUsingCssSelector()
        { 

        }
     }
}
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Master_In_Selenium;
internal class PracticeTest
{
    [Test]
    public void Advanced_configuration_browser_testing()
    {
        ChromeOptions options = new ChromeOptions();
        options.AcceptInsecureCertificates = true;
        options.AddArgument("--incognito");
        IWebDriver driver = new ChromeDriver(options);
        driver.Url = "https://www.hyrtutorials.com/p/css-selectors-practice.html";
        driver.Manage().Window.Maximize();
        driver.Quit();
    }
    [Test]
    public void Handle_multiple_tabs_and_multiple_window()
    {
        IWebDriver driver = new ChromeDriver() { Url= "https://www.hyrtutorials.com/p/window-handles-practice.html" };
        driver.Manage().Window.Maximize();
        IWebElement webElement = driver.FindElement(By.Id("newTabsBtn"));
        webElement.Click();
        Thread.Sleep(3000);
        ReadOnlyCollection<string> windowhandles = driver.WindowHandles;
        string t1= windowhandles[0];
        string t2= windowhandles[1];
        string t3= windowhandles[2];

        driver.SwitchTo().Window(t1);
        Thread.Sleep(3000);
        driver.SwitchTo().Window(t2);
        Thread.Sleep(3000);
        driver.SwitchTo().Window(t3);
        Thread.Sleep(3000);

        driver.SwitchTo().Window(t2);
        Thread.Sleep(3000);
        driver.FindElement(By.Id("firstName")).SendKeys("Hi new tab");
        Thread.Sleep(3000);

        driver.SwitchTo().Window(t1);
        Thread.Sleep(3000);
        driver.FindElement(By.Id("name")).SendKeys("Hi, Izhar");
        Thread.Sleep(3000);

        driver.Quit();
    }

    [Test]
    public void Add_cookies_and_delete_and_get_all_the_cookies()
    {
        IWebDriver driver = new ChromeDriver() { Url = "https://www.hyrtutorials.com/p/window-handles-practice.html" };
        driver.Manage().Window.Maximize();
        Thread.Sleep(3000);

        Screenshot sc= ((ITakesScreenshot)driver).GetScreenshot();
        
        sc.SaveAsFile("D:\\Selenium\\sc.png");

        //add new cookies
        Cookie mycookie = new Cookie("name", "Izhar khan");
        Cookie mycookie1 = new Cookie("Password", "Izhar@909090090");
        driver.Manage().Cookies.AddCookie(mycookie);
        driver.Manage().Cookies.AddCookie(mycookie1);

        //get the cookies
        var getcookie = driver.Manage().Cookies.AllCookies;
        Thread.Sleep(2000);

        //get the cookie by name
        var pass = driver.Manage().Cookies.GetCookieNamed("Password");

        //delete all cookies
        driver.Manage().Cookies.DeleteAllCookies();
        
        var getcookie2 = driver.Manage().Cookies.AllCookies;

        driver.Quit();
    }

    [Test]
    public void Implicit_and_Explicit_wait_and_fluent_wait_handling()
    {
        IWebDriver driver = new ChromeDriver() { Url = "https://www.hyrtutorials.com/p/waits-demo.html" };
        driver.Manage().Window.Maximize();
        Thread.Sleep(3000);
        //implicit wait
        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        //driver.FindElement(By.Id("btn1")).Click();
        //driver.FindElement(By.Id("txt1")).SendKeys("Hi, sorry for 5 sec delay...");

        //Explicit wait

        //driver.FindElement(By.Id("btn2")).Click();
        //WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));

        //// Wait until the text box is enabled
        //IWebElement textBox = wait.Until(driver =>
        //{
        //    var element = driver.FindElement(By.Id("txt2")); 
        //    return element.Displayed ? element : null; 
        //});
        //textBox.SendKeys("Sorry for 10 sec delay...");

        //Fluent wait
        driver.FindElement(By.Id("btn2")).Click();
        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
        {
            Timeout = TimeSpan.FromSeconds(15), // Maximum wait time
            PollingInterval = TimeSpan.FromSeconds(2) // Check every second
        };

        // Specify the exception types to ignore
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        // Use Fluent Wait to wait until the text box is displayed
        IWebElement textBox = fluentWait.Until(driver =>
        {
            IWebElement element = driver.FindElement(By.Id("txt2"));
            return element.Displayed ? element : null;
        });

        textBox.SendKeys("Sorry for 10 sec delay...");
        Thread.Sleep(2000);
        driver.Quit() ;
    }
}


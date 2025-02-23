//using Microsoft.Expression.Encoder.ScreenCapture;
using Allure.NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.Runtime;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Reflection.Metadata;

namespace Master_In_Selenium;

public class SeleniumTestCases
{
    private IWebDriver driver;

    [SetUp]
    public void Open_the_browser_and_hit_the_URL()
    {
        driver = new ChromeDriver();
        driver.Url = "https://www.hyrtutorials.com/p/css-selectors-practice.html";
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void Close_browser()
    {
        driver.Quit();
    }

    [Test]
    public void Manage_the_basic_window_of_chrome_browser()
    {
        driver.Manage().Window.FullScreen();
        Thread.Sleep(5000);
        //get the title
        Console.WriteLine(driver.Title);
        //get the page source
        Console.WriteLine(driver.PageSource);
        driver.Manage().Window.Minimize();
        Thread.Sleep(5000);
        driver.Manage().Window.Maximize();
        Thread.Sleep(5000);
        driver.Manage().Window.Size = new Size(400, 600);
        Thread.Sleep(3000);
        Size size = driver.Manage().Window.Size;
        Console.WriteLine(size);
        Thread.Sleep(5000);
        driver.Manage().Window.Position = new Point(400, 200);
        Thread.Sleep(3000);
        Point point = driver.Manage().Window.Position;
        Console.WriteLine(point);
    }

    [Test]
    public void Manage_the_navigation_of_web_page()
    {
        driver.Navigate().GoToUrl("https://www.pavantestingtools.com/p/introduction-to-java-programming.html");
        Console.WriteLine(driver.Title);
        Thread.Sleep(5000);
        driver.Navigate().Back();
        Thread.Sleep(5000);
        driver.Navigate().Forward();
        Thread.Sleep(5000);
        driver.Navigate().Refresh();
    }

    [Test]
    public void Find_the_element_using_CSS_selector()
    {
        //using #(id) selector
        IWebElement wbe1 = driver.FindElement(By.CssSelector("input#lastName"));
        wbe1.SendKeys("Hi, Khan");
        Thread.Sleep(3000);
        wbe1.Clear();
        //using .(class) selector
        var wbe2 = driver.FindElements(By.CssSelector("input.name"));
        foreach (var item in wbe2)
        {
            item.SendKeys("Hi, class");
            Thread.Sleep(5000);
            item.Clear();
        }
        Thread.Sleep(3000);

        //using tag name
        IWebElement wbe3 = driver.FindElement(By.CssSelector("input[class='confirm']"));
        IJavaScriptExecutor jswbe3 = (IJavaScriptExecutor)driver;
        jswbe3.ExecuteScript("arguments[0].scrollIntoView(true);", wbe3);
        wbe3.Click();

        Thread.Sleep(3000);

        //using element element css selector
        IWebElement wbe4 = driver.FindElement(By.CssSelector("option[value=java]"));
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", wbe4);
        wbe4.Click();
        Thread.Sleep(5000);

    }

    [Test]
    public void Find_the_element_using_XPath_selector()
    {

        //IWebElement wb1 = driver.FindElement(By.XPath("//input[@placeholder='Country']"));

        //IWebElement wb1 = driver.FindElement(By.XPath("//input[@id='firstName'][@name='fname']"));

        driver.Navigate().GoToUrl("https://www.hyrtutorials.com/p/add-padding-to-containers.html");
        //IWebElement wb1 = driver.FindElement(By.XPath("//tr[3]/td[2]"));

        //IWebElement wb1 = driver.FindElement(By.XPath("//form/div/input[@type='text'][position()=1]"));

        //var wb1 = driver.FindElements(By.XPath("//tr[3]/preceding-sibling::tr"));
        //foreach (var item in wb1)
        //{
        //    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", item);
        //    Console.WriteLine(item.Text);
        //}
        //var wb1 = driver.FindElements(By.XPath("//table/ancestor::div"));
        //var wb1 = driver.FindElements(By.XPath("//table/descendant::td"));
        string ss = driver.FindElement(By.XPath("//form/div/label")).Text;
        Console.WriteLine(ss);
        Thread.Sleep(5000);
    }

    [Test]
    public void Select_the_single_selection_and_multiselection_dropdown()
    {
        driver.Navigate().GoToUrl("https://www.hyrtutorials.com/p/html-dropdown-elements-practice.html");
        IWebElement webElement = driver.FindElement(By.Id("course"));
        //IWebElement webElement = driver.FindElement(By.Id("ide"));
        SelectElement element = new SelectElement(webElement);
        IList<IWebElement> elements = element.Options;
        Console.WriteLine(elements.Count);
        elements.Select(x=>x.Text).ToList().ForEach(x => Console.WriteLine(x));
        Thread.Sleep(3000);

        //IWebElement webElement = driver.FindElement(By.Id("ide"));
        //SelectElement element = new SelectElement(webElement);

        //var s = element.IsMultiple;
        //element.SelectByText("NetBeans");
        //Thread.Sleep(3000);
        //element.SelectByText("Eclipse");
        //Thread.Sleep(3000);
        ////element.DeselectByText("NetBeans");
        //Thread.Sleep(3000);
    }

    [Test]
    public void Action_class_and_its_properties()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        Actions actions = new Actions(driver);

        //actions.MoveToElement(driver.FindElement(By.Id("femalerb")))
        //    .Click()
        //    .Build()
        //    .Perform();

        //actions.Click(driver.FindElement(By.Id("femalerb")))
        //    .Build()
        //    .Perform();

        //actions.DoubleClick(driver.FindElement(By.XPath("//*[text()='Copy Text']")))
        //    .Build()
        //    .Perform();

        actions.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable")))
            .Build()
            .Perform();

        //actions.DragAndDropToOffset(driver.FindElement(By.Id("draggable")), 150, 20)
        //       .Build()
        //       .Perform();

        actions.Click(driver.FindElement(By.Id("name")))
            .SendKeys("Izhar" + Keys.Tab)
            .SendKeys("izhar123@gmail.com" + Keys.Tab)
            .SendKeys("8708198660" + Keys.Tab)
            .Build()
            .Perform();

        Thread.Sleep(3000);
    }

    [Test]
    public void SwitchTo_and_alert_confirm_and_prompt_box()
    {
        //Alert box

        //driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        //driver.FindElement(By.XPath("//*[text()='Alert']")).Click();
        //Thread.Sleep(2000);
        //string s = driver.SwitchTo().Alert().Text;
        //Console.WriteLine(s);
        //driver.SwitchTo().Alert().Accept();
        //Thread.Sleep(2000);

        //Confirm box

        //driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        //driver.FindElement(By.XPath("//*[text()='Confirm Box']")).Click();
        //Thread.Sleep(2000);
        //driver.SwitchTo().Alert().Dismiss();
        //Thread.Sleep(2000);
        //driver.FindElement(By.XPath("//*[text()='Confirm Box']")).Click();
        //driver.SwitchTo().Alert().Accept();
        //Thread.Sleep(2000);

        //Promt box

        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.FindElement(By.XPath("//*[text()='Prompt']")).Click();
        Thread.Sleep(2000);
        driver.SwitchTo().Alert().SendKeys("Izhar");
        driver.SwitchTo().Alert().Accept();
        Thread.Sleep(2000);
    }

    [Test]
    public void IFrame_Testing()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.SwitchTo().Frame("frame-one796456169");
        IWebElement element = driver.FindElement(By.Id("RESULT_TextField-0"));

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        Thread.Sleep(1000);

        element.SendKeys("Hi, Izhar Khan");
        Thread.Sleep(2000);

        driver.SwitchTo().DefaultContent();

        Thread.Sleep(2000);
        driver.FindElement(By.XPath("//table[@id='productTable']/tbody/tr[3]/td[4]/input[@type='checkbox']")).Click();
        Thread.Sleep(2000);
    }

    [Test]
    public void Capturing_the_screenshot_using_IWebDriver_Element()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("D:\\Selenium\\Test.png");
        TakesScreenshot(driver, driver.FindElement(By.Id("male")));
    }

    /// <summary>
    /// Taking Screenshot for element
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="element"></param>
    private void TakesScreenshot(IWebDriver driver, IWebElement element)
    {
        string fileName = "D:\\Selenium\\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".jpg";
        Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
        Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
        Rectangle croppedImage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
        screenshot = screenshot.Clone(croppedImage, screenshot.PixelFormat);
        screenshot.Save(string.Format(fileName, System.Drawing.Imaging.ImageFormat.Jpeg));
    }

    [Test]
    public void Capturing_the_video_using_IWebDriver_Element()
    {
        //driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");

        //ScreenCaptureJob scj = new ScreenCaptureJob();
        //scj.OutputScreenCaptureFileName = @"D:\Selenium\Test.avi";
        //scj.Start();

        //IWebElement element = driver.FindElement(By.XPath("//table[@id='productTable']/tbody/tr[3]/td[4]/input[@type='checkbox']"));
        //Thread.Sleep(1000);
        //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //Thread.Sleep(1000);
        //element.Click();

        //scj.Stop();
        //Thread.Sleep(1000);
    }

    [Test]
    public void JavaScriptExecuter_and_its_properties()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");

        //handle checkbox
        
        ((IJavaScriptExecutor)driver).ExecuteScript("document.querySelectorAll('input[value=male]')[0].click()");

        //get the inner text

        //var s = ((IJavaScriptExecutor)driver).ExecuteScript("return document.documentElement.innerText;").ToString();

        //get the title of the page

        //var s = ((IJavaScriptExecutor)driver).ExecuteScript("return document.title;").ToString();

        //get the url of the page

        //var s = ((IJavaScriptExecutor)driver).ExecuteScript("return document.URL;").ToString();

        //to scroll the page

        //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,500)");

        //to scroll the page to full bottom vertically

        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");

        Thread.Sleep(2000);
    }

    [Test, Description("Non-UI Test Case")]
    public void Chrome_option_class_operation_with_UILess()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--headless");
        ChromeDriver dvr = new ChromeDriver(options);
        dvr.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        string s = dvr.FindElement(By.XPath("//table[@name='BookTable']/tbody/tr[3]/td ")).Text;
        Console.WriteLine(s);
    }

    [Test]
    public void Event_handling_listning_and_performing_different_operation()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        EventFiringWebDriver eventFiringWebDriver = new EventFiringWebDriver(driver);

        eventFiringWebDriver.ElementClicking += eventFiringWebDriver_ElementClicking;
        eventFiringWebDriver.ElementValueChanged += EventFiringWebDriver_ElementValueChanging;
        driver = eventFiringWebDriver;
        driver.FindElement(By.Id("male")).Click();
        Thread.Sleep(2000);
        driver.FindElement(By.Id("name")).SendKeys("Hi, Izhar");
        Thread.Sleep(2000);
    }

    private void EventFiringWebDriver_ElementValueChanging(object? sender, WebElementEventArgs e)
    {
        HighlightElement(e.Element, e.Driver);
        Console.WriteLine("Element value is changing!!!");
    }

    private void eventFiringWebDriver_ElementClicking(object? sender, WebElementEventArgs e)
    {
        HighlightElement(e.Element, e.Driver);
        Console.WriteLine("Event is Clicking...");
    }
    private IWebElement HighlightElement(IWebElement element, IWebDriver driver)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='4px dotted yellow'", element);
        return element;
    }

    [Test]
    public void File_downloading_operation_using_web_driver()
    {
        string expectedFilePath = @"C:\Downloads\file-sample_100kB.doc";
        bool fileExists = false;

        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\Downloads");
        var driver = new ChromeDriver(chromeOptions);
        driver.Navigate().GoToUrl("https://file-examples.com/index.php/sample-documents-download/sample-doc-download/");
        driver.Manage().Window.Maximize();
        driver.FindElement(By.XPath("//table/tbody/tr[1]/td[5]/a")).Click();  
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        wait.Until(driver =>
        {
            return File.Exists(expectedFilePath);
        });
        Console.WriteLine("File exists : " + fileExists);
        FileInfo fileInfo = new FileInfo(expectedFilePath);
        Console.WriteLine("File Length : " + fileInfo.Length);
        Console.WriteLine("File Name : " + fileInfo.Name);
        Console.WriteLine("File Full Name :" + fileInfo.FullName);
        Assert.That(fileInfo.Length, Is.EqualTo(100352));
        Assert.That(fileInfo.Name, Is.EqualTo("file-sample_100kB.doc"));
        Assert.That(fileInfo.FullName, Is.EqualTo(@"C:\Downloads\file-sample_100kB.doc"));
    }
}
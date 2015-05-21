using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumWD
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Program Files (x86)\\Google\\Chrome\\Application");
            //IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Window.Maximize();

            Thread.Sleep(1000);

            IWebElement searchBox = driver.FindElement(By.Id("lst-ib"));
            searchBox.SendKeys("Wisarut Phuvanantanond");
            searchBox.SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("https://maps.google.com/" + "/");
            driver.FindElement(By.Id("searchboxinput")).Clear();
            driver.FindElement(By.Id("searchboxinput")).SendKeys("Central Rama 3, Bangkok, Thailand");
            driver.FindElement(By.Id("searchboxinput")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("#zoom>div.widget-zoom>button:first-child")).Click();
            }

            Thread.Sleep(5000);

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("#zoom>div.widget-zoom>button:nth-child(2)")).Click();
            }

            //driver.FindElement(By.Id("zoom")).Click();
            //driver.FindElement(By.Id("zoom")).Click();
            //driver.FindElement(By.Id("zoom")).Click();
            //Console.WriteLine("PageSource");
            //Console.WriteLine(driver.PageSource);
            //Console.WriteLine("---"); 
            //Console.WriteLine("Title");
            //Console.WriteLine(driver.Title);
            //Console.WriteLine("---");
            //Console.WriteLine("Window Handle");
            //Console.WriteLine(driver.CurrentWindowHandle);
            //Console.WriteLine("---");
            //Console.WriteLine("Url");
            //Console.WriteLine(driver.Url);

            Console.ReadKey();
        }
    }
}

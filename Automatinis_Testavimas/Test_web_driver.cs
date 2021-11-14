using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automatinis_Testavimas
{
    class Test_web_driver
    {
        [Test]
        public static void Test_chrome_driver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://login.yahoo.com/";
            chrome.Quit();
        }

        [Test]
        public static void Test_firefox_driver()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "http://login.yahoo.com/";
            firefox.Quit();
        }

        [Test]
        public static void Test_chrome1_driver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://login.yahoo.com/";
            IWebElement login_input_field = chrome.FindElement(By.Id("login-username"));
            login_input_field.SendKeys("Test");
            chrome.Quit();
        }

        [Test]
        public static void Test_selenium_page()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement input_field = chrome.FindElement(By.Id("user-message"));
            string my_text = "Labas";
            input_field.SendKeys(my_text);
            Thread.Sleep(5000);
            IWebElement pop_up = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            pop_up.Click();
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.AreEqual(my_text, result.Text, "Tekstas neatsirado");
            chrome.Quit();
        }
    }
}

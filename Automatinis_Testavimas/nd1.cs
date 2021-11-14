using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automatinis_Testavimas
{
    class nd1
    {
        private static IWebDriver Driver;

        [OneTimeSetUp]
        public static void Set_up()
        {
            Driver = new ChromeDriver();
            Driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement pop_up = Driver.FindElement(By.Id("at-cv-lightbox-close"));
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => pop_up.Displayed);
            pop_up.Click();
        }

        [OneTimeTearDown]
        public static void Tear_down()
        {
           Driver.Quit();
        }

        [TestCase("2", "2", "4", TestName = "2+2=4")]
        [TestCase("-5", "3", "-2", TestName = "-5+3=-2")]
        [TestCase("a", "b", "NaN", TestName = "a+b=NaN")]
        public static void First_test(string first_field, string second_field, string result)
        {
            
            //Thread.Sleep(5000);
            //IWebElement pop_up = Driver.FindElement(By.Id("at-cv-lightbox-close"));
            //pop_up.Click();
            
            IWebElement input_field1 = Driver.FindElement(By.Id("sum1"));
            IWebElement input_field2 = Driver.FindElement(By.Id("sum2"));
            input_field1.Clear();
            input_field1.SendKeys(first_field);
            input_field2.Clear();
            input_field2.SendKeys(second_field);

            IWebElement button = Driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();

            IWebElement result_from_page = Driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(result, result_from_page.Text, "Result is NOK");
        }
        /*
        [Test]
        public static void Second_test()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            Thread.Sleep(5000);
            IWebElement pop_up = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            pop_up.Click();

            IWebElement input_field1 = chrome.FindElement(By.Id("sum1"));
            string first_input = "-5";
            input_field1.SendKeys(first_input);

            IWebElement input_field2 = chrome.FindElement(By.Id("sum2"));
            string second_input = "3";
            input_field2.SendKeys(second_input);

            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", result.Text, "-5+3 is equal -2");
            chrome.Close();
        }

        [Test]

        public static void Third_test()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";

            Thread.Sleep(5000);
            IWebElement pop_up = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            pop_up.Click();

            IWebElement input_field1 = chrome.FindElement(By.Id("sum1"));
            string first_input = "a";
            input_field1.SendKeys(first_input);

            IWebElement input_field2 = chrome.FindElement(By.Id("sum2"));
            string second_input = "b";
            input_field2.SendKeys(second_input);

            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", result.Text, "a+b is equal NaN");
            chrome.Close();
        }
        */
    }
}

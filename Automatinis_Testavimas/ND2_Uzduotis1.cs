using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas
{
    class ND2_Uzduotis1
    {
        private static IWebDriver Driver_chrome;
        private static IWebDriver Driver_firefox;

        [OneTimeSetUp]
        public static void Set_up()
        {
            Driver_chrome = new ChromeDriver();
            Driver_chrome.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            Driver_chrome.Manage().Window.Maximize();

            Driver_firefox = new FirefoxDriver();
            Driver_firefox.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            Driver_firefox.Manage().Window.Maximize();

            

        }
        [OneTimeTearDown]
        public static void Tear_down()
        {
            Driver_chrome.Quit();
            Driver_firefox.Quit();
        }
        [Test]
        public static void Test_chrome()
        {
            IWebElement version = Driver_chrome.FindElement(By.ClassName("simple-major"));
            Assert.AreEqual("Chrome 95 on Windows 10", version.Text, "Versija netinkama");
        }

        [Test]
        public static void Test_firefox()
        {
            IWebElement version = Driver_firefox.FindElement(By.ClassName("simple-major"));
            Assert.AreEqual("Firefox 94 on Windows 10", version.Text, "Versija netinkama");
        }
    }
}

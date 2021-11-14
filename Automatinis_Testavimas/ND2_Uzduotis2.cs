using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas
{
    class ND2_Uzduotis2
    {
        private static IWebDriver Driver_chroma;

        [OneTimeSetUp]
        public static void Set_up()
        {
            Driver_chroma = new ChromeDriver();
            Driver_chroma.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            Driver_chroma.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver_chroma.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public static void Tear_down()
        {
            Driver_chroma.Quit();
        }

        [Test]
        public static void Check_one_box()
        {
            Driver_chroma.FindElement(By.Id("isAgeSelected")).Click();
            IWebElement result = Driver_chroma.FindElement(By.Id("txtAge"));
            Assert.IsTrue(result.Text.Equals("Success - Check box is checked"));
        }
        
        [Test]
        public static void Multiple_check_box()
        {
            IReadOnlyCollection<IWebElement> multiple_check_box = Driver_chroma.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement element in multiple_check_box)
            {
                element.Click();
            }
            IWebElement result = Driver_chroma.FindElement(By.Id("check1"));
            Assert.IsTrue(result.Text.Equals("Uncheck All"));
        }
    }
}

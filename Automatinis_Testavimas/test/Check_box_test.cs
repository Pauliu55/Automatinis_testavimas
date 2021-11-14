using Automatinis_Testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.test
{
    class Check_box_test
    {
        class CheckboxDemoTest
        {
            private static Check_box _page;

            [OneTimeSetUp]
            public static void SetUp()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
                _page = new Check_box(driver);
            }

            [OneTimeTearDown]

            public static void TearDown()
            {
                _page.Close_browser();
            }

            [Order(3)]
            [Test]
            public void TestSingleCheckBox()
            {
                _page.CheckSingleCheckbox()
                    .CheckResult();
            }

            [Order(1)]
            [Test]
            public void TestCheckAllCheckboxes()
            {
                _page.CheckAllCheckboxes()
                    .CheckButtonValue("Uncheck All");
            }

            [Order(2)]
            [Test]
            public void TestUncheckAllCheckboxes()
            {
                _page.CheckAllCheckboxes()
                    .ClickButton()
                    .VerifyThatAllCheckboxesAreUnchecked();
            }
        }
    }
}

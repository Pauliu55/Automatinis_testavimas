using Automatinis_Testavimas.Drivers;
using Automatinis_Testavimas.page;
using Automatinis_Testavimas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
namespace Automatinis_Testavimas.page
{
    public class Base_test
    {
        public static IWebDriver driver;
        public static Check_box _check_box_demo_page;
        public static Selenium_input_page _selenium_input_page;
        public static Drop_down_page _dropDownPage;
        public static Vartu_technika_page _vartu_technika_page;
        public static Senukai_page _senukai_page;
        public static Alert_page _alert_page;



        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = Custom_drivers.Get_chrome_driver();
            //driver = CustomDriver.GetIncognitoChrome();
            _check_box_demo_page = new Check_box(driver);
            _dropDownPage = new Drop_down_page(driver);
            _selenium_input_page = new Selenium_input_page(driver);
            _vartu_technika_page = new Vartu_technika_page(driver);
            _senukai_page = new Senukai_page(driver);
            _alert_page = new Alert_page(driver);
        }

        [TearDown]

        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                My_ss.Make_screen_shot(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
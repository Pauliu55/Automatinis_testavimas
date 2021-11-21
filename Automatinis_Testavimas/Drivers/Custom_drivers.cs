using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.Drivers
{
    public class Custom_drivers
    {
        public static IWebDriver Get_chrome_driver()
        {
            return Get_driver(Browser.Chrome);
        }
        public static IWebDriver Get_firefox_driver()
        {
            return Get_driver(Browser.Firefox);
        }

        public static IWebDriver Get_incognito_chrome()
        {
            return Get_driver(Browser.IncognitoChrome);
        }

        private static IWebDriver Get_driver(Browser browser_name)
        {
            IWebDriver driver = null;

            switch (browser_name)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case Browser.IncognitoChrome:
                    driver = Get_chrome_with_options();
                    break;
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            return driver;

        }
        private static IWebDriver Get_chrome_with_options()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            options.AddArgument("start-maximized");
            return new ChromeDriver(options);

        }
    }
}

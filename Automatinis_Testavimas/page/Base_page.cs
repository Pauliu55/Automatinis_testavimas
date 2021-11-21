using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    public class Base_page
    {
        protected static IWebDriver Driver;

        public Base_page(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void Close_browser()
        {
            Driver.Quit();
        }
    }
}

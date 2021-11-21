using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    public class Senukai_page : Base_page
    {
        private const string Page_address = "https://www.senukai.lt/";

        public Senukai_page(IWebDriver webdriver) : base(webdriver)
        { }

        public Senukai_page Navigate_to_default_page()
        {
            if (Driver.Url != Page_address)
                Driver.Url = Page_address;
            return this;
        }

        public Senukai_page Accept_cookie()
        {
            Cookie my_cookie = new Cookie("CookieConsent",
                "{stamp:%27HrfXET9bNa3cUan1VV7i8S1SymLHoOd0XBrynFq4y0dO4gzmXX+4KQ==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1637340040391%2Cregion:%27lt%27}",
                "www.senukai.lt", "/",
                DateTime.Now.AddDays(2));
            Driver.Manage().Cookies.AddCookie(my_cookie);
            Driver.Navigate().Refresh();
            return this;
        }

    }
}

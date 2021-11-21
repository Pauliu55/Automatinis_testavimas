using Automatinis_Testavimas.page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    public class Alert_page : Base_page
    {
        private const string Page_address = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
        private IWebElement Alert_button => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement Confirmation_alert_button => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement Prompt_alert_button => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));


        public Alert_page(IWebDriver webdriver) : base(webdriver)
        { }

        public Alert_page Navigate_to_default_page()
        {
            if (Driver.Url != Page_address)
                Driver.Url = Page_address;
            return this;
        }

        public Alert_page Click_alert_button()
        {
            Alert_button.Click();
            return this;
        }

        public Alert_page Accept_alert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }
        public Alert_page Click_confirmation_alert_button()
        {
            Confirmation_alert_button.Click();
            return this;
        }

        public Alert_page Dismiss_confirmation_alert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
            return this;
        }
        public Alert_page Click_prompt_alert_button()
        {
            Prompt_alert_button.Click();
            return this;
        }
        public Alert_page Insert_text_and_accept_prompt_alert(string text)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
            return this;
        }
    }
}
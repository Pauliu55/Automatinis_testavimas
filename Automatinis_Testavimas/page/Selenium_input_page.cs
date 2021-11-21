using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    public class Selenium_input_page : Base_page
    {
        private const string Page_address = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
        private IWebElement _input_field => Driver.FindElement(By.Id("user-message"));
        private IWebElement _button => Driver.FindElement(By.CssSelector("#get-input > button"));
        private IWebElement _result => Driver.FindElement(By.Id("display"));
        private IWebElement _first_input => Driver.FindElement(By.Id("sum1"));
        private IWebElement _second_input => Driver.FindElement(By.Id("sum2"));
        private IWebElement _get_total_button => Driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement _result_from_page => Driver.FindElement(By.Id("displayvalue"));
        public Selenium_input_page(IWebDriver webdriver) : base(webdriver)
        { }

        public Selenium_input_page Navigate_to_default_page()
        {
            if (Driver.Url != Page_address)
                Driver.Url = Page_address;
            return this;
        }

        public Selenium_input_page Insert_text(string text)
        {
            _input_field.Clear();
            _input_field.SendKeys(text);
            return this;
        }

        public Selenium_input_page Click_show_message_button()
        {
            _button.Click();
            return this;
        }

        public Selenium_input_page Check_result(string expected_result)
        {
            Assert.AreEqual(expected_result, _result.Text, "Tekstas neatsirado");
            return this;
        }
        public Selenium_input_page Insert_first_input(string text)
        {
            _first_input.Clear();
            _first_input.SendKeys(text);
            return this;
        }
        public Selenium_input_page Insert_second_input(string text)
        {
            _second_input.Clear();
            _second_input.SendKeys(text);
            return this;
        }

        public Selenium_input_page Insert_boths_input(string first, string second)
        {
            Insert_first_input(first);
            Insert_second_input(second);
            return this;
        }
        public Selenium_input_page Click_get_total_button()
        {
            _get_total_button.Click();
            return this;
        }
        public Selenium_input_page Check_sum_result(string expected_result_sum)
        {
            Assert.AreEqual(expected_result_sum, _result_from_page.Text, "Result is NOK");
            return this;
        }

    }
}

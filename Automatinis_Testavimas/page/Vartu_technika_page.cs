using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    public class Vartu_technika_page : Base_page
    {
        private const string Page_address = "http://vartutechnika.lt/";

        private IWebElement _width_input => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _height_input => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _auto_check_box => Driver.FindElement(By.Id("automatika"));
        private IWebElement _montavimo_check_box => Driver.FindElement(By.Id("darbai"));
        private IWebElement _calculate_button => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _result_box => Driver.FindElement(By.CssSelector("#calc_result > div"));

        public Vartu_technika_page(IWebDriver webdriver) : base(webdriver)
        { }

        public Vartu_technika_page Navigate_to_default_page()
        {
            if (Driver.Url != Page_address)
                Driver.Url = Page_address;
            return this;
        }


        public Vartu_technika_page Insert_width(string width)
        {
            _width_input.Clear();
            _width_input.SendKeys(width);
            return this;
        }
        public Vartu_technika_page Insert_height(string height)
        {
            _height_input.Clear();
            _height_input.SendKeys(height);
            return this;
        }

        public Vartu_technika_page Insert_width_and_height(string width, string height)
        {
            Insert_width(width);
            Insert_height(height);
            return this;
        }

        public Vartu_technika_page Check_automatika_check_box(bool should_be_checked)
        {
            if (should_be_checked != _auto_check_box.Selected)
                _auto_check_box.Click();
            return this;
        }
        public Vartu_technika_page Check_montavimo_darbai_check_box(bool should_be_checked)
        {
            if (should_be_checked != _montavimo_check_box.Selected)
                _montavimo_check_box.Click();
            return this;
        }

        public Vartu_technika_page Click_calcute_button()
        {
            _calculate_button.Click();
            return this;
        }

        private void Wait_for_result()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _result_box.Displayed);
        }

        public Vartu_technika_page Check_result(string expected_result)
        {
            Wait_for_result();
            Assert.IsTrue(_result_box.Text.Contains(expected_result), $"Result is not the same, expected {expected_result}, but was {_result_box.Text}");
            return this;
        }
    }
}

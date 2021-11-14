using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    class Drop_down : Base_page
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string Result_first_selected = "First selected option is : ";
        private const string Result_all_selected = "Options selected are : ";
        private IWebElement Result_element => Driver.FindElement(By.CssSelector(".getall-selected"));
        private IWebElement First_selected_button => Driver.FindElement(By.Id("printMe"));
        private IWebElement Get_all_selected_button => Driver.FindElement(By.Id("printAll"));
        private SelectElement Multi_drop_down => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        public Drop_down(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public Drop_down Click_first_selected_button()
        {
            First_selected_button.Click();
            return this;
        }
        public Drop_down Click_all_selected_button()
        {
            Get_all_selected_button.Click();
            return this;
        }
        public Drop_down Verify_result_first_selected(string first_value)
        {
            Assert.IsTrue(Result_element.Text.Equals(Result_first_selected + first_value), $"Result is wrong, not {first_value}");
            return this;
        }
        public Drop_down Verify_result_all_selected(string first_value, string second_value)
        {
            Assert.IsTrue(Result_element.Text.Equals(Result_all_selected + first_value + "," + second_value)
                , $"Result is wrong, not {first_value + ", " + second_value}");
            return this;
        }

        public Drop_down Select_from_multi_drop_down_by_value(string first_value, string second_value)
        {
            Actions action = new Actions(Driver);
            Multi_drop_down.SelectByValue(first_value);
            action.KeyDown(Keys.Control);
            Multi_drop_down.SelectByValue(second_value);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public Drop_down Select_from_multiple_drop_down_by_value(List<string> list_Of_states)
        {
            Multi_drop_down.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in list_Of_states)
            {
                foreach (IWebElement option in Multi_drop_down.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(First_selected_button);
            action.Build().Perform();
            return this;
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    public class Drop_down_page : Base_page
    {
        private const string Page_address = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string Result_text = "Day selected :- ";
        private SelectElement Drop_down => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement Result_text_element => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement First_selected_button => Driver.FindElement(By.Id("printMe"));
        private IWebElement Get_all_selected_button => Driver.FindElement(By.Id("printAll"));
        private SelectElement Multi_drop_down => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement Result_text_all_selected_element => Driver.FindElement(By.CssSelector(".getall-selected"));
        public Drop_down_page(IWebDriver webdriver) : base(webdriver)
        { }

        public Drop_down_page Navigate_to_default_page()
        {
            if (Driver.Url != Page_address)
                Driver.Url = Page_address;
            return this;
        }

        public Drop_down_page Select_from_drop_down_by_text(string text)
        {
            Drop_down.SelectByText(text);
            return this;
        }
        public Drop_down_page Select_from_drop_down_by_value(string text)
        {
            Drop_down.SelectByValue(text);
            return this;
        }
        public Drop_down_page Verify_result(string selected_day)
        {
            Assert.IsTrue(Result_text_element.Text.Equals(Result_text + selected_day), $"Result is wrong, not {selected_day}");
            return this;
        }
        public Drop_down_page Select_from_multiple_drop_down_and_click_first_button(List<string> list_of_states)
        {
            Multi_drop_down.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in list_of_states)
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
        public Drop_down_page Click_get_all_button()
        {
            Get_all_selected_button.Click();
            return this;
        }

        public Drop_down_page Check_listed_states(List<string> selected_elements)
        {
            string result = Result_text_all_selected_element.Text;
            foreach (string selectedElement in selected_elements)
            {
                Assert.True(result.Contains(selectedElement),
                    $"Should be {selectedElement}, but was {result}");
            }
            return this;
        }
        public Drop_down_page Check_first_state(string selected_element)
        {
            string result = Result_text_all_selected_element.Text;
            Assert.True(result.Contains(selected_element),
                $"{selected_element} is missing. {result}");
            return this;
        }

        public Drop_down_page Select_from_multiple_drop_down_by_value(List<string> list_of_states)
        {
            Multi_drop_down.DeselectAll();
            foreach (IWebElement option in Multi_drop_down.Options)
                if (list_of_states.Contains(option.GetAttribute("value")))
                {
                    Click_multiple_box(option);
                }
            return this;
        }
        private void Click_multiple_box(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.KeyDown(Keys.Control);
            actions.Click(element);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }
        public Drop_down_page Click_first_selected_button()
        {
            First_selected_button.Click();
            return this;
        }

        public Drop_down_page Click_all_selected_button()
        {
            Get_all_selected_button.Click();
            return this;
        }

    }
}

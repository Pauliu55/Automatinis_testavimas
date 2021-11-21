using Automatinis_Testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Automatinis_Testavimas.test
{
    public class Drop_down_test : Base_test
    {

        [Test]
        public void Test_drop_down()
        {
            _dropDownPage.Navigate_to_default_page()
                .Select_from_drop_down_by_text("Friday")
                .Verify_result("Friday");
        }

        [TestCase("Ohio", "Texas", TestName = "Pasirenkame 2 reiksmes ir patikriname")]
        [TestCase("Washington", "Ohio", "Texas", TestName = "Pasirenkame 3 reiksmes ir patikriname")]
        public void Test_multiple_drop_down(params string[] selected_elements)
        {
            _dropDownPage.Navigate_to_default_page()
                .Select_from_multiple_drop_down_and_click_first_button(selected_elements.ToList())
                .Check_first_state(selected_elements[0]);
        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname")]
        [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname")]
        public void Test_multiple_drop_down_get_all(params string[] selected_elements)
        {
            _dropDownPage.Navigate_to_default_page()
                .Select_from_multiple_drop_down_by_value(selected_elements.ToList())
                .Click_get_all_button();
        }
    }
}

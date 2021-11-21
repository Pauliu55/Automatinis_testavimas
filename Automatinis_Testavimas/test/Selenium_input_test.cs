using Automatinis_Testavimas.page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.test
{
    public class Selenium_input_test : Base_test
    {

        [Test]

        public void Test_selenium_input_first_block()
        {
            _selenium_input_page.Navigate_to_default_page()
                .Insert_text("Hi")
                .Click_show_message_button()
                .Check_result("Hi");
        }

        [TestCase("2", "2", "4", TestName = "2 plius 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plius 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a plius b = NaN")]
        public void Test_selenium_input_second_block(string first_input, string second_input, string result)
        {
            _selenium_input_page.Navigate_to_default_page()
                .Insert_boths_input(first_input, second_input)
            .Click_get_total_button()
            .Check_sum_result(result);
        }

    }
}

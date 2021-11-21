using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.page
{
    public class AlertTest : Base_test
    {
        [Test]
        public static void Test_alert()
        {
            _alert_page.Navigate_to_default_page().
                Click_alert_button().
                Accept_alert();
        }

        [Test]
        public static void TestConfirmationAlert()
        {
            _alert_page.Navigate_to_default_page().
                Click_confirmation_alert_button().
                Dismiss_confirmation_alert();
        }

        [Test]
        public static void TestPromptAlert()
        {
            _alert_page.Navigate_to_default_page()
                .Click_prompt_alert_button()
                .Insert_text_and_accept_prompt_alert("Penktadienis");
        }
    }
}
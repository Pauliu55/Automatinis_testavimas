using Automatinis_Testavimas.page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.test
{
    public class Vartu_technika_test : Base_test
    {

        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665.98€")]
        [TestCase("4000", "2000", true, true, "1006.43€", TestName = "4000 + 2000 + Vartu automatika + Vartu montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35€", TestName = "4000 + 2000 = 692.35€")]
        [TestCase("5000", "2000", false, true, "989.21€", TestName = "5000 + 2000 + Vartu montavimo darbai = 989.21€")]
        public void Test_vartu_technika(string width, string height, bool automatika, bool montavimo_darbai, string result)
        {

            _vartu_technika_page.Navigate_to_default_page().
                Insert_width_and_height(width, height)
                .Check_automatika_check_box(automatika)
                .Check_montavimo_darbai_check_box(montavimo_darbai)
            .Click_calcute_button()
            .Check_result(result);
        }
    }
}

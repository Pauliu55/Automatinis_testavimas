using Automatinis_Testavimas.page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.test
{
    public class Senukai_test : Base_test
    {
        [Test]
        public void TestSenukaiCookies()
        {
            _senukai_page.Navigate_to_default_page().
                Accept_cookie();
        }
    }
}

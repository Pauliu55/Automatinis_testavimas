using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Paskaitos_Darbai
{
    public class Class1
    {
        [Test]
        public static void Test_if_995_shares_from_3()
        {
            int leftover = 995 % 3;
            Assert.AreEqual(0, leftover, "995 are not sharring");
        }
    }
}

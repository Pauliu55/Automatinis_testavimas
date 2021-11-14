using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas
{
    class Class2
    {
        [Test]
        public static void Test_ar_dalijasi_is_3()
        {
            int dalmuo = 995 % 3;
            Assert.AreEqual(0, dalmuo, "995 nesidalija is 3");
        }

        [Test]
        public static void Test_if_today_is_monday()
        {
            DayOfWeek Today = DayOfWeek.Monday;
            Assert.IsTrue(DayOfWeek.Monday.Equals(Today), "Siandien ne pirmadienis");
        }
    }
}

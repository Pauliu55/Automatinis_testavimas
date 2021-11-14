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
    class Drop_down_test
    {
        private static Drop_down _page;

        [OneTimeSetUp]
        public static void Set_up()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new Drop_down(driver);
        }

        [OneTimeTearDown]

        public static void Tear_down()
        {
            //_page.Close_browser();
        }

        [Test]
        public void Test_multi_drop_down_first_selected_2_states()
        {
            _page.Select_from_multi_drop_down_by_value("Florida", "Texas")
                .Click_first_selected_button()
                .Verify_result_first_selected("Florida");
        }

        [Test]
        public void Test_multi_drop_down_all_selected_2_states()
        {
            _page.Select_from_multi_drop_down_by_value("Florida", "Texas")
                .Click_all_selected_button()
                .Verify_result_all_selected("Florida", "Texas");
        }

        public void Test_multi_drop_down_list()
        {

        }
    }
}

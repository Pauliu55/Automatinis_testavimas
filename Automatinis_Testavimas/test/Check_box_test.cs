using Automatinis_Testavimas.page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Automatinis_Testavimas.test
{
    public class Check_box_test : Base_test
    {


        [Order(3)]
        [Test]
        public void TestSingleCheckBox()
        {
            _check_box_demo_page.NavigateToDefaultPage()
                .CheckSingleCheckbox()
                .CheckResult();
        }
        [Order(1)]
        [Test]
        public void TestCheckAllCheckboxes()
        {
            _check_box_demo_page.NavigateToDefaultPage()
                .CheckAllCheckboxes()
                .CheckButtonValue("Uncheck All");
        }
        [Order(2)]
        [Test]
        public void TestUncheckAllCheckboxes()
        {
            _check_box_demo_page.NavigateToDefaultPage()
                .CheckAllCheckboxes()
                .ClickButton()
                .VerifyThatAllCheckboxesAreUnchecked();
        }
    }
}
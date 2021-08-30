using AutomationNEW.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationNEW.Test
{
    public class DropDownTest

    {
        private static DropdownPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new DropdownPage(chrome);
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            page.NavigateToPage();
            page.AcceptCookies();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("Volvo", "Audi", TestName = "Test list with Volvo, Audi values")]
        [TestCase("Audi", "Saab", TestName = "Test list with Audi, Saab values")]
        [TestCase("Audi", "Volvo", "Opel", TestName = "Test list with Audi, Volvo, Opel values")]
        public static void TestDropdown(params string[] cars)
        {

            List<string> carsList = cars.ToList();
            page.SelectFromDropdownByValue(carsList);
            page.SubmitButton();
            page.VerifyResultBySelectedOption(carsList);
            page.SelectRunButton();
        }
    }
}

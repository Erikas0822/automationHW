using AutomatinisReal.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomatinisReal.Test
{
    class SumHwTest
    {
        private static SumHwPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new SumHwPage(chrome);

            chrome.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            page.AcceptCookies();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("2", "2", "4", TestName = "2 plus 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plus 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a plus b = NaN")]
        public static void TestSumCalculation(string firstInput, string secondInput, string result)
        {
            page.FirstInputField(firstInput);
            page.SecondInputField(secondInput);
            page.GetTotal(result);
            page.VerifyResult(result);
        }
    }
}

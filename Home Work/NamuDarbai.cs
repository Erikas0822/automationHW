using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisReal
{
    class NamuDarbai
    {
        [Test]
        public static void TestTwoInputFields()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click();

            string num1 = "2";
            string num2 = "2";

            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));

            inputField1.SendKeys(num1);
            inputField2.SendKeys(num2);

            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();

            IWebElement resultElement = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("4", resultElement.Text, "Text was wrong");
        }

        [Test]
        public static void TestTwoInputs()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click();

            string num1 = "-5";
            string num2 = "3";

            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));

            inputField1.SendKeys(num1);
            inputField2.SendKeys(num2);

            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();

            IWebElement resultElement = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", resultElement.Text, "Text was wrong");
        }
        [Test]
        public static void TestTwoInputsLetters()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click();

            string num1 = "a";
            string num2 = "b";

            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));

            inputField1.SendKeys(num1);
            inputField2.SendKeys(num2);

            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();

            IWebElement resultElement = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", resultElement.Text, "Text was wrong");
        }


        private static IWebDriver chrome;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            chrome = new ChromeDriver();
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";

        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            chrome.Quit();
        }

        [Test]

        public static void checkWebPage()
        {
            string resultText = chrome.FindElement(By.Id("primary-detection")).Text;
            string result = "Chrome 92";


            Assert.IsTrue(resultText.Contains(result), "Result is wrong");



        }
    }
}


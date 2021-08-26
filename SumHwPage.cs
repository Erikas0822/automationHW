using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomatinisReal.Page
{
    class SumHwPage : BasePage
    {
        private IWebElement firstInputField => Driver.FindElement(By.Id("sum1"));
        private IWebElement secondInputField => Driver.FindElement(By.Id("sum2"));

        private IWebElement getTotalButton => Driver.FindElement(By.CssSelector("#gettotal > button"));

        private IWebElement resultFromPage => Driver.FindElement(By.Id("displayvalue"));

        private IWebElement acceptCookiesButon => Driver.FindElement(By.Id("at-cv-lightbox-close"));

        public SumHwPage(IWebDriver webdriver) : base(webdriver) { }

        public void FirstInputField(string firstInput)
        {
            firstInputField.Clear();
            firstInputField.SendKeys(firstInput);
        }
        public void AcceptCookies()
        {
            acceptCookiesButon.Click();
        }
        public void SecondInputField(string secondInput)
        {
            secondInputField.Clear();
            secondInputField.SendKeys(secondInput);
        }

        public void GetTotal(string total)
        {
            getTotalButton.Click();
        }

        public void VerifyResult(string result)
        {
            Assert.AreEqual(result, resultFromPage.Text, $"Actual result differs from expected {result}");
        }

    }
}

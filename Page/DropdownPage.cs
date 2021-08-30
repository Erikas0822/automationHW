using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace AutomationNEW.Page
{
    class DropdownPage : BasePage
    {
        private const string AddressUrl = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select_multiple";
        private SelectElement carList => new SelectElement(Driver.FindElement(By.CssSelector("#cars")));
        private IWebElement runButton => Driver.FindElement(By.Id("runbtn"));
        private IWebElement resultButton => Driver.FindElement(By.CssSelector("body > form > input[type=submit]"));
        private IWebElement resultElement => Driver.FindElement(By.CssSelector("body > div.w3-container.w3-large.w3-border"));
        private IWebElement acceptCookiesButon => Driver.FindElement(By.Id("accept-choices"));

        public DropdownPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        public void AcceptCookies()
        {
            acceptCookiesButon.Click();
        }
        public void SubmitButton()
        {
            resultButton.Click();
        }

        public void VerifyResultBySelectedOption(List<string> cars)
        {
            foreach (string car in cars)
            {
                Assert.IsTrue(resultElement.Text.Contains(car.ToLower()),
                    $"Result is not present, was {resultElement.Text}, but expected {car} ");
            }
        }
        public void SelectFromDropdownByValue(List<string> cars)
        {
            Driver.SwitchTo().Frame("iframeResult");
            carList.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (IWebElement option in carList.Options)
                {
                   if (cars.Contains(option.Text) && !option.Selected)
                   {
                     option.Click();
                   }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
        }
        public void SelectRunButton()
        {
            Driver.SwitchTo().DefaultContent();
            runButton.Click();
        }
    }
}


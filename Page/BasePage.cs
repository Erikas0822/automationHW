using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomatinisReal.Page
{
    public class BasePage
    {
            public IWebDriver Driver;
            public BasePage(IWebDriver webdriver)
            {
                Driver = webdriver;
            }

            public void CloseBrowser()
            {
                Driver.Quit();
            }
        public WebDriverWait GetWait(int seconds = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }
    }
}

using OpenQA.Selenium;


namespace AutomatinisReal.Page
{
    class BasePage
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
    }
}

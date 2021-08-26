using OpenQA.Selenium;


namespace AutomatinisReal.Page
{
    class BasePage
    {
            protected IWebDriver Driver;
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

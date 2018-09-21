using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestTaskForTheXrm.Base
{
    class Browser
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver => _driver ?? (_driver = new ChromeDriver());

        public static void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;

namespace TestTaskForTheXrm.Base.Controls
{
    public class DropdownMenu
    {
        private readonly string _dropdownXPath;
        private readonly IWebElement _button;

        public DropdownMenu(string buttonXPath, string dropdownXPath)
        {
            _button = Browser.Driver.FindElement(By.XPath(buttonXPath));
            _dropdownXPath = dropdownXPath;
        }

        private IWebElement Dropdown => Browser.Driver.FindElement(By.XPath(_dropdownXPath));
        
        private void Open()
        {
            _button.Click();
            Assert.IsTrue(Dropdown.Displayed, "Dropdown is not displayed");
        }
        
        public void SelectItemByName(string itemName)
        {
            Waiter.Wait(() => Open(), "The Dropdown Menu is not opened");
            IWebElement item = Dropdown.FindElement(By.XPath($"//div[contains(@class, 'item') and . = '{itemName}']"));
            Waiter.Wait(() => Assert.IsTrue(item.Enabled, $"item with name {itemName} is not enabled"));
            item.Click();
        }
    }
}

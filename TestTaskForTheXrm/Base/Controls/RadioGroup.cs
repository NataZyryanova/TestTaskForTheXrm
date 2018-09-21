using NUnit.Framework;
using OpenQA.Selenium;

namespace TestTaskForTheXrm.Base.Controls
{
    public class RadioGroup
    {
        private readonly IWebElement _radioGroup;

        public RadioGroup(string radioGroupXPath)
        {
            _radioGroup = Browser.Driver.FindElement(By.XPath(radioGroupXPath));
        }

        public void CheckedItemByName(string itemName)
        {
            IWebElement item = _radioGroup.FindElement(By.XPath($"//label[. = '{itemName}']"));
            Waiter.Wait(() => Assert.IsTrue(item.Enabled, $"item with name {itemName} is not enabled"));
            Waiter.Wait(() =>
            {
                item.Click();
                Assert.IsTrue(item.GetAttribute("Class").Contains("_checked"));
            });
        }
    }
}

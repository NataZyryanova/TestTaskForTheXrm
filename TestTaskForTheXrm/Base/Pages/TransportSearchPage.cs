using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestTaskForTheXrm.Base.Controls;

namespace TestTaskForTheXrm.Base.Pages
{
    class TransportSearchPage:PageBase
    {
        private const string Title = "Екатеринбург. Расписание самолётов, поездов, электричек и автобусов";

        private IWebElement Logo => Driver.FindElement(By.ClassName("yandex-logo"));
        private RadioGroup TransportRadioGroup => new RadioGroup("*//div[@class = 'header__transport-selector']//span[contains(@class, 'radio-group')]");
        private IWebElement FromInput => Browser.Driver.FindElement(By.XPath("*//div[@class = 'search-form__from']//input[@name = 'fromName']"));
        private IWebElement ToInput => Browser.Driver.FindElement(By.XPath("*//div[@class = 'search-form__to']//input[@name = 'toName']"));
        private IWebElement WhenInput => Browser.Driver.FindElement(By.XPath("*//div[@class = 'datepicker_search__from']//input[contains(@id, 'uniqs')]"));
        private IWebElement SearchButton => Browser.Driver.FindElement(By.XPath("*//*[@class = 'page__header']//div[@class = 'search-form__submit']"));
        
        public override void BrowseWaitVisible()
        {
            Waiter.Wait(() => Assert.IsTrue(Logo.Displayed, "Logo is not Displayed"));
            Waiter.Wait(() => Assert.IsTrue(Driver.Title.Contains(Title), $"Title do not Contains: {Title}"));
        }

        public void TransportSearch(string typeOfTransport, string from, string to, DateTime date)
        {
            TransportRadioGroup.CheckedItemByName(typeOfTransport);
            FromInput.Clear();
            FromInput.SendKeys(from);
            ToInput.SendKeys(to);
            WhenInput.SendKeys(date.ToString("dd.MM.yyyy"));
            SearchButton.Click();
        }
    }
}

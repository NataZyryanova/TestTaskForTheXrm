using NUnit.Framework;
using OpenQA.Selenium;
using TestTaskForTheXrm.Base.Controls;

namespace TestTaskForTheXrm.Base.Pages
{
    public class StartPage : PageBase
    {
        public const string Path = "https://yandex.ru/";
        private string Title = "Яндекс";

        public IWebElement Logo => Driver.FindElement(By.ClassName("home-logo"));
        public IWebElement TopMenu => Driver.FindElement(By.ClassName("home-arrow__tabs"));
        public DropdownMenu MoreAction => new DropdownMenu("*//a[contains(@class,'home-tabs__more-switcher')]", "*//div[@class = 'home-tabs__more']");

        public override void BrowseWaitVisible()
        {
            Waiter.Wait(() => Assert.IsTrue(Logo.Displayed, "Logo is not Displayed"));
            Waiter.Wait(() => Assert.IsTrue(Driver.Title.Contains(Title), $"Title do not Contains: {Title}"));
            Waiter.Wait(() => Assert.IsTrue(TopMenu.Enabled, "Top Menu is Disable"));
        }
    }
}

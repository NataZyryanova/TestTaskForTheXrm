using System;
using OpenQA.Selenium;

namespace TestTaskForTheXrm.Base.Pages
{
    public abstract class PageBase
    {
        public IWebDriver Driver { get; } = Browser.Driver;

        public abstract void BrowseWaitVisible();

        public TPage ChangePageType<TPage>() where TPage : PageBase, new()
        {
            var instance = Activator.CreateInstance<TPage>();
            instance.BrowseWaitVisible();
            return instance;
        }
    }
}

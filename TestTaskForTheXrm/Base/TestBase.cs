using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TestTaskForTheXrm.Base.Pages;

namespace TestTaskForTheXrm.Base
{
    [TestFixture]
    public abstract class TestBase
    {
        public IWebDriver Driver => Browser.Driver;

        [SetUp]
        public virtual void SetUp()
        {
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void EndTest()
        {
           Browser.CloseDriver();
        }

        public TPage LoadPage<TPage>(string path) where TPage : PageBase, new()
        {
            Driver.Url = path;
            var instance = Activator.CreateInstance<TPage>();
            instance.BrowseWaitVisible();
            return instance;
        }
    }
}

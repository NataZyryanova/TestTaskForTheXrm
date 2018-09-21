using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestTaskForTheXrm.Base.Pages
{
    public class DetailedInformationAboutTransportPage:PageBase
    {
        private IWebElement Logo => Driver.FindElement(By.ClassName("b-head-logo__logo"));
        private IWebElement Header => Driver.FindElement(By.ClassName("b-page-title__title"));
        private IWebElement StartTime => Browser.Driver.FindElement(By.XPath("*//tr[contains(@class, 'start')]//td[contains(@class, 'type_departure')]//strong"));
        private IWebElement EndTime => Browser.Driver.FindElement(By.XPath("*//tr[contains(@class, 'end')]//td[contains(@class, 'type_arrival')]"));
        private IWebElement TravelTime => Browser.Driver.FindElement(By.XPath("*//tr[contains(@class, 'end')]//td[contains(@class, 'type_time')]"));

        public override void BrowseWaitVisible()
        {
            Waiter.Wait(() => Assert.IsTrue(Logo.Displayed));
        }

        public TransportInfo CreateTransportInfo()
        {
            string pattern = @".+ (\d{4}), (.+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(Header.Text);

            return new TransportInfo
            {
                Number = match.Groups[1].Value,
                Name = match.Groups[2].Value,
                StartTime = StartTime.Text,
                EndTime = EndTime.Text,
                TravelTime = TravelTime.Text
            };
        }
    }
}

using OpenQA.Selenium;
using TestTaskForTheXrm.Base.Pages;

namespace TestTaskForTheXrm.Base.Controls
{
    public class SearchResultLine
    {
        private const string NumberXPath = "//span[@class = 'SegmentTitle__number']";
        private const string NameXPath = "//span[@class = 'SegmentTitle__title']";
        private const string StartTimeXPath = "//div[@class = 'SearchSegment__dateTime Time_important']/span";
        private const string EndTimeXPath = "//div[@class = 'SearchSegment__dateTime']/span";
        private const string TravelTimeXPath = "//div[@class = 'SearchSegment__duration']";
        private const string PriceTimeXPath = "//span[@class = 'Price SuburbanTariffs__buttonPrice']";
        private readonly string _searchResultLineXPath;

        public SearchResultLine(string searchResultLineXPath)
        {
            _searchResultLineXPath = searchResultLineXPath;
        }

        private IWebElement Number => Browser.Driver.FindElement(By.XPath($"{_searchResultLineXPath}{NumberXPath}"));
        public IWebElement Name => Browser.Driver.FindElement(By.XPath($"{_searchResultLineXPath}{NameXPath}"));
        public IWebElement StartTime => Browser.Driver.FindElement(By.XPath($"{_searchResultLineXPath}{StartTimeXPath}"));
        private IWebElement EndTime => Browser.Driver.FindElement(By.XPath($"{_searchResultLineXPath}{EndTimeXPath}"));
        private IWebElement TravelTime => Browser.Driver.FindElement(By.XPath($"{_searchResultLineXPath}{TravelTimeXPath}"));
        public IWebElement Price => Browser.Driver.FindElement(By.XPath($"{_searchResultLineXPath}{PriceTimeXPath}"));

        public TransportInfo CreateTransportInfo()
        {
            return new TransportInfo
            {
                Number = Number.Text,
                Name = Name.Text,
                StartTime = StartTime.Text,
                EndTime = EndTime.Text,
                TravelTime = TravelTime.Text
            };
        }
    }
}

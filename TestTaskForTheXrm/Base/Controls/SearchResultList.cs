using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestTaskForTheXrm.Base.Controls
{
    public class SearchResultList
    {
        private readonly string _xpath;

        public SearchResultList(string xPath)
        {
            _xpath = xPath;
        }

        private ReadOnlyCollection<IWebElement> ListSearchResult => Browser.Driver.FindElements(By.XPath(_xpath));
        private int CountSearchResult => ListSearchResult.Count;

        public SearchResultLine GetSearchResultByPriceAndTime(decimal price, int hour)
        {
            for (int i = 1; i<=CountSearchResult; i++)
            {
                var searchResult = new SearchResultLine($"{_xpath}[{i}]");
                decimal searchResultPrice = Convert.ToDecimal(searchResult.Price.Text.TrimEnd(" Р".ToCharArray()));
                TimeSpan searchResultTime = new TimeSpan(Convert.ToInt16(searchResult.StartTime.Text.Substring(0, 2)), 0, 0);
                TimeSpan hourTimeSpan = new TimeSpan(hour, 0, 0);
                if (searchResultPrice < price && searchResultTime >= hourTimeSpan)
                {
                    return searchResult;
                }
            }

            throw new AssertionException($"Нет рейсов дешевле {price} рублей и позднее {hour} часов");
        }
    }
}

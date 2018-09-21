using System;
using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using TestTaskForTheXrm.Base.Controls;

namespace TestTaskForTheXrm.Base.Pages
{
    public class TransportSearchResultsPage:PageBase
    {
        private const string Title = "— Яндекс.Расписания";

        private IWebElement Logo => Driver.FindElement(By.ClassName("YaLogo"));
        private IWebElement Header => Driver.FindElement(By.ClassName("SearchTitle"));
        public SearchResultList ListSearchResult => new SearchResultList("*//section[@class = 'SearchSegments']/article");
        private DropdownMenu CurrencySelect => new DropdownMenu("*//div[@class = 'Select CurrencySelect']/button", "*//div[@class = 'Popup__content']");
        
        public override void BrowseWaitVisible()
        {
            Waiter.Wait(() => Assert.IsTrue(Logo.Displayed, "Logo is not Displayed"));
            Waiter.Wait(() => Assert.IsTrue(Driver.Title.Contains(Title), $"Title do not Contains: {Title}"));
        }

        public void СheckHeader(string from, string to, DateTime date)
        {
            Waiter.Wait(() =>
            {
                Assert.IsTrue(Header.Text.Contains($"Расписание электричек из {from}"));
                Assert.IsTrue(Header.Text.Contains($"в {to}"));
                Assert.IsTrue(Header.Text.Contains($"{date.ToString("dd MMMM, dddd", new CultureInfo("Ru"))}"));
            });
        }

        public void PrintShortInfo(SearchResultLine selectedLine)
        {
            var startTime = selectedLine.StartTime.Text;
            var priceRu = selectedLine.Price.Text;
            CurrencySelect.SelectItemByName("$ доллары");
            var priseEn = selectedLine.Price.Text;
            Console.Write($"Данные о рейсе:\n" +
                          $"Время отправления - {startTime}\n" +
                          $"Цена в рублях - {priceRu}\n" +
                          $"Цена в долларах - {priseEn}");
        }
    }
 }


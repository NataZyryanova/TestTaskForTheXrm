using System;
using NUnit.Framework;
using TestTaskForTheXrm.Base;
using TestTaskForTheXrm.Base.Pages;

namespace TestTaskForTheXrm.Tests
{
    class YandexScheduleOfTrainsTest:TestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            _startPage = LoadPage<StartPage>(StartPage.Path);
        }

        private StartPage _startPage;

        [Test]
        public void Test()
        {
            #region SearchCondition

            string typeOfTransport = "Электричка";
            string from = "Екатеринбург";
            string to = "Каменск-Уральский";
            DateTime date = FindDateByDayOfWeek(DayOfWeek.Saturday);
            decimal maxPrice = 200;
            int minStartHour = 12;

            #endregion

            var menuItemName = "Расписания";
            _startPage.MoreAction.SelectItemByName(menuItemName);
            var schedulePage = _startPage.ChangePageType<TransportSearchPage>();
            schedulePage.TransportSearch(typeOfTransport, from, to, date);
            var searchResultPage = schedulePage.ChangePageType<TransportSearchResultsPage>();
            searchResultPage.СheckHeader(from, to, date);
            var selectedTransport = searchResultPage.ListSearchResult.GetSearchResultByPriceAndTime(maxPrice, minStartHour);
            var infoFromTheSearchResultPage = selectedTransport.CreateTransportInfo();
            searchResultPage.PrintShortInfo(selectedTransport);
            selectedTransport.Name.Click();
            var detailPage = searchResultPage.ChangePageType<DetailedInformationAboutTransportPage>();
            var detailTransportInfo = detailPage.CreateTransportInfo();

            Assert.That(detailTransportInfo.Number, Is.EqualTo(infoFromTheSearchResultPage.Number));
            Assert.That(detailTransportInfo.Name, Is.EqualTo(infoFromTheSearchResultPage.Name));
            Assert.That(detailTransportInfo.StartTime, Is.EqualTo(infoFromTheSearchResultPage.StartTime));
            Assert.That(detailTransportInfo.EndTime, Is.EqualTo(infoFromTheSearchResultPage.EndTime));
            Assert.That(detailTransportInfo.TravelTime, Is.EqualTo(infoFromTheSearchResultPage.TravelTime));
        }

        static DateTime FindDateByDayOfWeek(DayOfWeek dayOfWeek)
        {
            DateTime date = DateTime.Today;
            return date.AddDays(Math.Abs(dayOfWeek - date.DayOfWeek));
        }
    }
}

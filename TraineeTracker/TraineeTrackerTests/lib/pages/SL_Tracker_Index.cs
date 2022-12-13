﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib.pages
{
    public class SL_Tracker_Index
    {
        private IWebDriver SeleniumDriver { get; }
        private IWebElement GetCreateBtn => SeleniumDriver.FindElement(By.Id("create_btn"));
        private IWebElement GetBackBtn => SeleniumDriver.FindElement(By.Id("back_btn"));
        private ReadOnlyCollection<IWebElement> GetDetailsBtns => SeleniumDriver.FindElements(By.Id("details_btn"));
        private ReadOnlyCollection<IWebElement> GetDeleteBtns => SeleniumDriver.FindElements(By.Id("delete_btn"));
        private IWebElement GetPieChartElement1 => SeleniumDriver.FindElement(By.Id("piechart"));
        private IWebElement GetPieChartElement2 => SeleniumDriver.FindElement(By.Id("piechart_two"));

        private string _indexUrl = AppConfigReader.TrackerIndexUrl;

        public SL_Tracker_Index(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitIndexPage(int id) => SeleniumDriver.Navigate().GoToUrl($@"{_indexUrl}/{id}");
        public void ClickCreateButton() => GetCreateBtn.Click();
        public void ClickBackButton() => GetBackBtn.Click();
        public void ClickDetailsButton(int index) => GetDetailsBtns[index].Click();
        public void ClickDeleteButton(int index) => GetDeleteBtns[index].Click();
    }
}

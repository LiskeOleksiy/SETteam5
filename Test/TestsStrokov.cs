﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using AutomationTest.Framework;
using AutomationTest.PageObject;
using NUnit.Framework;

namespace AutomationTest.Test
{
    [TestFixture]
    public class Test
    {
        private static readonly TimeSpan ImplicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32("3000"));
        private  IWebDriver _driver;
        private  MainPage _mainPage;
        private void DriverSettings()
        {
            _driver = new ChromeDriver(Directory.GetCurrentDirectory());
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            _driver.Navigate().GoToUrl(Settings.HomeUrl);
            _mainPage = new MainPage(_driver);
        }
        [TearDown]
        public void OneTimeTearDown() => _driver.Quit();

        [TestCase("SortHighToLow")] 
        [TestCase("SortLowToHigh")] 
        [TestCase("SortZToA")] 
        [TestCase("SortAToZ")] 
        public void SortValidation(string sortType)
        {
            DriverSettings();
            Accessories newAccessories = _mainPage.Accessories;
            Currency newCurrency = _mainPage.CreateCurrency();
            newAccessories.ChooseAccessories();
            newCurrency
                .OpenCurrencyDropdown()
                .ChooseCurrency("$");
            bool validSort = newAccessories.ClickSort()
                                           .Sort(sortType)
                                           .IsSortValid();
            Assert.That(validSort);
        }
        [TestCase("₴")] 
        [TestCase("$")] 
        [TestCase("€")] 
        public void CurrencyValidation(string currency)
        {
            DriverSettings();
            Currency newCurrency = _mainPage.CreateCurrency();
            bool validCurrency = newCurrency
                .OpenCurrencyDropdown()
                .ChooseCurrency(currency)
                .IsCurrencyOk(currency);
            Assert.That(validCurrency);
        }
        [TestCase("set@selenium.tester","")]
        [TestCase("set@selenium","")]
        [TestCase("","message text")]
        public void SubmitContactValidation(string email, string message)
        {
            DriverSettings();
            Contact newContact = _mainPage.OpenContactPage();
            bool isMessageOk = newContact
                .EnterData(email, message)
                .SubmitNewMessage()
                .IsDataOk();
            Assert.That(isMessageOk);
        }

    }
}
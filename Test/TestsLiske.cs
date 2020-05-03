using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
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

        [TestCase("SortHighToLow", "Clothes")] 
        [TestCase("SortLowToHigh", "Clothes")] 
        [TestCase("SortAToZ", "Clothes")] 
        [TestCase("SortZToA", "Clothes")] 
        
        [TestCase("SortHighToLow", "Accessories")] 
        [TestCase("SortLowToHigh", "Accessories")] 
        [TestCase("SortAToZ", "Accessories")] 
        [TestCase("SortZToA", "Accessories")]
        
        [TestCase("SortHighToLow", "Art")] 
        [TestCase("SortLowToHigh", "Art")] 
        [TestCase("SortAToZ", "Art")] 
        [TestCase("SortZToA", "Art")]
        
        [TestCase("SortHighToLow", "AllProducts")] 
        [TestCase("SortLowToHigh", "AllProducts")] 
        [TestCase("SortAToZ", "AllProducts")] 
        [TestCase("SortZToA", "AllProducts")]
        
        public void SortValidation(string sortType, string storeDept)
        {
            DriverSettings();
            Store newStore = _mainPage.CreateStore();
            Currency newCurrency = _mainPage.CreateCurrency();
            newStore.OpenStore(storeDept);
            newCurrency
                .ChooseCurrency('$');
            bool validSort = newStore.ClickSort()
                .Sort(sortType)
                .IsSortValid();
            Assert.That(validSort);
        }
        [TestCase('$', "Clothes")] 
        [TestCase('€', "Clothes")] 
        [TestCase('₴', "Clothes")] 
        
        [TestCase('$', "Accessories")] 
        [TestCase('€', "Accessories")] 
        [TestCase('₴', "Accessories")] 
        
        [TestCase('$', "Art")] 
        [TestCase('€', "Art")] 
        [TestCase('₴', "Art")] 
        
        [TestCase('$', "AllProducts")] 
        [TestCase('€', "AllProducts")] 
        [TestCase('₴', "AllProducts")] 
        public void CurrencyValidation(char currency, string storeDept)
        {
            DriverSettings();
            Store newStore = _mainPage.CreateStore();
            Currency newCurrency = _mainPage.CreateCurrency();
            newStore.OpenStore(storeDept);
            newCurrency.ChooseCurrency(currency);
            _driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            bool validCurrency = newCurrency.IsCurrencyOk(currency);
            Assert.That(validCurrency);
        }
        [TestCase("set@selenium.test","")]
        [TestCase("set@selenium","")]
        [TestCase("","message text")]
        [TestCase("","")]
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
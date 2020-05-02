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
        private double _sum;
        private void DriverSettings()
        {
            _driver = new ChromeDriver(Directory.GetCurrentDirectory());
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            _driver.Navigate().GoToUrl(Settings.Url);
            _mainPage = new MainPage(_driver);
        }
        [TearDown]
        public void OneTimeTearDown() => _driver.Quit();
        [Test] 
        public void Test1()
        {
            DriverSettings();
            User user = _mainPage.OpenLoginPage();
            user.LoginUser().OpenMainPage().SearchWord("Hummingbird");
        }
        [Test] 
        public void Test2()
        {
            DriverSettings();
            User user = _mainPage.OpenLoginPage();
            user.LoginUser().OpenMainPage().SearchWord("Hummingbird");
            Thread.Sleep(4000);
        }
        [TestCase("set@selenium.test","")]
        [TestCase("set@selenium","")]
        [TestCase("","message text")]
        public void SubmitContactValidation(string email, string message)
        {
            DriverSettings();
            Contact contact = _mainPage.OpenContactPage();
            bool isMessageOk = contact.EnterData(email, message).SubmitNewsletter().IsDataOk();
            Assert.That(isMessageOk, Is.EqualTo(true));
        }
    }
}
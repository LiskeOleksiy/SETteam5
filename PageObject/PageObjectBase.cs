using AutomationTest.Framework;
using OpenQA.Selenium;
namespace AutomationTest.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        protected PageObjectBase(IWebDriver driver) => Driver = driver;
        
        protected void InputData(By byType, string data)
        {
            Driver.FindElement(byType).SendKeys(data);
        }
        protected void InputData(By byType)
        {
            Driver.FindElement(byType).Click();
        }
        protected IWebElement FindData(By byType)
        {
            IWebElement parseText = Driver.FindElement(byType);
            return parseText;
        }
        public User OpenMainPage(User obj)
        {
            Driver.Navigate().GoToUrl(Settings.HomeUrl);
            return obj;
        }
    }
}
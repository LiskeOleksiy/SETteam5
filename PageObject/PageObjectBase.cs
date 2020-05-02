using AutomationTest.Framework;
using OpenQA.Selenium;
namespace AutomationTest.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        protected PageObjectBase(IWebDriver driver) => Driver = driver;
        
        public void InputData(By byType, string data)
        {
            Driver.FindElement(byType).SendKeys(data);
        }
        public void InputData(By byType)
        {
            Driver.FindElement(byType).Click();
        }
        public User OpenMainPage(User obj)
        {
            Driver.Navigate().GoToUrl(Settings.Url);
            return obj;
        }
    }
}
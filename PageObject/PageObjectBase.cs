using OpenQA.Selenium;
namespace AutomationTest.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        protected PageObjectBase(IWebDriver driver) => Driver = driver;
    }
}
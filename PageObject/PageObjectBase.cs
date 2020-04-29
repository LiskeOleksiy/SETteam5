using OpenQA.Selenium;
namespace Selenium1.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        public PageObjectBase(IWebDriver driver) => Driver = driver;
    }
}
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Clothes : PageObjectBase
    {
        private static readonly By ChooseClothesButton =
            By.XPath("//*[@id='content']/section/div/article[1]/div/a/img");
        public Clothes(IWebDriver driver) : base(driver)
                {
                }
         public Clothes ChooseClothes()
         {
             InputData(ChooseClothesButton);
             return this;
         }
    }
}
using System;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Currency : PageObjectBase
    {
        private static readonly By ChooseCurrencyButton =
            By.XPath("//*[@id='_desktop_currency_selector']/div/button/span");
        private static readonly By ChooseUsdButton =
            By.XPath("//*[@id='_desktop_currency_selector']/div/ul/li[3]/a");
        private static readonly By ChooseEurButton =
            By.XPath("//*[@id='_desktop_currency_selector']/div/ul/li[1]/a");
        private static readonly By ChooseUahButton =
            By.XPath("//*[@id='_desktop_currency_selector']/div/ul/li[2]/a");
        //*[@id="content"]/section/div/article[1]/div/div[1]/div/span[5]
        public Currency(IWebDriver driver) : base(driver)
        {
        }
        public Currency ChooseCurrencyDropdown()
        {
            InputData(ChooseCurrencyButton);
            return this;
        }
        public Currency ChooseCurrency (string currency)
        {
            switch (currency)
            {
                case "$":
                    InputData(ChooseUsdButton);
                    break;
                case "€":
                    InputData(ChooseEurButton);
                    break;
                case "₴":
                    InputData(ChooseUahButton);
                    break;
                default:
                    Console.WriteLine("Wrong currency");
                    break;
            }
            return this;
        }

    }
}
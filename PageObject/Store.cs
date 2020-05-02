using System;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Store : PageObjectBase
    {
        private double FirstPrice { get; set; }
        private double SecondPrice { get; set; }
        private bool check = false;
        
        private static readonly By OpenStoreButton = By.XPath("//*[@id='content']/section/a");
        private static readonly By SortButton = By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/button");
        private static readonly By LowToHighButton =
            By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[4]");
        private static readonly By HighToLowButton =
            By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[5]");
        private static readonly By AToZButton =
            By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[2]");
        private static readonly By ZToAButton =
            By.XPath("//*[@id='js-product-list-top']/div[2]/div/div[1]/div/a[3]");
        private static readonly By ParseFirstPrice =
            By.XPath("//*[@id='js-product-list']/div[1]/article[1]/div/div[1]/div/span[2]");

        private static readonly By ParseSecondPrice =
            By.XPath("//*[@id='js-product-list']/div[1]/article[2]/div/div[1]/div/span[2]");

        private static readonly By ParseFirstText =
            By.XPath("//*[@id='js-product-list']/div[1]/article[1]/div/div[1]/h2/a");
        private static readonly By ParseSecondText =
            By.XPath("//*[@id='js-product-list']/div[1]/article[2]/div/div[1]/h2/a");
        private string sortType2;
        public Store(IWebDriver driver) : base(driver)
        {
        }
        public Store OpenStore()
        {
            InputData(OpenStoreButton);
            return this;
        }
        public Store ClickSort()
        {
            InputData(SortButton);
            return this;
        }
        public Store Sort(string sortType)
        {
            sortType2 = sortType;
            switch (sortType)
            {
                case "SortLowToHigh":
                    InputData(LowToHighButton);
                    break;
                case "SortHighToLow":
                    InputData(HighToLowButton);
                    break;
                case "SortAToZ":
                    InputData(AToZButton);
                    break;
                case "SortZToA":
                    InputData(ZToAButton);
                    break;
                default:
                    Console.WriteLine("Wrong sorting type");
                    break;
            }
            Thread.Sleep(2000);
            return this;
        }
        public bool IsSortValid()
        {
            IWebElement firstPriceText = FindData(ParseFirstPrice);
            double firstPrice = Convert.ToDouble(firstPriceText.Text.Trim('$'), CultureInfo.InvariantCulture);
            FirstPrice = firstPrice;
            IWebElement secondPriceText = FindData(ParseSecondPrice);
                double secondPrice = Convert.ToDouble(secondPriceText.Text.Trim('$'), CultureInfo.InvariantCulture);
            SecondPrice = secondPrice;
            IWebElement firstText = FindData(ParseFirstText);
            IWebElement secondText = FindData(ParseSecondText);
            int compareItem = String.Compare(firstText.Text, secondText.Text);
            switch (sortType2)
            {
                case "SortLowToHigh":
                    check = FirstPrice <= SecondPrice;
                    break;
                case "SortHighToLow":
                    check = FirstPrice >= SecondPrice;
                    break;
                case "SortAToZ":
                    if (compareItem <= 0)
                        check = true;
                    break;
                case "SortZToA":
                    if (compareItem >= 0)
                        check = true;
                    break;
                    
                default:
                    Console.WriteLine("Wrong sorting type");
                    break;
            }
            return check;
        }
    }
}
using System;
using NUnit.Framework;

namespace Selenium1.Framework
{
    public static class Settings
    {
        public static readonly string Url = "https://www.prestashop.com/en";
        public static readonly TimeSpan ImplicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32("3000"));
    }

}
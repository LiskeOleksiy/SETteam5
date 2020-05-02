using System;

namespace AutomationTest.Framework
{
    public static class Settings
    {
        public const string Url = "http://52.177.12.77:8080/uk/";
        public const string Email = "set@selenium.test";
        public const string Password = "shmal";
        public static readonly TimeSpan ImplicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32("3000"));
    }
}
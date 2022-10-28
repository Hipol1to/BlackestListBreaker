using ListBreaker.Data;
using ListBreaker.POMs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
namespace ListBreaker
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string orbiUrl = Confidential.LoginUrl;
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(orbiUrl);
            driver.Manage().Window.Maximize();
            OrbiLoginPage.LoginOnOrbi(driver, Confidential.Email, Confidential.Password);
            OrbiInfoPage.NavigateToGroupPage(driver);
            string yo = "";
            driver.Close();
            driver.Dispose();
        }
    }
}
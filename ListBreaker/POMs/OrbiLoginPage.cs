using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListBreaker.Data;

namespace ListBreaker.POMs
{
    public static class OrbiLoginPage
    {
        private static string Password => string.Empty;
        private static By Username => By.Id("txtNombreUsuario");
        private static By Passwordd => By.Id("txtContrasena");
        private static By LoginButton => By.XPath("//*[contains(@name,'submit')]");
        private static By OkButton => By.XPath("//*[contains(@class,'btn-block')]");
        private static By ScrollButton => By.Id("bajar");

        public static void LoginOnOrbi(IWebDriver driver, string email, string password)
        {
            var emailInput = driver.FindElement(Username);

            emailInput.Click();
            emailInput.SendKeys(email);

            var passwordInput = driver.FindElement(Passwordd);
            passwordInput.Click();
            passwordInput.SendKeys(password);

            var login = driver.FindElement(LoginButton);
            login.Click();
            Thread.Sleep(1000);
            driver.FindElement(ScrollButton).Click();
            Thread.Sleep(500);
            driver.FindElement(OkButton).Click();
        }
    }
}

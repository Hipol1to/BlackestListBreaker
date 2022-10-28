using ListBreaker.Data;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBreaker.POMs
{
    public static class OrbiInfoPage
    {
        private static string SubjectNeeded = "Programación II"; //nombre asignatura
        private static By SubjectName => By.XPath("//*[@id=\"div-contenido\"]/div[4]/div/div[1]/div/table[1]/tbody/tr[2]/td[2]/table/tbody/tr[1]/td[2]/div");
        public static void NavigateToGroupPage(IWebDriver driver)
        {
            int minGroupNumber = 62337;
            int maxGroupNumber = 65600;
            for (int currentGroupNumber = minGroupNumber; currentGroupNumber < maxGroupNumber; currentGroupNumber++)
            {
                driver.Navigate().GoToUrl($"{Confidential.GroupUrl}{currentGroupNumber}");
                Thread.Sleep(3000);
                try
                {
                    var subjectName = driver.FindElement(SubjectName);
                    var subjectNameValue = subjectName.Text;
                    if (subjectNameValue.Contains(SubjectNeeded))
                    { //debes poner un breakpoint aqui para saber cuando encontro el grupo
                        List<string> groups = new List<string>();
                        string currentURL = driver.Url;
                        groups.Add(currentURL);
                        File.WriteAllLines(Confidential.FilePath, groups);
                    }
                }
                catch (Exception)
                { }
                
            }
            
        }
    }
}

using ListBreaker.Data;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBreaker.POMs
{
    public static class OrbiInfoPage
    {
        private static string SubjectNeeded = "Electronica basica -grupo1-virtual - Puntos Tecnologicos"; //nombre asignatura
        private static By SubjectName => By.XPath("//*[@id=\"div-contenido\"]/div[4]/div/div[1]/div/table[1]/tbody/tr[2]/td[2]/table/tbody/tr[1]/td[2]/div");
        public static Task NavigateToGroupPage(IWebDriver driver)
        {
            int minGroupNumber = 62337;
            int maxGroupNumber = 69600;
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
                        string groupURL = $"{driver.Url} -> {SubjectNeeded}";
                        if (!File.Exists(Confidential.FilePath))
                        {
                            String value = "/G";
                            string[] folderPath = Confidential.FilePath.Split(value);
                            Directory.CreateDirectory(folderPath[0]);
                            using (FileStream fs = File.Create(Confidential.FilePath)) ;
                        }
                            File.AppendAllText(Confidential.FilePath,
                   groupURL + Environment.NewLine);
                    }
                }
                catch (Exception)
                { }
                
            }

            return Task.CompletedTask;
        }
    }
}

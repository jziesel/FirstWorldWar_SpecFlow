using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstWorldWar_SpecFlow.Utility
{
    class CommonFunctions
    {
        public static void clickLink(IWebElement link)
        {
            try
            {
                if (link != null)
                {
                    link.Click();
                }
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }
        }
    }
}

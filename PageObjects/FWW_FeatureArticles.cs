using FirstWorldWar_SpecFlow.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstWorldWar_SpecFlow.PageObjects
{
    class FWW_FeatureArticles
    {
        IWebDriver driver;

        public FWW_FeatureArticles(IWebDriver driver)
        {
            this.driver = driver;
        }

        /*
         *      Locators
         */
        By trenchWarfare = By.XPath("//*[@id='rightbar']/ul[1]/li[8]/a");


        public void clickFeatureArticleLink()
        {
            CommonFunctions.clickLink(driver.FindElement(trenchWarfare));
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using static OpenQA.Selenium.Edge.EdgeOptions;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using FirstWorldWar_SpecFlow.DataProviders;
using FluentAssertions;  //https://methodpoet.com/fluent-assertions/
using System.Collections.Generic;
using FirstWorldWar_SpecFlow.Managers;
using FirstWorldWar_SpecFlow.PageObjects;

namespace TQA_SpecFlowProject1.Steps
{
    [Binding]
    public class PopularFeaturesSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private WebDriverManager webDriverManager = new WebDriverManager();
        private IWebDriver driver = null;
        private FWW_FeatureArticles featureArticle = null;

        public PopularFeaturesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = webDriverManager.getDriver();
            featureArticle = new FWW_FeatureArticles(driver);
        }


        [Given(@"the First World War Home page is loaded")]
        public void GivenTheFirstWorldWarHomePageIsLoaded()
        {
            //ScenarioContext.Current.Pending();
            driver.Url = "https://firstworldwar.com/index.htm";
        }
        
        [When(@"the user selects the Trench Warfare link")]
        public void WhenTheUserSelectsTheTrenchWarfareLink()
        {
            //ScenarioContext.Current.Pending();
            featureArticle.clickFeatureArticleLink();
        }
        
        [Then(@"the user is taken to the Feature Articles - Life in the Trenches page")]
        public void ThenTheUserIsTakenToTheFeatureArticles_LifeInTheTrenchesPage()
        {
            //ScenarioContext.Current.Pending();
            if (driver.FindElement(By.XPath("//*[@id='main']/h1")).Text.Contains("Life in the Trenches")){
                Console.WriteLine("Success!");
            } else
            {
                Console.WriteLine("Did not land on the correct page!");
            }
        }

        [When(@"the user clicks the current (.*)")]
        public void WhenTheUserClicksTheCurrent(string link)
        {
            clickLink(link);
        }

        [Then(@"the user is taken to the specific (.*)")]
        public void ThenTheUserIsTakenToTheSpecific(string article)
        {
            verifyLandingPage(article);
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            webDriverManager.closeWebDriver();
        }


        private void clickLink(string link)
        {
            driver.FindElement(By.LinkText(link)).Click();
        }

        private void verifyLandingPage(string page)
        {
            if (driver.FindElement(By.XPath("//*[@id='main']/h1")).Text.Contains(page))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Did not land on the correct page!");
            }
        }

        private void livingDocHtmlReportGeneration()
        {

        }
    }
}

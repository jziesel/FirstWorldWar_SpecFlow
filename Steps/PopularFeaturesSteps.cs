using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;  //https://methodpoet.com/fluent-assertions/
using FirstWorldWar_SpecFlow.Managers;
using FirstWorldWar_SpecFlow.PageObjects;

namespace TQA_SpecFlowProject1.Steps
{
    [Binding]
    public class PopularFeaturesSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private WebDriverManager webDriverManager = null;  // new WebDriverManager();
        private IWebDriver driver = null;
        private FWW_FeatureArticles featureArticle = null;

        public PopularFeaturesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            webDriverManager = new WebDriverManager(_scenarioContext);
            driver = _scenarioContext.Get<IWebDriver>("wdmDriver");
            featureArticle = new FWW_FeatureArticles(driver);
        }


        [When(@"the user selects the Trench Warfare link")]
        public void WhenTheUserSelectsTheTrenchWarfareLink()
        {
            featureArticle.clickFeatureArticleLink();
        }
        
        [Then(@"the user is taken to the Feature Articles - Life in the Trenches page")]
        public void ThenTheUserIsTakenToTheFeatureArticles_LifeInTheTrenchesPage()
        {
            if (driver.FindElement(By.XPath("//*[@id='main']/h1")).Text.Contains("Life in the Trenches")){
                Console.WriteLine("Success!");
            } else
            {
                Console.WriteLine("Did not land on the correct page!");
            }
        }

/*        [When(@"the user clicks the current (.*)")]
        public void WhenTheUserClicksTheCurrent(string link)
        {
            clickLink(link);
        }

        [Then(@"the user is taken to the specific (.*)")]
        public void ThenTheUserIsTakenToTheSpecific(string article)
        {
            verifyLandingPage(article);
        }*/

        [AfterScenario()]
        public void AfterScenario()
        {
            webDriverManager.closeWebDriver(driver);
        }


/*        private void clickLink(string link)
        {
            driver.FindElement(By.LinkText(link)).Click();
        }*/

/*        private void verifyLandingPage(string page)
        {
            if (driver.FindElement(By.XPath("//*[@id='main']/h1")).Text.Contains(page))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Did not land on the correct page!");
            }
        }*/

        private void livingDocHtmlReportGeneration()
        {

        }
    }
}

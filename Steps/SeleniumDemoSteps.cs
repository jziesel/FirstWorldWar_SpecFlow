using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace TQA_SpecFlowProject1.Steps
{
    [Binding]
    public class SeleniumDemoSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver = null;


        [Given(@"the Firefox Webdriver is launched")]
        public void GivenTheFirefoxWebdriverIsLaunched()
        {
            //ScenarioContext.Current.Pending();
            driver = new FirefoxDriver();
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
            driver.FindElement(By.XPath("//*[@id='rightbar']/ul[1]/li[8]/a")).Click();
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

        [AfterScenario()]
        public void AfterScenario()
        {
            Console.WriteLine("Closing the WebDriver");
            if (driver != null)
            {
                driver.Quit();

            }        
        }
    }
}

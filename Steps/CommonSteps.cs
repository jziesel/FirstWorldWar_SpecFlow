using FirstWorldWar_SpecFlow.Managers;
using FirstWorldWar_SpecFlow.Utility;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace FirstWorldWar_SpecFlow.Steps
{
    [Binding]
    public class CommonSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private WebDriverManager webDriverManager = null;  // new WebDriverManager();
        private IWebDriver driver = null;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            webDriverManager = new WebDriverManager(_scenarioContext);
            driver = _scenarioContext.Get<IWebDriver>("wdmDriver");
        }

        [Given(@"the First World War Home page is loaded")]
        public void GivenTheFirstWorldWarHomePageIsLoaded()
        {
            driver.Url = "https://firstworldwar.com/index.htm";
        }

        [When(@"the user clicks the current (.*)")]
        public void WhenTheUserClicksTheCurrent(string link)
        {
            //clickLink(link);
            CommonFunctions.clickLink(driver.FindElement(By.LinkText(link)));
        }

        [Then(@"the user is taken to the specific (.*)")]
        public void ThenTheUserIsTakenToTheSpecific(string article)
        {
            verifyLandingPage(article);
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
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using static OpenQA.Selenium.Edge.EdgeOptions;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace TQA_SpecFlowProject1.Steps
{
    [Binding]
    public class PopularFeaturesSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver = null;

        public PopularFeaturesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"the Webdriver is launched")]
        public void GivenTheWebdriverIsLaunched()
        {
            //ScenarioContext.Current.Pending();

            // this is temporary until config file can be incorporated...
            var browser = "CHROMEBROWSER";   // "EDGEBROWSER";  

            switch(browser)
            {
                case "CHROMEBROWSER":
                    ChromeOptions co = new ChromeOptions();
                    co.AcceptInsecureCertificates = true;  // needed because the AUT site has an expired cert.
                    driver = new ChromeDriver("C:\\Users\\JZiesel\\.nuget\\packages\\Selenium.WebDriver.ChromeDriver\\109.0.5414.7400\\driver\\win32\\chromedriver.exe", co);
                    break;

                case "EDGEBROWSER":
                    EdgeOptions eo = new EdgeOptions();
                    eo.AcceptInsecureCertificates = true;  // needed because the AUT site has an expired cert.
                    driver = new EdgeDriver(eo);
                    break;

                case "FIREFOXBROWSER":
                    FirefoxOptions fo = new FirefoxOptions();
                    fo.AcceptInsecureCertificates = true;  // needed because the AUT site has an expired cert.
                    driver = new FirefoxDriver("C:\\Users\\JZiesel\\.nuget\\packages\\selenium.webdriver.geckodriver\\0.33.0\\driver\\win64\\geckodriver.exe", fo);  // _testRunContext.TestDirectory   "C:\\Users\\JZiesel\\geckodriver260\\geckodriver.exe"
                    break;

                default:
                    break;
            }

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
            Console.WriteLine("Closing the WebDriver");
            if (driver != null)
            {
                driver.Quit();

            }        
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

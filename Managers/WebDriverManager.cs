using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using static OpenQA.Selenium.Edge.EdgeOptions;
using TechTalk.SpecFlow;
using System.Text;
using System;
using System.Collections.Generic;
using FirstWorldWar_SpecFlow.DataProviders;
using FluentAssertions;  //https://methodpoet.com/fluent-assertions/

namespace FirstWorldWar_SpecFlow.Managers
{
    class WebDriverManager
    {
        private readonly ScenarioContext _scenarioContext; 
        private IWebDriver driver = null;

        public WebDriverManager(ScenarioContext scenarioContext)  // ScenarioContext scenarioContext
        {
            _scenarioContext = scenarioContext;
            if (!_scenarioContext.ContainsKey("wdmDriver"))
            {
                getDriver();
            }
        }

        public IWebDriver getDriver()
        {
            if (driver == null) driver = createWebDriver();
            return driver;
        }

        public void maximizeBrowserWindow()
        {
            driver.Manage().Window.FullScreen();
        }

        public void closeWebDriver(IWebDriver driver)
        {
            Console.WriteLine("Closing the WebDriver");
            if (driver != null)
            {
                driver.Quit();

            }
        }

        private IWebDriver createWebDriver()
        {
            var browser = new ConfigFileReader();

            switch (browser.getBrowser())
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
                    Console.WriteLine("Unknown browser defined!");
                    browser.getBrowser().Should().ContainAny(new List<string> { "CHROMEBROWSER", "EDGEBROWSER", "FIREFOXBROWSER" }); //FluentAssertions
                    break;
            }
            driver.Manage().Window.Maximize();
            _scenarioContext.Add("wdmDriver", driver);

            return driver;
        }
    }
}

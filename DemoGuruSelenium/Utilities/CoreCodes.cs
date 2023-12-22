using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Serilog;

namespace DemoGuruSelenium.Utilities
{
    internal class CoreCodes
    {
        protected Dictionary<string, string>? properties; //declaring
        public IWebDriver? driver;

        public ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        public ExtentTest? test;
        public string currDir = Directory.GetParent("../../../").FullName;

        public void ReadConfigSettings()
        {
            properties = new(); //initializing
            string configFileName = currDir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(configFileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        public static DefaultWait<IWebDriver> FluentWait(IWebDriver driver) //for events that need to be waited for execution
        {
            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            return fluentWait;
        }
        public string TakeScreenshot()
        {
            ITakesScreenshot? ts = (ITakesScreenshot?)driver;
            Screenshot? ss = ts?.GetScreenshot();
            string screenShotFilePath = currDir + "/Screenshots/Screenshot_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".png";
            ss?.SaveAsFile(screenShotFilePath);
            return screenShotFilePath; //returning stored file path
        }
        protected void LogTestResult(string testName, string result, string? errorMessage = null)
        {
            Log.Information(result);
            if (errorMessage == null)
            {
                test?.Pass(result);
            }
            else
            {
                test?.Fail($"{result}. Reason: {errorMessage}");
                Log.Error($"Test failed for {testName}\nException: {errorMessage}");
            }
        }

        [OneTimeSetUp]
        public void Initialize() //initializing logs, extent reports and browser
        {
            string logFilePath = currDir + "/Logs/Log_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);
            ReadConfigSettings();
            if (properties?["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties?["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url = properties?["baseUrl"];
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void Cleanup() //cleaning up driver and reports after tests
        {
            driver?.Quit();
            extent.Flush();
            Log.CloseAndFlush();
        }
    }
}

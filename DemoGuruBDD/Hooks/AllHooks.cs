using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DemoGuruBDD.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Serilog;

namespace DemoGuruBDD.Hooks
{
    [Binding]
    internal sealed class AllHooks : CoreCodes //inheriting CoreCodes
    {
        public static IWebDriver? driver;
        public static ExtentReports? extent;
        static ExtentSparkReporter? sparkReporter;
        public static ExtentTest? test;

        [BeforeFeature(Order = 1)]
        public static void InitializeBrowser() //cross browser implementation
        {
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

        [BeforeFeature(Order = 2)]
        public static void InitializeReports()
        {
            string logFilePath = currDir + "/Logs/Log_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/ExtentReport" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);
        }

        [AfterFeature]
        public static void Cleanup()
        {
            driver?.Quit();
            Log.CloseAndFlush();
            extent?.Flush();
        }
    }
}
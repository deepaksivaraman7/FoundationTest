using DemoGuruBDD.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;

namespace DemoGuruBDD.Utilities
{
    internal class CoreCodes
    {
        protected static Dictionary<string, string>? properties; //Declaring properties
        public static string currDir = Directory.GetParent("../../../").FullName;
        public static void ReadConfigSettings()
        {
            properties = new(); //Initializing properties
            string configFilePath = currDir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(configFilePath);
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
        public static string TakeScreenshot(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot ss = ts.GetScreenshot();
            string screenShotFilePath = currDir + "/Screenshots/Screenshot_" + DateTime.Now.ToString("yyyyMMdd_Hmmss") + ".png";
            ss.SaveAsFile(screenShotFilePath);
            return screenShotFilePath; //returning the stored file path
        }
        protected static void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);
            if (errorMessage == null)
            {
                Log.Information(testName + " Passed");
                AllHooks.test?.Pass(result);

            }
            else
            {
                AllHooks.test?.Fail($"{result}. Reason: {errorMessage}");
                Log.Error($"Test failed for {testName}\nException: {errorMessage}");
            }
        }
    }
}

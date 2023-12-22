using DemoGuruSelenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace DemoGuruSelenium.PageObjects
{
    internal class IndexPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public IndexPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }
        public void WaitForAdClose()
        {
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("SIGN-ON"))); //implementation of fluent wait
        }
    }
}

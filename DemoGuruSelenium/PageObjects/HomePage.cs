using DemoGuruSelenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace DemoGuruSelenium.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }

        //Arrange

        [FindsBy(How = How.LinkText, Using = "REGISTER")]
        private IWebElement RegisterLink { get; set; }

        //Act
        public RegisterPage ClickRegisterLink()
        {
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("REGISTER")));
            RegisterLink.Click();
            return new RegisterPage(driver);
        }
    }
}

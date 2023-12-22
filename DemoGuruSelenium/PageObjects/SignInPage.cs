using DemoGuruSelenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace DemoGuruSelenium.PageObjects
{
    internal class SignInPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public SignInPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            fluentWait = CoreCodes.FluentWait(this.driver);
        }

        //Arrange

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "userName")]
        private IWebElement UserNameField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement? PasswordField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement? SubmitButton { get; set; }

        //Act
        public void EnterUserName(string userName)
        {
            UserNameField.SendKeys(userName);
        }
        public void WaitForAdClose()
        {
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Name("userName"))); //implementation of fluent wait
        }
        public void EnterPassword(string password)
        {
            PasswordField?.SendKeys(password);
        }
        public SignInSuccessPage ClickSubmitButton()
        {
            SubmitButton?.Click();
            return new SignInSuccessPage(driver);
        }
    }
}

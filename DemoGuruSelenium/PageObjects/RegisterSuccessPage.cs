using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoGuruSelenium.PageObjects
{
    internal class RegisterSuccessPage
    {
        IWebDriver driver;
        public RegisterSuccessPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange

        [CacheLookup]
        [FindsBy(How = How.LinkText, Using = "sign-in")]
        private IWebElement? SignInLink { get; set; }

        //Act
        public SignInPage ClickSignInLink()
        {
            SignInLink?.Click();
            return new SignInPage(driver);
        }
    }
}

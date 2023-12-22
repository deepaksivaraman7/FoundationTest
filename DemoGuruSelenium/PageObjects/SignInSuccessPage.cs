using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace DemoGuruSelenium.PageObjects
{
    internal class SignInSuccessPage
    {
        IWebDriver driver;
        public SignInSuccessPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange

        [CacheLookup]
        [FindsBy(How = How.LinkText, Using = "SIGN-OFF")]
        private IWebElement? SignOffLink { get; set; }

        //Act
        public IndexPage ClickSignOffLink()
        {
            SignOffLink?.Click();
            return new IndexPage(driver);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace DemoGuruSelenium.PageObjects
{
    internal class RegisterPage
    {
        IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement? FirstNameField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement? LastNameField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement? PhoneField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement? EmailField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "address1")]
        private IWebElement? AddressField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement? CityField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "state")]
        private IWebElement? StateField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "postalCode")]
        private IWebElement? PostalCodeField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement? CountryField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement? UserNameField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement? PasswordField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement? ConfirmPasswordField { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement? SubmitButton { get; set; }

        //Act
        public void EnterFirstName(string firstName)
        {
            FirstNameField?.SendKeys(firstName);
        }
        public void EnterLastName(string lastName)
        {
            LastNameField?.SendKeys(lastName);
        }
        public void EnterPhoneNumber(string phone)
        {
            PhoneField?.SendKeys(phone);
        }
        public void EnterEmail(string email)
        {
            EmailField?.SendKeys(email);
        }
        public void EnterAddress(string address)
        {
            AddressField?.SendKeys(address);
        }
        public void EnterCity(string city)
        {
            CityField?.SendKeys(city);
        }
        public void EnterState(string state)
        {
            StateField?.SendKeys(state);
        }
        public void EnterPostalCode(string postalCode)
        {
            PostalCodeField?.SendKeys(postalCode);
        }
        public void EnterCountry(string country)
        {
            SelectElement selectMonth = new(CountryField);
            selectMonth.SelectByValue(country.ToUpper());
        }
        public void EnterUserName(string userName)
        {
            UserNameField?.SendKeys(userName);
        }
        public void EnterPassword(string password)
        {
            PasswordField?.SendKeys(password);
        }
        public void EnterConfirmPassword(string confirmPassword)
        {
            ConfirmPasswordField?.SendKeys(confirmPassword);
        }
        public RegisterSuccessPage ClickSubmitButton()
        {
            SubmitButton?.Click();
            return new RegisterSuccessPage(driver);
        }
    }
}

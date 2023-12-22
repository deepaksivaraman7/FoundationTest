using DemoGuruBDD.Hooks;
using DemoGuruBDD.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;

namespace DemoGuruBDD.StepDefinitions
{
    [Binding]
    internal class AuthenticationSteps : CoreCodes
    {
        public static IWebDriver driver = AllHooks.driver;
        string testName = "Authentication test";
        DefaultWait<IWebDriver> fluentWait = FluentWait(driver);

        [When(@"User clicks Register link")]
        public void WhenUserClicksRegisterLink()
        {
            AllHooks.test = AllHooks.extent.CreateTest(testName);
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("REGISTER")));
            driver.FindElement(By.LinkText("REGISTER")).Click();
            Log.Information("Clicked register link");
            AllHooks.test.Info("Clicked register link");
        }

        [Then(@"User will be redirected to register page")]
        public void ThenUserWillBeRedirectedToRegisterPage()
        {
            string filePath = TakeScreenshot(driver);
            AllHooks.test?.AddScreenCaptureFromPath(filePath, "Registration page");
            Log.Information("Screenshot taken");
            AllHooks.test?.Info("Screenshot taken");
            try
            {
                Assert.That(driver.Title, Does.Contain("Register"));
                Log.Information("Entered registration page");
                AllHooks.test?.Info("Entered registration page");
            }
            catch (AssertionException ex)
            {
                LogTestResult(testName, $"{testName} failed", ex.Message);
            }
        }

        [When(@"User enters '([^']*)' in the firstname field")]
        public void WhenUserEntersInTheFirstnameField(string firstName)
        {
            driver.FindElement(By.Name("firstName")).SendKeys(firstName);
            Log.Information("Entered first name");
            AllHooks.test?.Info("Entered first name");
        }

        [When(@"User enters '([^']*)' in the lastname field")]
        public void WhenUserEntersInTheLastnameField(string lastName)
        {
            driver.FindElement(By.Name("lastName")).SendKeys(lastName);
            Log.Information("Entered last name");
            AllHooks.test?.Info("Entered last name");
        }

        [When(@"User enters '([^']*)' in the phone field")]
        public void WhenUserEntersInThePhoneField(string phone)
        {
            driver.FindElement(By.Name("phone")).SendKeys(phone);
            Log.Information("Entered phone number");
            AllHooks.test?.Info("Entered phone number");
        }

        [When(@"User enters '([^']*)' in the email field")]
        public void WhenUserEntersInTheEmailField(string email)
        {
            driver.FindElement(By.Id("userName")).SendKeys(email);
            Log.Information("Entered email");
            AllHooks.test?.Info("Entered email");
        }

        [When(@"User enters '([^']*)' in the address field")]
        public void WhenUserEntersInTheAddressField(string address)
        {
            driver.FindElement(By.Name("address1")).SendKeys(address);
            Log.Information("Entered address");
            AllHooks.test?.Info("Entered address");
        }

        [When(@"User enters '([^']*)' in the city field")]
        public void WhenUserEntersInTheCityField(string city)
        {
            driver.FindElement(By.Name("city")).SendKeys(city);
            Log.Information("Entered city");
            AllHooks.test?.Info("Entered city");
        }

        [When(@"User enters '([^']*)' in the state field")]
        public void WhenUserEntersInTheStateField(string state)
        {
            driver.FindElement(By.Name("state")).SendKeys(state);
            Log.Information("Entered state");
            AllHooks.test?.Info("Entered state");
        }

        [When(@"User enters '([^']*)' in the postal code field")]
        public void WhenUserEntersInThePostalCodeField(string postalCode)
        {
            driver.FindElement(By.Name("postalCode")).SendKeys(postalCode);
            Log.Information("Entered postal code");
            AllHooks.test?.Info("Entered postal code");
        }

        [When(@"User selects '([^']*)' from the country dropdown")]
        public void WhenUserSelectsFromTheCountryDropdown(string country)
        {
            driver.FindElement(By.Name("country")).SendKeys(country);
            Log.Information("Entered country");
            AllHooks.test?.Info("Entered country");
        }

        [When(@"User enters '([^']*)' in the username field")]
        public void WhenUserEntersInTheUsernameField(string username)
        {
            driver.FindElement(By.Id("email")).SendKeys(username);
            Log.Information("Entered user name");
            AllHooks.test?.Info("Entered user name");
        }

        [When(@"User enters '([^']*)' in the password field")]
        public void WhenUserEntersInThePasswordField(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
            Log.Information("Entered password");
            AllHooks.test?.Info("Entered password");
        }

        [When(@"User enters '([^']*)' in the confirm password field")]
        public void WhenUserEntersInTheConfirmPasswordField(string confirmPassword)
        {
            driver.FindElement(By.Name("confirmPassword")).SendKeys(confirmPassword);
            Log.Information("Entered confirm password");
            AllHooks.test?.Info("Entered confirm password");
        }

        [When(@"User clicks submit button")]
        public void WhenUserClicksSubmitButton()
        {
            driver.FindElement(By.Name("submit")).Click();
            Log.Information("Clicked submit button");
            AllHooks.test?.Info("Clicked submit button");
        }

        [Then(@"User will be redirected to registration success page with valid '([^']*)' and '([^']*)'")]
        public void ThenUserWillBeRedirectedToRegistrationSuccessPageWithValidAnd(string userName, string password)
        {
            string filePath = TakeScreenshot(driver);
            AllHooks.test?.AddScreenCaptureFromPath(filePath, "Registration success page");
            Log.Information("Screenshot taken");
            AllHooks.test?.Info("Screenshot taken");
            try
            {
                Assert.That(driver.Url, Does.Contain("register_sucess"));
                Assert.That(userName != "" && password != ""); //this assert will fail as the website allows empty username and password to be registered.
                Log.Information("Registration successful");
                AllHooks.test?.Info("Registration successful");
            }
            catch (AssertionException ex)
            {
                LogTestResult(testName, $"{testName} failed", ex.Message);
            }
        }

        [When(@"User clicks on sign in link")]
        public void WhenUserClicksOnSignInLink()
        {
            driver.FindElement(By.LinkText("sign-in")).Click();
            Log.Information("Clicked sign in link");
            AllHooks.test?.Info("Clicked sign in link");
        }

        [Then(@"User will be redirected to Signin page")]
        public void ThenUserWillBeRedirectedToSigninPage()
        {
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.Name("userName"))); //implementation of fluent wait
            string filePath = TakeScreenshot(driver);
            AllHooks.test?.AddScreenCaptureFromPath(filePath, "Sign in page");
            Log.Information("Screenshot taken");
            AllHooks.test?.Info("Screenshot taken");
            try
            {
                Assert.That(driver.Url, Does.Contain("login"));
                Log.Information("Entered sign in page");
                AllHooks.test?.Info("Entered sign in page");
            }
            catch (AssertionException ex)
            {
                LogTestResult(testName, $"{testName} failed", ex.Message);
            }
        }
        [When(@"User enters '([^']*)' in username field in login page")]
        public void WhenUserEntersInUsernameFieldInLoginPage(string username)
        {
            driver.FindElement(By.Name("userName")).SendKeys(username);
            Log.Information("Entered user name");
            AllHooks.test?.Info("Entered user name");
        }

        [When(@"User enters '([^']*)' in password field in login page")]
        public void WhenUserEntersInPasswordFieldInLoginPage(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
            Log.Information("Entered password");
            AllHooks.test?.Info("Entered password");
        }

        [When(@"User clicks submit button in login page")]
        public void WhenUserClicksSubmitButtonInLoginPage()
        {
            driver.FindElement(By.Name("submit")).Click();
            Log.Information("Clicked submit button");
            AllHooks.test?.Info("Clicked submit button");
        }

        [Then(@"User will be redirected to login success page")]
        public void ThenUserWillBeRedirectedToLoginSuccessPage()
        {
            string filePath = TakeScreenshot(driver);
            AllHooks.test?.AddScreenCaptureFromPath(filePath, "Login success page");
            Log.Information("Screenshot taken");
            AllHooks.test?.Info("Screenshot taken");
            try
            {
                Assert.That(driver.Url, Does.Contain("login_sucess"));
                Log.Information("Login successful");
                AllHooks.test?.Info("Login successful");
            }
            catch (AssertionException ex)
            {
                LogTestResult(testName, $"{testName} failed", ex.Message);
            }
        }

        [When(@"User clicks on sign off link")]
        public void WhenUserClicksOnSignOffLink()
        {
            driver.FindElement(By.LinkText("SIGN-OFF")).Click();
            Log.Information("Clicked sign off link");
            AllHooks.test?.Info("Clicked sign off link");
        }

        [Then(@"User will be redirected to index page")]
        public void ThenUserWillBeRedirectedToIndexPage()
        {
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("SIGN-ON"))); //implementation of fluent wait
            string filePath = TakeScreenshot(driver);
            AllHooks.test?.AddScreenCaptureFromPath(filePath, "Index page");
            Log.Information("Screenshot taken");
            AllHooks.test?.Info("Screenshot taken");
            try
            {
                Assert.That(driver.Url, Does.Contain("index"));
                Log.Information("Sign off successful");
                AllHooks.test?.Info("Sign off successful");

                LogTestResult(testName, $"{testName} successful");
            }
            catch (AssertionException ex)
            {
                LogTestResult(testName, $"{testName} failed", ex.Message);
            }
        }
    }
}

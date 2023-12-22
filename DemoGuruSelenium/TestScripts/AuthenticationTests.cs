using DemoGuruSelenium.Helpers;
using DemoGuruSelenium.PageObjects;
using DemoGuruSelenium.Utilities;
using Serilog;

namespace DemoGuruSelenium.TestScripts
{
    internal class AuthenticationTests : CoreCodes //Inheriting from CoreCodes
    {
        [Test, Category("E2E Test"), TestCase("India")]
        public void AuthenticationTest(string location)//passing location as parameter here, rest of the parameters are taken from excel file
        {
            string testName = "Authentication test";
            test = extent.CreateTest(testName);
            var homePage = new HomePage(driver); //initializing homepage
            Log.Information($"{testName} started");
            test.Info($"{testName} started");

            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "User details";
            List<UserDetails> excelDataList = ExcelUtilities.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                if (!driver.Url.Equals($"{properties?["baseUrl"]}/"))
                {
                    driver.Navigate().GoToUrl(properties?["baseUrl"]);
                }
                try
                {
                    string? firstName = excelData.FirstName;
                    string? lastName = excelData.LastName;
                    string? phone = excelData.Phone;
                    string? email = excelData.Email;
                    string? address = excelData.Address;
                    string? city = excelData.City;
                    string? state = excelData.State;
                    string? postalCode = excelData.PostalCode;
                    string? country = location;
                    string? userName = excelData.UserName;
                    string? password = excelData.Password;

                    Log.Information($"Test started for {firstName}");
                    test.Info($"Test started for {firstName}");

                    var registerPage = homePage.ClickRegisterLink();
                    Log.Information("Register link clicked");
                    test.Info("Register link clicked");
                    string registerPageSnap = TakeScreenshot(); //saves and returns the file path of the screenshot
                    test.AddScreenCaptureFromPath(registerPageSnap, "Register page"); //adding screenshot to the extent report using the file path
                    Assert.That(driver.Title, Does.Contain("Register"));
                    Log.Information("Entered registration page");
                    test.Info("Entered registration page");

                    registerPage.EnterFirstName(firstName);
                    Log.Information("First name entered");
                    test.Info("First name entered");

                    registerPage.EnterLastName(lastName);
                    Log.Information("Last name entered");
                    test.Info("Last name entered");

                    registerPage.EnterPhoneNumber(phone);
                    Log.Information("Phone number entered");
                    test.Info("Phone number entered");

                    registerPage.EnterEmail(email);
                    Log.Information("Email entered");
                    test.Info("Email entered");

                    registerPage.EnterAddress(address);
                    Log.Information("Address entered");
                    test.Info("Address entered");

                    registerPage.EnterCity(city);
                    Log.Information("City entered");
                    test.Info("City entered");

                    registerPage.EnterState(state);
                    Log.Information("State entered");
                    test.Info("State entered");

                    registerPage.EnterPostalCode(postalCode);
                    Log.Information("Postal code entered");
                    test.Info("Postal code entered");

                    registerPage.EnterCountry(country);
                    Log.Information("Country entered");
                    test.Info("Country entered");

                    registerPage.EnterUserName(userName);
                    Log.Information("User name entered");
                    test.Info("User name entered");

                    registerPage.EnterPassword(password);
                    Log.Information("Password entered");
                    test.Info("Password entered");

                    registerPage.EnterConfirmPassword(password);
                    Log.Information("Confirm password entered");
                    test.Info("Confirm password entered");

                    var registerSuccessPage = registerPage.ClickSubmitButton();
                    Log.Information("Clicked submit button");
                    test.Info("Clicked submit button");
                    string registerSuccessSnap = TakeScreenshot(); //saves and returns the file path of the screenshot
                    test.AddScreenCaptureFromPath(registerSuccessSnap, "Register success page"); //adding screenshot to the extent report using the file path
                    Assert.Multiple(() =>
                    {
                        Assert.That(driver.Url, Does.Contain("sucess"));
                        Assert.That(userName != "" && password != ""); //this assert will fail as the website allows empty username and password to be registered.
                    });
                    Log.Information("Registration successful");
                    test.Info("Registration successful");

                    var signInPage = registerSuccessPage.ClickSignInLink();
                    Log.Information("Clicked sign in link");
                    test.Info("Clicked sign in link");

                    signInPage.WaitForAdClose(); //providing wait for closing ad manually
                    string signInPageSnap = TakeScreenshot(); //saves and returns the file path of the screenshot
                    test.AddScreenCaptureFromPath(signInPageSnap, "Signin page"); //adding screenshot to the extent report using the file path
                    Assert.That(driver.Url, Does.Contain("login"));
                    Log.Information("Entered login page");
                    test.Info("Entered login page");

                    signInPage.EnterUserName(userName);
                    Log.Information("User name entered");
                    test.Info("User name entered");

                    signInPage.EnterPassword(password);
                    Log.Information("Password entered");
                    test.Info("Password entered");

                    var signInSuccessPage = signInPage.ClickSubmitButton();
                    Log.Information("Clicked submit button");
                    test.Info("Clicked submit button");

                    string signInSuccessSnap = TakeScreenshot(); //saves and returns the file path of the screenshot
                    test.AddScreenCaptureFromPath(signInSuccessSnap, "Signin success page"); //adding screenshot to the extent report using the file path
                    Assert.That(driver.Url, Does.Contain("login_sucess"));
                    Log.Information("Login success");
                    test.Info("Login success");
                    var indexPage = signInSuccessPage.ClickSignOffLink();
                    Log.Information("Clicked sign off link");
                    test.Info("Clicked sign off link");

                    indexPage.WaitForAdClose(); //providing wait for closing ad manually
                    string indexPageSnap = TakeScreenshot(); //saves and returns the file path of the screenshot
                    test.AddScreenCaptureFromPath(indexPageSnap, "Index page"); //adding screenshot to the extent report using the file path
                    Assert.That(driver.Url, Does.Contain("index"));
                    LogTestResult(testName, $"{testName} success");
                }
                catch (Exception ex)
                {
                    LogTestResult(testName, $"{testName} failed", ex.Message);
                }

            }
        }
    }
}

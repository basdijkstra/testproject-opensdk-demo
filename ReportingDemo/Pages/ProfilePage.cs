

using OpenQA.Selenium;
using ReportingDemo.Helpers;
using TestProject.OpenSDK.Drivers.Web;

namespace ReportingDemo.Pages
{
    public class ProfilePage
    {
        private ChromeDriver driver;

        private SeleniumHelpers selenium;

        private readonly By textfieldGreetings = By.CssSelector("#doesnotexist");

        public ProfilePage(ChromeDriver driver)
        {
            this.driver = driver;

            this.selenium = new SeleniumHelpers(this.driver);
        }

        public bool GreetingsAreDisplayed()
        {
            return selenium.IsVisible("textfieldGreetings", this.textfieldGreetings);
        }
    }
}

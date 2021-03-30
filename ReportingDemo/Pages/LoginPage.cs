using OpenQA.Selenium;
using ReportingDemo.Helpers;
using TestProject.OpenSDK.Drivers.Web;

namespace ReportingDemo.Pages
{
    public class LoginPage
    {
        private ChromeDriver driver;

        private SeleniumHelpers selenium;

        private readonly By textfieldUsername = By.CssSelector("#name");
        private readonly By textfieldPassword = By.CssSelector("#password");
        private readonly By buttonDoLogin = By.CssSelector("#login");

        public LoginPage(ChromeDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl("https://example.testproject.io");

            this.selenium = new SeleniumHelpers(this.driver);        }

        public void LoginAs(string username, string password)
        {
            this.selenium.SendKeys("textfieldUsername", this.textfieldUsername, "John Smith");
            this.selenium.SendKeys("textfieldPassword", this.textfieldPassword, "12345");
            this.selenium.Click("buttonDoLogin", this.buttonDoLogin);
        }
    }
}

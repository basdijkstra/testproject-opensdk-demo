using NUnit.Framework;
using OpenQA.Selenium;
using ReportingDemo.Pages;
using TestProject.OpenSDK.Drivers.Web;
using TestProject.OpenSDK.Enums;

namespace ReportingDemo
{
    public class ReportingTest
    {
        private ChromeDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver();
            this.driver.Report().DisableCommandReports(DriverCommandsFilter.All);
        }

        [Test]
        public void ExampleReportingTest()
        {
            new LoginPage(this.driver)
                .LoginAs("John Smith", "12345");

            Assert.IsTrue(
                new ProfilePage(this.driver).GreetingsAreDisplayed()
            );
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver?.Quit();
        }
    }
}
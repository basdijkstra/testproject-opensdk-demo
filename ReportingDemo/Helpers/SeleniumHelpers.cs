using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestProject.OpenSDK.Drivers.Web;

namespace ReportingDemo.Helpers
{
    public class SeleniumHelpers
    {
        private ChromeDriver driver;
        public SeleniumHelpers(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void SendKeys(string elementDescriptor, By by, string textToSend)
        {
            try
            {
                IWebElement myElement = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                });

                myElement.Clear();
                myElement.SendKeys(textToSend);
                this.driver.Report().Step(
                    description: $"Sent '{textToSend}' to element '{elementDescriptor}' located by {by}",
                    passed: true);
            }
            catch (WebDriverException)
            {
                string errorMessage = $"Error in SendKeys(): could not locate element '{elementDescriptor}' located by {by}";

                this.driver.Report().Step(
                    description: errorMessage,
                    passed: false,
                    screenshot: true);

                Assert.Fail(errorMessage);
            }
        }

        public void Click(string elementDescriptor, By by)
        {
            try
            {
                IWebElement myElement = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                });

                myElement.Click();
                this.driver.Report().Step(
                    description: $"Clicked element '{elementDescriptor}' located by {by}",
                    passed: true);
            }
            catch (WebDriverException)
            {
                string errorMessage = $"Error in Click(): could not locate element '{elementDescriptor}' located by {by}";

                this.driver.Report().Step(
                    description: errorMessage,
                    passed: false,
                    screenshot: true);

                Assert.Fail(errorMessage);
            }
        }

        public bool IsVisible(string elementDescriptor, By by)
        {
            try
            {
                IWebElement myElement = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(driver =>
                {
                    IWebElement tempElement = this.driver.FindElement(by);
                    return (tempElement.Displayed) ? tempElement : null;
                });

                this.driver.Report().Step(
                    description: $"Check visibility of element '{elementDescriptor}' located by '{by}'",
                    passed: true);

                return true;
            }
            catch (WebDriverException)
            {
                this.driver.Report().Step(
                    description: $"Check visibility of element '{elementDescriptor}' located by '{by}'",
                    passed: false);

                return false;
            }
        }
    }
}

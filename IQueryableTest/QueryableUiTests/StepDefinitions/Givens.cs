using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QueryableUiTests.Helpers;

namespace QueryableUiTests.StepDefinitions
{
    [Binding]
    public class Givens
    {
        private IWebDriver WebDriver => ChromeGod.Instance.WebDriver;

        [Given(@"Bob have given birth to ""([^""]*)""")]
        public void GivenBobHaveGivenBirthTo(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        [Given(@"aboba was born")]
        public void GivenAbobaWasBorn()
        {
            IWait<IWebDriver> wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Constants.PAGE_LOAD_TIMEOUT));
            wait.Until(driver =>
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString() == "complete";
            });
        }
    }
}

using OpenQA.Selenium;
using QueryableUiTests.Helpers;
using System;
using TechTalk.SpecFlow;

namespace QueryableUiTests.StepDefinitions
{
    [Binding]
    public class Whens
    {
        private IWebDriver WebDriver => ChromeGod.Instance.WebDriver;

        [When(@"Bob smashes ""([^""]*)""")]
        public void WhenBobSmashesId(string selector)
        {
            WebDriver.FindElement(By.CssSelector(selector)).Click();
        }
    }
}

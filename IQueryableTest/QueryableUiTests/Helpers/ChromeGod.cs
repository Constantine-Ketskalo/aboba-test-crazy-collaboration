using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableUiTests.Helpers
{
    public sealed class ChromeGod
    {
        #region Singleton
        private ChromeGod()
        {
            WebDriver = new ChromeDriver();
        }

        public static ChromeGod Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly ChromeGod instance = new ChromeGod();
        }
        #endregion

        public IWebDriver WebDriver { get; private set; }
    }
}

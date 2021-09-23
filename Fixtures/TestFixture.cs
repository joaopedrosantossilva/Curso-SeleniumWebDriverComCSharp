using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Alura.LeilaoOnline.Funcional.Helpers;
using System;

namespace Alura.LeilaoOnline.Funcional.Fixtures {
    public class TestFixture : IDisposable {

        public IWebDriver Driver { get; private set; }

        public TestFixture() {
            Driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //TearDown
        public void Dispose() {
            Driver.Quit();
        }

    }
}

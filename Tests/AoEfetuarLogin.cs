using Alura.LeilaoOnline.Funcional.Fixtures;
using Alura.LeilaoOnline.Funcional.PageObjects;
using OpenQA.Selenium;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoEfetuarLogin {

        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture) {
            driver = fixture.Driver;
              }

        [Fact]
        public void DadoCredenciasValidasDeveIrParaDashboard() {

            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");

            //act
            loginPO.EfetuarLolgin();

            //Assert
            Assert.Contains("Dashboard", driver.Title);

        }

        [Fact]
        public void DadoCredenciasInvalidasDeveContinuarLogin() {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.o", "123");

            //act
            loginPO.EfetuarLolgin();

            //Assert
            Assert.Contains("Login", driver.PageSource);

        }
    }
}


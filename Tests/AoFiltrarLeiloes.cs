using Alura.LeilaoOnline.Funcional.Fixtures;
using Alura.LeilaoOnline.Funcional.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Xunit;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes {

        private IWebDriver driver;

        public AoFiltrarLeiloes(TestFixture fixture) {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressaDeveMostrarPainelResutado() {

            //arrange
            new LoginPO(driver).EfetuarLoginComCredencias("fulano@example.org","123");

            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //act
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(new List<string> { "Arte", "Coleções" },"",true);

            //assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);

        }
    }
}

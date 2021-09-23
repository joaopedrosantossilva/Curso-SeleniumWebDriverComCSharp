using Alura.LeilaoOnline.Funcional.Fixtures;
using Alura.LeilaoOnline.Funcional.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoOfertarUmLance {

        private IWebDriver driver; 

        public AoOfertarUmLance(TestFixture fixture) {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual() {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.EfetuarLolgin();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1);

            //act
            detalhePO.ofertarLance(300);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => detalhePO.lanceAtual == 300);

            //assert
            Assert.True(iguais);
        }
    }
}

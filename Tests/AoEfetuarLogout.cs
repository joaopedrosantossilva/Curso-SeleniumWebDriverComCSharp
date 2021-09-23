using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.LeilaoOnline.Funcional.PageObjects;
using Alura.LeilaoOnline.Funcional.Fixtures;
using Alura.LeilaoOnline.Funcional.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoEfetuarLogout {

        private IWebDriver driver;
        public AoEfetuarLogout(TestFixture fixture) {
            driver = fixture.Driver;            
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada() {
            //arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .EfetuarLolgin();

            var dashboardPO = new DashboardInteressadaPO(driver);

            //act - efetuar logout
            dashboardPO.Menu.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}

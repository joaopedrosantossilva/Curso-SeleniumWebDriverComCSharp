using Alura.LeilaoOnline.Funcional.Fixtures;
using Alura.LeilaoOnline.Funcional.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao {

        private IWebDriver driver; 

        public AoNavegarParaFormNovoLeilao(TestFixture fixture) {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminDeveMostrarTresCategorias() {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.EfetuarLolgin();

            var novoLeilaoPO = new NovoLeilaoBO(driver);

            //act
            novoLeilaoPO.Visitar();

            //assert
            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }
    }
}

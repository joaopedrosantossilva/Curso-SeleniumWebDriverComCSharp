using Alura.LeilaoOnline.Funcional.Fixtures;
using OpenQA.Selenium;
using System;
using Xunit;
using Alura.LeilaoOnline.Funcional.PageObjects;
using System.Threading;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoCriarleilao {

        private IWebDriver driver;

        public AoCriarleilao(TestFixture fixture) {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInformarInfoValidadesDeveCadastrarLeilao() {
            
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.EfetuarLolgin();

            var novoLeilaoPO = new NovoLeilaoBO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 1",
                "Felis pellentesque scelerisque porttitor hendrerit habitant curabitur nulla, vivamus eros odio etiam fringilla orci donec, ipsum cursus ultrices non sodales semper. praesent sit malesuada sem fusce vestibulum proin imperdiet pretium tortor enim, mattis lacus facilisis mauris cubilia suspendisse urna habitant et, proin hac pretium ut dictum venenatis pulvinar rutrum urna. dictum tincidunt convallis dictum primis dapibus justo sed, ipsum neque erat sodales commodo nulla placerat, proin sed conubia consectetur varius porta. ultrices eu pellentesque tellus nulla fusce faucibus auctor, ante fusce molestie curabitur dui velit accumsan pharetra, vivamus sem lacus sapien vitae varius.",
                "Item de Colecionador",
                4000,
                "c:\\imagens\\colecao1.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
                );

            //act
            novoLeilaoPO.SubmeteConclusaoFormulario();

            //assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}

using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Funcional.Fixtures;
using Alura.LeilaoOnline.Funcional.PageObjects;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoEfetuarORegistro {

        private IWebDriver driver;
        private RegistroPO registroPO;

        public AoEfetuarORegistro(TestFixture fixture) {
            driver = fixture.Driver;
            registroPO = new RegistroPO(driver);
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento() {
            
            //arrange
            registroPO.Visitar();
            registroPO.preencheFormulario(nome: "João Pedro", email: "joaopedro@teste.com", senha: "12345678", confirmPassword: "12345678");

            //act - Confirma registro
            registroPO.SubmeteFormulario();
            //assert - devo ser direcionado para uma pagina de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "joaopedro@teste.com", "123456789", "123456789")]
        [InlineData("João Pedro", "joaopedro", "123456789", "123456789")]
        [InlineData("João Pedro", "joaopedro@teste.com", "123456789", "12345")]
        [InlineData("João Pedro", "joaopedro@teste.com", "123456789", "")]
        public void DadoInformacoesInvalidasDeveExibirMensagem(string nome, string email, string senha, string confirmPassword) {
            //arrange
            registroPO.Visitar();
            registroPO.preencheFormulario(nome, email, senha, confirmPassword);
            //act - Confirma registro
            registroPO.SubmeteFormulario();
            //Deve validar mensagens de campos obrigatorios presentes presentes
            Assert.Contains("Registre-se para participar dos leilões!", driver.PageSource);
        }
        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagem() {

            //arrange
            registroPO.Visitar();
            //act
            registroPO.SubmeteFormulario();
            //assert
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }


    }
}

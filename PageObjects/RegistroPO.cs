using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Funcional.PageObjects {
    public class RegistroPO {

        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmSenha;
        private By byBotaoRegistro;
        private By bySpanErroNome;

        public RegistroPO(IWebDriver driver) {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErroNome = By.CssSelector("span[data-valmsg-for='Nome']");
        }

        public string NomeMensagemErro => driver.FindElement(bySpanErroNome).Text;

        public void preencheFormulario(string nome, string email, string senha, string confirmPassword) {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmSenha).SendKeys(confirmPassword);          
        }

        public void Visitar() {

            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        public void SubmeteFormulario() {
            driver.FindElement(byBotaoRegistro).Click();
        }


    }
}

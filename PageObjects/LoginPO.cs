using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Funcional.PageObjects {

    public class LoginPO {
        private IWebDriver driver;
        private By byInputUsuario;
        private By byInputSenha;
        private By byButtonLogin;

        public LoginPO(IWebDriver driver) {
            this.driver = driver;
            byInputUsuario = By.Id("Login");
            byInputSenha = By.Id("Password");
            byButtonLogin = By.Id("btnLogin");
        }

        public LoginPO Visitar() {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            return this;
        }

        public LoginPO PreencheFormulario(string email, string senha) {
            return InformarEmail(email)
                .InformarSenha(senha);
        }

        public LoginPO InformarSenha(string senha) {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO InformarEmail(string email) {
            driver.FindElement(byInputUsuario).SendKeys(email);
            return this;
        }

        public LoginPO EfetuarLolgin() {
            driver.FindElement(byButtonLogin).Click();
            return this;
        }

        public void EfetuarLoginComCredencias(string login, string password) {
            Visitar()
                .PreencheFormulario(login, password)
                .EfetuarLolgin();
        }

    }
}

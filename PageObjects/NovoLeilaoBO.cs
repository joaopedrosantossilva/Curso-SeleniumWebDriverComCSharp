using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Funcional.PageObjects {
    public class NovoLeilaoBO {
        private IWebDriver driver;
        private By byInputTitulo;
        private By byInputDescricao;
        private By bySelectCategoria;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byButtonSalvar;


        public NovoLeilaoBO(IWebDriver driver) {
            this.driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            bySelectCategoria = By.CssSelector("select[id=Categoria]");
            byInputCategoria = By.CssSelector(".select-wrapper input");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byButtonSalvar = By.CssSelector("button[type=submit]");
        }

        public IEnumerable<string> Categorias{
            get {
                var elementoCategoria = new SelectElement(driver.FindElement(bySelectCategoria));
                return elementoCategoria.Options
                    .Where(o => o.Enabled)
                    .Select(o => o.Text);


            } 
        }


        public void Visitar() {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(string titulo, string descricao, string categoria, double valorInicial, string imagem, DateTime inicioPregao, DateTime terminoPregao) {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            driver.FindElement(byInputCategoria).SendKeys(categoria);
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputValorInicial).SendKeys(valorInicial.ToString());
            driver.FindElement(byInputInicioPregao).SendKeys(inicioPregao.ToString("dd/MM/yyyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(terminoPregao.ToString("dd/MM/yyyy"));
        }

        public void SubmeteConclusaoFormulario() {
            driver.FindElement(byButtonSalvar).Click();
        }
    }
}

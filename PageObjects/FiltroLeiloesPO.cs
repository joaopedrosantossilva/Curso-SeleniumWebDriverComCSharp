using Alura.LeilaoOnline.Funcional.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Funcional.PageObjects {
    public class FiltroLeiloesPO {

        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byButtonPesquisar;

        public FiltroLeiloesPO(IWebDriver driver) {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byButtonPesquisar = By.CssSelector("form > button.btn");
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento) {

            var select = new SelectMaterialize(driver, bySelectCategorias);
            select.DeselectAll();
            categorias.ForEach(categ => {
                select.SelectByText(categ);
            });
            driver.FindElement(byInputTermo).SendKeys(termo);

            if (emAndamento) {
                driver.FindElement(byInputAndamento).Click();
            }

            driver.FindElement(byButtonPesquisar).Click();
        }
    }
}

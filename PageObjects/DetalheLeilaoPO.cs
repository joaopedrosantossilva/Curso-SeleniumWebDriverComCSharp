using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Funcional.PageObjects {
    public class DetalheLeilaoPO {

        private IWebDriver driver;
        private By byInputValor;
        private By byButtonDarLance;
        private By byLanceAtual;

        public DetalheLeilaoPO (IWebDriver driver) {
            this.driver = driver;
            byInputValor = By.Id("Valor");
            byButtonDarLance = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        public double lanceAtual {
            get {
                 var valorAtual = driver.FindElement(byLanceAtual).Text;
                return double.Parse(valorAtual, System.Globalization.NumberStyles.Currency);
            }
        }

        public void Visitar(int idLeilao) {
            driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");
        }

        public void ofertarLance(double valor) {
            driver.FindElement(byInputValor).Clear();
            driver.FindElement(byInputValor).SendKeys(valor.ToString());
            darLance();
        }

        public void darLance() {
            driver.FindElement(byButtonDarLance).Click();
        }
    }
}

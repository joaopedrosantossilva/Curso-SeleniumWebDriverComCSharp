using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Funcional.Helpers {

    class SelectMaterialize {

        private IWebDriver driver;
        private IWebElement selectWrrapper;
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper) {
            this.driver = driver;
            selectWrrapper = driver.FindElement(locatorSelectWrapper);
            opcoes = selectWrrapper.FindElements(By.CssSelector("li > span"));
        }

        public SelectMaterialize(IWebDriver driver) {
            this.driver = driver;
        }

        public IEnumerable<IWebElement> Options => opcoes;

        private void OpenWrapper() {
            selectWrrapper.Click();
        }

        private void LoseFocus() {
            selectWrrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);
        }


        public void DeselectAll() {
            OpenWrapper();
            opcoes.ToList().ForEach(o => {
                o.Click();
            });
            LoseFocus();
        }



        public void SelectByText(string option) {
            OpenWrapper();
            opcoes
                .Where(o => o.Text.Contains(option))
                .ToList()
                .ForEach(o => {
                    o.Click();
                });
            LoseFocus();
                
        }

    }
}


using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Alura.LeilaoOnline.Funcional.Fixtures;

namespace Alura.LeilaoOnline.Funcional.Tests {

    [Collection("Chrome Driver")]
    public class AoNavegarParaHome{

        private IWebDriver driver;

        //Setup
        public AoNavegarParaHome(TestFixture fixture) {
            //Arrange 
            driver = fixture.Driver;
         }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo() {

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //Assert
            Assert.Contains("Leilões Online", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNaPagina() {

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMsgDeError() {

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000/");

            //Assert
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach (var span in spans) {
                Assert.False(string.IsNullOrEmpty(span.Text)); 
            }
           
        }


    }
}

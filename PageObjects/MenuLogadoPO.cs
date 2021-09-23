using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Funcional.PageObjects {
    public class MenuLogadoPO {

        private IWebDriver driver;
        private By byLinkLogout;
        private By byMeuPerfilLink;

        public MenuLogadoPO(IWebDriver driver) {
            this.driver = driver;
            byLinkLogout = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
        }

        public void EfetuarLogout() {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLinkLogout);

            IAction acaoLogout = new Actions(driver)
            //mover para o elemento pai
            .MoveToElement(linkMeuPerfil)
            //mover para o link de logout
           .MoveToElement(linkLogout)
           //clicar no link de logout
           .Click()
           .Build();
            //executa ação
            acaoLogout.Perform();
        }
    }
}

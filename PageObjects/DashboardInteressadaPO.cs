using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Alura.LeilaoOnline.Funcional.Helpers;

namespace Alura.LeilaoOnline.Funcional.PageObjects {

    public class DashboardInteressadaPO {
        private IWebDriver driver;      

        public FiltroLeiloesPO Filtro { get;}
        public MenuLogadoPO Menu { get;  }

        public DashboardInteressadaPO(IWebDriver driver) {
            this.driver = driver;
            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
        }

              
    }
}


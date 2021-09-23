using System;
using System.Collections.Generic;
using Alura.LeilaoOnline.Funcional.Helpers;
using Alura.LeilaoOnline.Funcional.PageObjects;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.LeilaoOnline.Funcional.Tests {
    
    public class AoNavegarparaHomeMobile: IDisposable {

        private ChromeDriver driver;

        public AoNavegarparaHomeMobile() {
        }

        public void Dispose() {
            driver.Quit();
        }

        [Fact]
        public void Dadolargura992DeveMostrarmenuMobile() {
            //arrange   
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 992;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);            
            driver = new ChromeDriver(TestHelpers.PastaDoExecutavel, options);
            var homePO = new HomeNaoLogadaPO(driver);

            //act
            homePO.Visitar();

            //assert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }


        [Fact]
        public void Dadolargura993NaoDeveMostrarmenuMobile() {
            //arrange
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 993;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelpers.PastaDoExecutavel, options);
            var homePO = new HomeNaoLogadaPO(driver);


            //act
            homePO.Visitar();

            //assert
            Assert.False(homePO.Menu.MenuMobileVisivel);
        }


    }
}

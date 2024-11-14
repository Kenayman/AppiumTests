using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AppiumTestings.Framework.Test
{
    public class Tests
    {
        private static IMobileApplication Application => AqualityServices.Application;
        protected static readonly JsonSettingsFile config = new("settings.json");
        private static readonly string appPackage = config.GetValue<string>("driverSettings.android.capabilities.appPackage");
        private static readonly string appActivity = config.GetValue<string>("driverSettings.android.capabilities.appActivity");

        private readonly ILabel searchBox1 = AqualityServices.ElementFactory.GetLabel(By.Id("com.android.chrome:id/search_box_text"), "Search Box");
        private readonly ILabel searchBox2 = AqualityServices.ElementFactory.GetLabel(By.XPath("//android.widget.EditText[@resource-id=\"com.android.chrome:id/url_bar\"]"), "Search Box");


        [SetUp]
        public void SetUp()
        {
            // Activa la aplicaci�n de Google Chrome
            Application.Driver.ActivateApp(appPackage);

            
        }

        [Test]
        public void TestBattery()
        {

            Search();
        }

        private void Search()
        {
            

            // Aseg�rate de que el cuadro de b�squeda est� visible antes de interactuar
            Assert.IsTrue(searchBox1.State.WaitForDisplayed(), "Search box is not displayed");

            // Env�a el texto "hotwheels" al cuadro de b�squeda
            searchBox1.Click();
            searchBox2.SendKeys("hotwheels");
            searchBox2.SendKeys(Keys.Enter);

        }


        [TearDown]
        public void TearDown()
        {
            Application.Driver.Quit();
        }
    }
}

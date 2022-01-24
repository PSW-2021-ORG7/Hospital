using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalEndToEndTests.Pages
{
    public class HospitalMapPage
    {
        private readonly IWebDriver _driver;
        private readonly string _hospitalMapPageUri;
        private IWebElement Building => _driver.FindElement(By.XPath("//*[name()='polygon' and contains(@id, 'building')]"));
        

        public HospitalMapPage(IWebDriver driver)
        {
            _driver = driver;
            _hospitalMapPageUri = "http://localhost:4200/hospital-map";
        }

        public void EnsureBuildingIsDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return Building.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void ClickOnBuilding()
        {
            Building.Click();
        }

        public void Navigate() => _driver.Navigate().GoToUrl(_hospitalMapPageUri);
    }
}

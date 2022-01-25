using System;
using HospitalEndToEndTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace HospitalEndToEndTests
{
    public class HospitalMapTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly HospitalMapPage _hospitalMapPage;

        public HospitalMapTests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");     
            options.AddArguments("disable-infobars");         
            options.AddArguments("--disable-extensions"); 
            options.AddArguments("--disable-gpu"); 
            options.AddArguments("--disable-dev-shm-usage");   
            options.AddArguments("--no-sandbox");               
            options.AddArguments("--disable-notifications");    

            _driver = new ChromeDriver(options);

            _hospitalMapPage = new HospitalMapPage(_driver);
            _hospitalMapPage.Navigate();
            _hospitalMapPage.EnsureBuildingIsDisplayed();
        }

        [Fact]
        public void Checks_if_floor_plan_is_displayed()
        {
            _hospitalMapPage.ClickOnBuilding();
            Assert.Equal("http://localhost:4200/hospital-map/floor-plan?buildingId=1", _driver.Url);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

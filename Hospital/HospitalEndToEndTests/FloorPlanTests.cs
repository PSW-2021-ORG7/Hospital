using System;
using HospitalEndToEndTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace HospitalEndToEndTests
{
    public class FloorPlanTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly FloorPlanPage _floorPlanPage;

        public FloorPlanTests()
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

            _floorPlanPage = new FloorPlanPage(_driver);
            _floorPlanPage.Navigate();
            _floorPlanPage.EnsureFloorPlanIsDisplayed();
            _floorPlanPage.EnsureRoomDetailsButtonIsDisabled();
            _floorPlanPage.EnsureRoomsListIsNotEmpty();
        }

        [Fact]
        public void Checks_if_correct_room_is_selected()
        {
            var selectedRoomName = _floorPlanPage.SelectRoom();
            var selectedRoom = _floorPlanPage.FindSelectedRoom();
            Assert.Equal(selectedRoomName, selectedRoom.Text);
            Dispose();
        }

        [Fact]
        public void Checks_if_room_details_btn_is_enabled()
        {
            _floorPlanPage.SelectRoom();
            Assert.True(_floorPlanPage.IsRoomDetailsBtnEnabled());
            Dispose();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

using System;
using System.Linq;
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
            _floorPlanPage.EnsureRadioButtonsAreDisplayed();
        }

        [Fact]
        public void Checks_if_correct_room_is_selected()
        {
            var expectedSelectedRoomName = _floorPlanPage.SelectRoom().FindElement(By.TagName("span")).Text;
            var actualSelectedRoomName = _floorPlanPage.FindSelectedRoom().Text;
            Assert.Equal(expectedSelectedRoomName, actualSelectedRoomName);
        }

        [Fact]
        public void Checks_if_room_details_btn_is_enabled()
        {
            _floorPlanPage.SelectRoom();
            Assert.True(_floorPlanPage.IsRoomDetailsBtnEnabled());
        }

        [Fact]
        public void Checks_if_correct_rooms_are_visible()
        {
            var selectedFloor = _floorPlanPage.ChangeFloors();
            var actualVisibleRooms = _floorPlanPage.GetVisibleRooms();
            var actualHiddenRooms = _floorPlanPage.GetHiddenRooms();
            Assert.True(actualVisibleRooms.All(r => r.GetAttribute("class").Contains("floor-" + selectedFloor)));
            Assert.True(actualHiddenRooms.All(r => !r.GetAttribute("class").Contains("floor-" + selectedFloor)));
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

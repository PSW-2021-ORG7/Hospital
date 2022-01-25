using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HospitalEndToEndTests.Pages
{
    public class FloorPlanPage
    {
        private readonly IWebDriver _driver;
        private readonly string _floorPlanPageUri;
        private IReadOnlyCollection<IWebElement> FloorPlan =>
            _driver.FindElements(By.XPath("//*[name()='rect' and starts-with(@id, 'room-')]"));

        private IWebElement RoomDetailsButton =>
            _driver.FindElement(By.XPath("//*[@id='floor-plan']/app-side-bar/div/div[4]"));

        private IReadOnlyCollection<IWebElement> RoomsList => _driver.FindElements(By.XPath("//*[contains(@id, 'card')]"));

        private IReadOnlyCollection<IWebElement> FloorSelectionRadioButtons =>
            _driver.FindElements(By.XPath("//input[@type='radio' and starts-with(@id, 'floor')]"));

        public FloorPlanPage(IWebDriver driver)
        {
            _driver = driver;
            _floorPlanPageUri = "http://localhost:4200/hospital-map/floor-plan?buildingId=1";
        }

        public void EnsureFloorPlanIsDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return FloorPlan.Count > 0;
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

        public void EnsureRoomDetailsButtonIsDisabled()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return RoomDetailsButton.GetCssValue("cursor") == "default";
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

        public void EnsureRoomsListIsNotEmpty()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return RoomsList.Count > 0;
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

        public void EnsureRadioButtonsAreDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return FloorSelectionRadioButtons.Count > 0;
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

        public IWebElement SelectRoom()
        {
            RoomsList.ElementAt(0).Click();
            return RoomsList.ElementAt(0);
        }

        public IWebElement FindSelectedRoom()
        {
            IWebElement selectedRoom = null;
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
            wait.Until(condition =>
            {
                try
                {
                    selectedRoom = _driver.FindElement(By.XPath("//*[name()='text' and @style='fill: rgb(255, 255, 255); font-size: 14px; visibility: visible;']"));
                    return selectedRoom.Displayed;
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
            return selectedRoom;
        }

        public bool IsRoomDetailsBtnEnabled()
        {
            return RoomDetailsButton.GetCssValue("cursor") == "pointer";
        }

        public string ChangeFloors()
        {
            FloorSelectionRadioButtons.ElementAt(0).Click();
            return FloorSelectionRadioButtons.ElementAt(0).GetAttribute("id")[5..];
        }

        public List<IWebElement> GetVisibleRooms()
        {
            var visibleRooms = new List<IWebElement>();
            foreach (var room in FloorPlan)
            {
                if (room.GetCssValue("visibility") == "visible")
                {
                    visibleRooms.Add(room);
                }
            }

            return visibleRooms;
        }

        public List<IWebElement> GetHiddenRooms()
        {
            var hiddenRooms = new List<IWebElement>();
            foreach (var room in FloorPlan)
            {
                if (room.GetCssValue("visibility") == "hidden")
                {
                    hiddenRooms.Add(room);
                }
            }

            return hiddenRooms;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(_floorPlanPageUri);
    }
}

using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections;

namespace unit5_final_task.Accuweather.Pages
{
    internal class CityWeatherPage : Form
    {
        private const string pageName = "Weather Forecast | AccuWeather";
        private ILabel cityName => ElementFactory.GetLabel(By.ClassName("header-loc"), "City Name");
        public CityWeatherPage() : base(By.XPath(string.Format(LocatorConstants.PartialTextLocator, pageName)), "Accuweather HomePage") { }

        public string GetCityName()
        {
            cityName.State.WaitForDisplayed();
            return cityName.Text;
        }
    }
}
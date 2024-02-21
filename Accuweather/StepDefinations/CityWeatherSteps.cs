using NUnit.Framework;
using TechTalk.SpecFlow;
using unit5_final_task.Accuweather.Pages;

namespace unit5_final_task.Accuweather.StepDefinations
{
    [Binding]
    internal class CityWeatherSteps
    {

        CityWeatherPage cityWeatherPage = new();

        [Then(@"the city weather page header contains the city name (.*) from the search")]
        public void CityWeatherPageContainsTheCityName(string cityName)
        {
            Assert.That(cityWeatherPage.GetCityName(), Is.AtLeast(cityName), "City Name Doesn't Match");
        }
    }
}
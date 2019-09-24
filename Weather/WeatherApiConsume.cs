namespace Weather
{
    using System;
    using System.Threading.Tasks;
    using PCLAppConfig;

    public static class WeatherApiConsume
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string apiKey = ConfigurationManager.AppSettings["apiKey"];
            string query = "https://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode
                + ",us&appid="
                + apiKey
                + "&units=imperial";

            dynamic results = await DataService.GetDataFromService(query).ConfigureAwait(false);
            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + "F";
                weather.Wind = (string)results["wind"]["speed"] + "mph";
                weather.Humidity = (string)results["main"]["humidity"] + "%";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime timeStamp = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = timeStamp.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = timeStamp.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + "UTC";
                weather.Sunset = sunset.ToString() + "UTC";
                return weather;
            }
                return null;
        }
    }
}

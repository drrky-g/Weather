namespace Weather
{
    using System;

    public class Weather
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }

        public Weather()
        {
            //this constructor ensures that the labels are bound to the UI
            //even if theyre empty
            this.Title = "";
            this.Temperature = "";
            this.Wind = "";
            this.Humidity = "";
            this.Visibility = "";
            this.Sunrise = "";
            this.Sunset = "";
        }
    }
}

namespace Weather
{
    using System;
    using System.ComponentModel;
    using Xamarin.Forms;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Demo Weather App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;

            //binding
            this.BindingContext = new Weather();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await WeatherApiConsume.GetWeather(zipCodeEntry.Text);
                this.BindingContext = weather;
                getWeatherBtn.Text = "Search Again";
            }
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.netMaui.Services;
using WeatherApp.netMaui.Model;

namespace WeatherApp.netMaui.ViewModel
{
    internal partial class WeatherInfoViewModel : ObservableObject
    {
		private readonly WeatherService _weatherService;

		public WeatherInfoViewModel()
		{
			_weatherService = new WeatherService();	
		}

        [ObservableProperty]
        private string longitude;

		[ObservableProperty]
		private string latitude;

		[ObservableProperty]
		private string weatherIcon;

		[ObservableProperty]
		private string temperature;

		[ObservableProperty]
		private string weatherDescription;

		[ObservableProperty]
		private string location;

		[ObservableProperty]
		private int humidity;

		[ObservableProperty]
		private string cloudCoverLevel;

		[ObservableProperty]
		private string isDay;

		[RelayCommand]
		private async Task FetchWeatherInformation()
		{
			var responseModel = await _weatherService.GetWeatherInformation(latitude, longitude);
			if (responseModel != null)
			{
				WeatherIcon = responseModel.current.weather_icons[0];
				Temperature = $"{responseModel.current.temperature}";
				Location = $"{responseModel.location.name}, {responseModel.location.region}, {responseModel.location.country}";
				WeatherDescription = responseModel.current.weather_descriptions[0];
				Humidity = responseModel.current.humidity;
				CloudCoverLevel = $"{responseModel.current.cloudcover}";
				IsDay = responseModel.current.is_day;
			}
			else
			{
				await Shell.Current.DisplayAlert("Error", "Failed to fetch weather data.", "OK");
			}
		}

	}

}

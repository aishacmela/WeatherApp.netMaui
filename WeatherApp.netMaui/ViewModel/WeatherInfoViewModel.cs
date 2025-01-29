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
		private string city;

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
		private string feelsLike;

		[ObservableProperty]
		private string windSpeed;

		[RelayCommand]
		private async Task FetchWeatherInformation()
		{
			var responseModel = await _weatherService.GetWeatherInformation(city);
			if (responseModel != null)
			{
				WeatherIcon = responseModel.current.weather_icons[0];
				Temperature = $"{responseModel.current.temperature}°C";
				Location = $"{responseModel.location.name}, {responseModel.location.country}";
				WeatherDescription = responseModel.current.weather_descriptions[0];
				Humidity = responseModel.current.humidity;
				FeelsLike = $"{responseModel.current.feelslike}";
				WindSpeed = $"{responseModel.current.wind_speed}";
			}
			else
			{
				await Shell.Current.DisplayAlert("Error", "Failed to fetch weather data.", "OK");
			}
		}

	}

}

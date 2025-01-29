using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.netMaui.Services;

namespace WeatherApp.netMaui.ViewModel
{
    internal partial class WeatherInfoViewModel : ObservableObject
    {
		// Instance of WeatherService to fetch weather information.
		private readonly WeatherService _weatherService;

		// Constructor initializes the WeatherService instance.
		public WeatherInfoViewModel()
		{
			_weatherService = new WeatherService();	
		}

		// Observable properties to automatically notify UI when changed
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

		// Command that fetches weather information when invoked.
		[RelayCommand]
		private async Task FetchWeatherInformation()
		{
			//Calls the weather service to get data for the given city
		   var responseModel = await _weatherService.GetWeatherInformation(city);

			//If the API response is valid, update the ViewModel properties.
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
				// Show an error alert if fetching data fails.
				await Shell.Current.DisplayAlert("Error", "Failed to fetch weather data.", "OK");
			}
		}

	}

}

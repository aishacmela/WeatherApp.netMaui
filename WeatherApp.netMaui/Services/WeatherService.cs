using System.Net.Http.Json;
using System.Reflection.Metadata;
using WeatherApp.netMaui.Model;

namespace WeatherApp.netMaui.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);
        }

        public async Task<ResponseModel> GetWeatherInformation(string latitude , string longitude)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            return await _httpClient.GetFromJsonAsync<ResponseModel>($"current?access_key={Constants.API_KEY}&query={latitude},{longitude}");
        }
    }
}

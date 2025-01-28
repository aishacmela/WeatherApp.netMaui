using WeatherApp.netMaui.ViewModel;

namespace WeatherApp.netMaui.View;

public partial class WeatherInfoPage : ContentPage
{
	public WeatherInfoPage()
	{
		InitializeComponent();
		BindingContext = new WeatherInfoViewModel();
	}
}
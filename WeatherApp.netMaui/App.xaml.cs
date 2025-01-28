using WeatherApp.netMaui.View;

namespace WeatherApp.netMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherInfoPage();
        }
    }
}

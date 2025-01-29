using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.netMaui.Model
{
	public class ResponseModel
	{
		[JsonPropertyName("location")]
		public ResponseModelLocation location { get; set; }

		[JsonPropertyName("current")]
		public ResponseModelCurrent current { get; set; }
	}


	public class ResponseModelLocation
	{
		public string name { get; set; }
		public string country { get; set; }
	}

	public class ResponseModelCurrent
	{
		public string observation_time { get; set; }
		public int temperature { get; set; }
		public string[] weather_icons { get; set; }
		public string[] weather_descriptions { get; set; }
		public int wind_speed { get; set; }
		public int humidity { get; set; }
		public int feelslike { get; set; }
		public int uv_index { get; set; }
		
	}



}

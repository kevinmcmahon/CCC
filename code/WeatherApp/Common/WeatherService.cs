using System;
using System.Text;

namespace Common.WeatherWebService
{
	public class WeatherService
	{
		WeatherForecast ws;
		
		public WeatherService ()
		{
			ws = new WeatherWebService.WeatherForecast("http://www.webservicex.net/WeatherForecast.asmx");
		}
		
		public WeatherForecasts GetForecasts(string zipCode)
        {
			WeatherForecasts forecast = null;
			
            try
            {
				forecast = ws.GetWeatherByZipCode(zipCode);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Calling WS : {0}\n\n{1}", e.Message, e.InnerException);
            }
			
			return forecast;
		}
	}
	
	public static class Extensions 
	{
		public static string ToDisplayString(this Common.WeatherWebService.WeatherForecasts forecast)
		{
			StringBuilder sb = new StringBuilder();
			foreach(var wd in forecast.Details)
			{
				sb.AppendLine(string.Format("{0} HI: {1} LO:{2}", wd.Day, wd.MaxTemperatureF, wd.MinTemperatureF));
			}
			
            return sb.ToString();
		}
	}
}


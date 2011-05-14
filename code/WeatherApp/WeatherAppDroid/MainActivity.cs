using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Common.WeatherWebService;

namespace WeatherAppDroid
{
	public static class Constants
    {
        public static string LOGTAG = "WeatherDroidApp";
    }

	[Activity (Label = "WeatherApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 0;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Log.Verbose(Constants.LOGTAG, "MainActivity onCreate");
			
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			
            var responseText = FindViewById<TextView>(Resource.Id.response);
            var statusText = FindViewById<TextView>(Resource.Id.status);
            var button = FindViewById<Button>(Resource.Id.MyButton);
		
			var weatherService = new Common.WeatherWebService.WeatherService();
			
            button.Click += (sender, args) =>
                                {
                                    count++;
                                    statusText.Text = string.Format("Requests Issued : {0}", count);
									responseText.Text = "Waiting for data";
									
									Log.Verbose(Constants.LOGTAG,"Calling Weather Web");                                    
                                    System.Threading.ThreadPool.QueueUserWorkItem(delegate
                                                                     {
																		var forecast = weatherService.GetForecasts("60614");
																		RunOnUiThread(() =>{ responseText.Text = forecast.ToDisplayString(); });
                                                                     });
                                };
		}
	}
}



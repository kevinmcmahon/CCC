using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Common.WeatherWebService;

namespace WeatherAppTouch
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
	
	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		int count = 0;
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			var weatherService = new Common.WeatherWebService.WeatherService();
			resultText.Text = "";
			countText.Text = "";
			
			button.TouchDown += (sender, e) => {
				countText.Text = string.Format("Requests made : {0}",++count);
				var forecasts = weatherService.GetForecasts("60614");
				resultText.Text = forecasts.ToDisplayString();
			};
			
			window.MakeKeyAndVisible ();
	
			return true;
		}
	
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}


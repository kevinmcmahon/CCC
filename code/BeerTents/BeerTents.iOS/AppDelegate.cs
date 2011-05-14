using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace BeerTents.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UINavigationController navController;
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			TentsViewController tvc = new TentsViewController();
		 	navController = new UINavigationController();
			navController.PushViewController(tvc, false);
			navController.NavigationBar.BarStyle = UIBarStyle.Black;
			navController.TopViewController.Title = "Tents";
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			window.AddSubview (navController.View);
			window.MakeKeyAndVisible ();
			
			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
		
		/*
		public override void WillTerminate (UIApplication application)
		{
			//Save data here
		}
		*/
	}
}


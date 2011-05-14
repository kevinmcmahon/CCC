using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace BeerTents.iOS
{
	public class Application
	{
		static void Main (string[] args)
		{	
			try 
			{
				UIApplication.Main (args,null,"AppDelegate");
			} 
			catch (Exception e)
			{
				Console.WriteLine ("Toplevel exception: {0}", e);
			}
		}
	}
}


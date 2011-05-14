
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace BeerTents.iOS 
{
	public partial class TentCellController : UIViewController
	{
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public TentCellController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public TentCellController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public TentCellController () : base("TentCellController", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
		
		public string TentName 
		{
			get { return name.Text; }
			set { name.Text = value; }
		}
		
		public string Brewery
		{
			get { return brewery.Text; }
			set { brewery.Text = value; }
		}
		
		public UITableViewCell Cell
		{
			get { return cell; }
		}
	}
}


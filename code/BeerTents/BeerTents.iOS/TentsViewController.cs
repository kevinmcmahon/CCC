
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using BeerTents.Common;
namespace BeerTents.iOS
{
	[Register("TentsViewController")]
	public class TentsViewController : UIViewController
	{
		UIImageView _imageView;
		UITableView _tableView;
		List<Tent> _tents;
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			if(_tents == null)
			{
				_tents = new TentInfoRepository("tents.xml").GetAll();
			}
			
			_tableView = new UITableView
							{
								Delegate = new TableViewDelegate(this, _tents),
							    DataSource = new TableViewDataSource(_tents),
							    AutoresizingMask = UIViewAutoresizing.FlexibleHeight|
							                       UIViewAutoresizing.FlexibleWidth,
							    BackgroundColor = UIColor.White,
								ScrollEnabled = true, 
								Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height)
							};
			
			_tableView.SizeToFit();
			this.View.AddSubview(_tableView);
		}			
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
				
			var selection = _tableView.IndexPathForSelectedRow;
			if(selection != null)
				_tableView.DeselectRow(selection,true);
		}
		
		public override string ToString ()
		{
			return "Tent Information";
		}
		
        private class TableViewDelegate : UITableViewDelegate
        {
			TentsViewController _tvc;
			List<Tent> _tents;
			
            public TableViewDelegate(TentsViewController controller, List<Tent> tents)
            {
				_tvc = controller;
				_tents = tents;
            }

			/// <summary>
			/// If there are subsections in the hierarchy, navigate to those
			/// ASSUMES there are _never_ Categories hanging off the root in the hierarchy
			/// </summary>
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
            {	
				var tent = _tents[indexPath.Row];
				Console.WriteLine("TentsViewController:TableViewDelegate.RowSelected: Label={0}",tent.Name);	
				var details = new TentDetailViewController(tent);
				details.Title = tent.Name;
				_tvc.NavigationController.PushViewController(details, true);
			}
        }

        private class TableViewDataSource : UITableViewDataSource
        {
            static NSString kCellIdentifier = new NSString ("MyEventIdentifier");

			List<Tent> _tents;
			Dictionary<int, TentCellController> controllers = null;
			Random r;
			
            public TableViewDataSource(List<Tent> tents)
            {
				r = new Random();
				_tents = tents;
				controllers = new Dictionary<int, TentCellController>();
            }

            public override int RowsInSection (UITableView tableview, int section)
            {
                return _tents.Count;
            }

            public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
            {
				UITableViewCell cell = tableView.DequeueReusableCell (kCellIdentifier);
				
				var tent = _tents[indexPath.Row];
				
				TentCellController cellController = null;
				
				if (cell == null)
				{
					cellController = new TentCellController();
					NSBundle.MainBundle.LoadNib("TentCellController", cellController, null);
					cell = cellController.Cell;
					cell.Tag = r.Next();
					controllers.Add(cell.Tag, cellController);			
				}
				else
				{
					cellController = controllers[cell.Tag];
				}
			
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				
				try
				{
					cellController.TentName = tent.Name;
					cellController.Brewery = tent.Brewery;
				}
				catch (Exception){}
				
				return cell;
            }
        }
	}
}

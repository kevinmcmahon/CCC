using System;
using System.Xml.Linq;
using System.IO;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Util;
using Android.Widget;
using Android.OS;
using BeerTents.Common;

namespace BeerTents.Android
{
	public static class Constants 
	{
		public static string LOGTAG = "BeerTents";
		public static string INTENT_TENT_DETAIL = "com.example.TENTDETAIL";
		public static string TENT_EXTRA = "com.example.TentExtra";
	}
	
	[Activity (Label = "BeerTents", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		TentAdapter adapter;
	
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			adapter = new TentAdapter(this, Resource.Layout.list_item, GetTents());
			this.ListAdapter = adapter;
		}
		
		private Tent[] GetTents()
		{
			TextReader reader;
			
			using(var rawstream = Resources.OpenRawResource(Resource.Raw.tents))
			{
				reader = new StreamReader(rawstream);
			}
			return new BeerTents.Common.TentInfoRepository(reader).GetAll().ToArray();
		}
		
		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{	
			Tent tent = null;
			
			try
			{
				tent = adapter.GetItemAtPosition(position);
			}
			catch (Exception e) 
			{
				Log.Error(Constants.LOGTAG, "items from adapter blew up", e);
			}
			
			((BeerTentApplication)Application).SelectedTent = tent;
			
	        // startFrom page is not stored in application, for example purposes it's a simple "extra"
	        Intent intent = new Intent(Constants.INTENT_TENT_DETAIL);
	        StartActivity(intent);
	    }
	}
	
	[Application]
	public class BeerTentApplication : Application
	{
		public BeerTentApplication(IntPtr handle) : base(handle) {}
		
		public Tent SelectedTent { get; set; }
	}
}
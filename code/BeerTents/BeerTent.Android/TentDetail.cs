using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BeerTents.Common;

namespace BeerTents.Android
{
	[Activity(Label="Tent Detail")]
	[IntentFilter(new[] {"com.example.TENTDETAIL"}, Categories=new[]{Intent.CategoryDefault})]
	public class TentDetail : Activity
	{
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.tentdetail);
			
			var tent = ((BeerTentApplication) this.Application).SelectedTent;
			
			var brewery = FindViewById<TextView>(Resource.Id.brewery);
			brewery.Text = tent.Brewery;
			
			var prop = FindViewById<TextView>(Resource.Id.prop);
			prop.Text = tent.Proprietor;
			
			var phone = FindViewById<TextView>(Resource.Id.phone);
			phone.Text = tent.PhoneNumber;
			
			var web = FindViewById<TextView>(Resource.Id.web);
			web.Text = tent.Url;
		}
	}
}


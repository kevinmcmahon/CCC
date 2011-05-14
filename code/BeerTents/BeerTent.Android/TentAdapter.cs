using System;

using Android.Content;
using Android.Views;
using Android.Widget;
using BeerTents.Common;

namespace BeerTents.Android
{
	public class TentAdapter : ArrayAdapter
	{
		private BeerTents.Common.Tent[] _tents;
		
		public TentAdapter(Context context, int textViewResourceId, Tent[] objects) : base (context, textViewResourceId, objects)
		{
			_tents = objects;
		}
		
		public override View GetView (int position, View convertView, ViewGroup parent)
		{	
			View v = convertView;
	
			if (v == null) {
	            LayoutInflater vi = (LayoutInflater) this.Context.GetSystemService(Context.LayoutInflaterService);
	            v = vi.Inflate(Resource.Layout.list_item, null);
	        }
	        Tent tent = _tents[position];
	        
	        if (tent != null)
			{
	            TextView tt = v.FindViewById<TextView>(Resource.Id.toptext);
	            TextView bt = v.FindViewById<TextView>(Resource.Id.bottomtext);
	            
				if (tt != null)
				{
					tt.Text = tent.Name;
	            }
					
	            if(bt != null)
				{
	            	bt.Text = tent.Brewery;
	            }
	        }
	        
			return v;
		}
		
		public Tent GetItemAtPosition (int position)
		{
			return _tents[position];
		}
	}
}
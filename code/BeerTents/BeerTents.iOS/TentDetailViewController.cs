using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MessageUI;
using BeerTents.Common;

namespace BeerTents.iOS
{
	[Register("TentDetailViewController")]
	public class TentDetailViewController : UIViewController
	{
		Tent _tent;
		UIWebView _web;
		
		public TentDetailViewController(Tent tent)
		{
			_tent = tent;
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			_web = new UIWebView {
				ScalesPageToFit = false,
				Opaque = false,
				BackgroundColor = UIColor.White,
				MultipleTouchEnabled = true,
				Frame = new RectangleF(0, 0, this.View.Frame.Width, this.View.Frame.Height-80),
			};
			
			_web.Delegate = new WebViewDelegate();
			
			_web.SizeToFit();
			
			this.View.AddSubview(_web);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			_web.LoadHtmlString(FormatText(), new NSUrl()); 
		}
		
		string FormatText()
		{	
			StringBuilder sb = new StringBuilder();
			sb.Append("<html><head><style>" +
				"body,b,i,p,h2{font-family:Helvetica; font-size:18px}" +
				"h1,h2{color:#599EF1;}" +
				"a{color:#333333;}" +
				"</style></head><body>");
			
			if(!string.IsNullOrEmpty(_tent.Brewery))
			{ 
				sb.Append("<div>");
				sb.Append(string.Format("<b style='color:#666666'>Brewery</b><br/>"));
				sb.Append(string.Format("{0}<br/>{1}",_tent.Brewery,Environment.NewLine));
				sb.Append("</div>");
			}
			
			
			if(!string.IsNullOrEmpty(_tent.Proprietor))
			{ 
				sb.Append("<div>");
				sb.Append(string.Format("<br/><b style='color:#666666'>Proprietor(s)</b><br/>"));
				sb.Append(string.Format("{0}<br/>{1}",_tent.Proprietor,Environment.NewLine));
				sb.Append("</div>");
			}
			
			sb.Append("<div>");
			if(!string.IsNullOrEmpty(_tent.PhoneNumber))
			{
				sb.Append("<br/><b style='color:#666666'>Phone</b><br/>");
				sb.Append(string.Format("<a href='tel://{0}'>{0}</a><br/>{1}", 
			                        _tent.PhoneNumber, Environment.NewLine));
			}
			if (!string.IsNullOrEmpty(_tent.FaxNumber))
			{
				sb.Append("<br/><b style='color:#666666'>Fax</b><br/>");
				sb.Append(string.Format("{0}{1}<br/>", _tent.FaxNumber, Environment.NewLine));
			}
			
			if(!string.IsNullOrEmpty(_tent.Url))
			{
				sb.Append(string.Format("<br/><a href='{0}'>Website</a><br/>{1}", _tent.Url, Environment.NewLine));
			}
			
			sb.Append("</div>");
			
			if(!string.IsNullOrEmpty(_tent.SeatingInside) || !string.IsNullOrEmpty(_tent.SeatingOutside))
			{
				sb.Append("<div>");
				sb.Append("<br/><b style='color:#666666;'>Seating</b><br/>");
				if(!string.IsNullOrEmpty(_tent.SeatingInside))
					sb.Append(string.Format("Inside : {0}{1}<br/>",_tent.SeatingInside,Environment.NewLine));
				if(!string.IsNullOrEmpty(_tent.SeatingOutside))
					sb.Append(string.Format("Outside : {0}{1}<br/>",_tent.SeatingOutside,Environment.NewLine));
				sb.Append("</div>");	
			}
			
			if(!string.IsNullOrEmpty(_tent.Music))
			{
				sb.Append("<div>");
				sb.Append(string.Format("<br/><b style='color:#666666;'>Music</b><br/>{0}{1}<br/>",_tent.Music,Environment.NewLine));
				sb.Append("</div>");
			}
			if(!string.IsNullOrEmpty(_tent.Notes))
			{
				sb.Append("<div>");
				sb.Append(string.Format("<br/><b style='color:#666666;'>Notes</b><br/>{0}{1}<br/>",_tent.Notes,Environment.NewLine));
				sb.Append("</div>");
			}
			
			sb.Append("</body></html>");
			
			return sb.ToString();
		}
	}
	
	public class WebViewDelegate : UIWebViewDelegate
	{
		static bool NetworkActivity {
			set {
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = value;
			}
		}
		
		public override void LoadStarted (UIWebView webView)
		{	
			NetworkActivity = true;
		}
		
		public override void LoadingFinished (UIWebView webView)
		{
			NetworkActivity = false;
		}
		
		public override void LoadFailed (UIWebView webView, NSError error)
		{
			NetworkActivity = false;
			if (webView != null)
				webView.LoadHtmlString (String.Format ("<html><center><font size=+5 color='red'>An error occurred:<br>{0}</font></center></html>", error.LocalizedDescription), null);
		}
		
		public override bool ShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
		{
			if (request.Url.Scheme.Equals("mailto"))
			{
				UIApplication.SharedApplication.OpenUrl(request.Url);
				// don't load url in this webview
				return false;
			}
		
			return true;
		}
	}
}


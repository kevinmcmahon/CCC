// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace WeatherAppTouch {
	
	
	// Base type probably should be MonoTouch.Foundation.NSObject or subclass
	[MonoTouch.Foundation.Register("AppDelegate")]
	public partial class AppDelegate {
		
		private MonoTouch.UIKit.UIWindow __mt_window;
		
		private MonoTouch.UIKit.UIButton __mt_button;
		
		private MonoTouch.UIKit.UILabel __mt_countText;
		
		private MonoTouch.UIKit.UITextView __mt_resultText;
		
		#pragma warning disable 0169
		[MonoTouch.Foundation.Connect("window")]
		private MonoTouch.UIKit.UIWindow window {
			get {
				this.__mt_window = ((MonoTouch.UIKit.UIWindow)(this.GetNativeField("window")));
				return this.__mt_window;
			}
			set {
				this.__mt_window = value;
				this.SetNativeField("window", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("button")]
		private MonoTouch.UIKit.UIButton button {
			get {
				this.__mt_button = ((MonoTouch.UIKit.UIButton)(this.GetNativeField("button")));
				return this.__mt_button;
			}
			set {
				this.__mt_button = value;
				this.SetNativeField("button", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("countText")]
		private MonoTouch.UIKit.UILabel countText {
			get {
				this.__mt_countText = ((MonoTouch.UIKit.UILabel)(this.GetNativeField("countText")));
				return this.__mt_countText;
			}
			set {
				this.__mt_countText = value;
				this.SetNativeField("countText", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("resultText")]
		private MonoTouch.UIKit.UITextView resultText {
			get {
				this.__mt_resultText = ((MonoTouch.UIKit.UITextView)(this.GetNativeField("resultText")));
				return this.__mt_resultText;
			}
			set {
				this.__mt_resultText = value;
				this.SetNativeField("resultText", value);
			}
		}
	}
}
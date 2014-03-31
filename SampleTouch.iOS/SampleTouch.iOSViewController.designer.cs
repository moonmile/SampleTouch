// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SampleTouch.iOS
{
	[Register ("SampleTouch_iOSViewController")]
	partial class SampleTouch_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView image1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView image2 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (image1 != null) {
				image1.Dispose ();
				image1 = null;
			}

			if (image2 != null) {
				image2.Dispose ();
				image2 = null;
			}
		}
	}
}

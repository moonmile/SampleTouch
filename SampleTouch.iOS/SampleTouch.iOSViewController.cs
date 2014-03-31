using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace SampleTouch.iOS
{
	public partial class SampleTouch_iOSViewController : UIViewController
	{
		public SampleTouch_iOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		List <UIImageView> drags;

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			drags = new List<UIImageView> ();
			drags.Add (this.image2);
			drags.Add (this.image1);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

		UIImageView dragItem = null;
        /// <summary>
        /// タッチ開始
        /// </summary>
        /// <param name="touches"></param>
        /// <param name="evt"></param>
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

			UITouch touch = touches.AnyObject as UITouch;

			foreach (var el in this.drags) {
				if (el.Frame.Contains (touch.LocationInView (View))) {
					this.dragItem = el;
					break;
				}
			}
        }
        /// <summary>
        /// タッチ移動
        /// </summary>
        /// <param name="touches"></param>
        /// <param name="evt"></param>
        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			PointF newPoint = touch.LocationInView(View);
			PointF previousPoint = touch.PreviousLocationInView(View);
			if (dragItem != null ) {
				float offsetX = previousPoint.X - newPoint.X;
				float offsetY = previousPoint.Y - newPoint.Y;
				dragItem.Frame = new RectangleF (
					new PointF (dragItem.Frame.X - offsetX, dragItem.Frame.Y - offsetY),
					dragItem.Frame.Size);
			}
        }

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);
			dragItem = null;
		}
    }
}


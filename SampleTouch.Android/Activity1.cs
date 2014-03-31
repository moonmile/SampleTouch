using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SampleTouch.Android
{
    [Activity(Label = "SampleTouch.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        ImageView iv1, iv2;
        TextView text1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            this.iv1 = FindViewById<ImageView>(Resource.Id.imageView1);
            this.iv2 = FindViewById<ImageView>(Resource.Id.imageView2);
            this.iv1.SetImageResource(Resource.Drawable.MarkBlue);
            this.iv2.SetImageResource(Resource.Drawable.MarkBlue);
            this.text1 = FindViewById<TextView>(Resource.Id.textView1);
            iv1.Touch += iv1_Touch;
            iv2.Touch += iv1_Touch;
        }

        bool moveFlag = false;
        float _sx, _sy;
        void iv1_Touch(object sender, View.TouchEventArgs e)
        {
            var el = sender as ImageView;
            if (el == null) return;

            float x = e.Event.RawX;
            float y = e.Event.RawY;

            switch (e.Event.Action)
            {
            case MotionEventActions.Down:
                _sx = x - el.Left;
                _sy = y - el.Top;
                moveFlag = true;
                break;
            case MotionEventActions.Move:
                if (moveFlag)
                {
                    int left = (int)(x - _sx);
                    int top = (int)(y - _sy);
                    el.Layout(left, top,
                        left + el.Width,
                        top + el.Height);
                }
                break;  
            case MotionEventActions.Up:
                moveFlag = false;
                break;
            }
        }
    }
}


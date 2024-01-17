using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanApp
{
    [Activity(Label = "FlagsActivity")]
    public class FlagsActivity : Activity
    {
        private ImageView img;
        private int step = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.flags);
            FindViewById<Button>(Resource.Id.changeBtn).Click += FlagChange_Click;
            img = FindViewById<ImageView>(Resource.Id.flagImg);
            FindViewById<Button>(Resource.Id.backBtn).Click += FlagsActivity_Click;
        }

        private void FlagsActivity_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(HomeActivity));
            StartActivity(intent);
        }

        private void FlagChange_Click(object sender, EventArgs e)
        {
            step++;
            if (step >= 4)
                step = 0;
            switch (step)
            {
                case 0:
                    img.SetImageResource(Resource.Drawable.canada);
                    break;
                case 1:
                    img.SetImageResource(Resource.Drawable.usa);
                    break;
                case 2:
                    img.SetImageResource(Resource.Drawable.spain);
                    break;
                case 3:
                    img.SetImageResource(Resource.Drawable.israel);
                    break;
            }
        }
    }
}
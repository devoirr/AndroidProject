using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace RomanApp
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        private ImageView img;
        private int step = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.homepage);
            FindViewById<TextView>(Resource.Id.welcomeTextView).Text = "Welcome, " + Intent.GetStringExtra("username");

            FindViewById<Button>(Resource.Id.flagsBtn).Click += Flags_Click;
            FindViewById<Button>(Resource.Id.cameraBtn).Click += Camera_Click;
            FindViewById<Button>(Resource.Id.triviaBtn).Click += Trivia_Click; ;
            FindViewById<Button>(Resource.Id.reservationBtn).Click += Reservation_Click;
        }

        private void Trivia_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Camera_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Reservation_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ReservationActivity));
            StartActivity(intent);
        }

        private void Flags_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FlagsActivity));
            StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home_options, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_flags)
            {
                Intent intent = new Intent(this, typeof(FlagsActivity));
                StartActivity(intent);
                return true;

            }
            else if (item.ItemId == Resource.Id.action_reservation)
            {
                Intent intent = new Intent(this, typeof(ReservationActivity));
                StartActivity(intent);
                return true;
            }
            return base.OnOptionsItemSelected(item);

        }
    }
}
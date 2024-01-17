using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace RomanApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ISharedPreferences sp;
        EditText userNameField, passwordField;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button register = FindViewById<Button>(Resource.Id.registerBtn);
            Button logIn = FindViewById<Button>(Resource.Id.loginBtn);

            userNameField = FindViewById<EditText>(Resource.Id.username);
            passwordField = FindViewById<EditText>(Resource.Id.password);

            register.Click += OnRegisterClick;
            logIn.Click += onLogInClick;

            sp = this.GetSharedPreferences("details", FileCreationMode.Private);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void OnRegisterClick(object sender, EventArgs args)
        {
            Intent intent = new Intent(this, typeof(SignUpActivity));
            StartActivity(intent);
        }

        private void onLogInClick(object sender, EventArgs args)
        {
            if (userNameField.Text == null || userNameField.Text == null)
            {
                Toast.MakeText(Application.Context, "Enter username and password!", ToastLength.Short).Show();
                return;
            }
            string username = sp.GetString("username", "");
            string pass = sp.GetString("password", "");
            if (username != "" && username == userNameField.Text && pass != "" && passwordField.Text == pass)
            {
                Toast.MakeText(Application.Context, "Success!", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(HomeActivity));
                intent.PutExtra("username", username);
                StartActivity(intent);
            } else
            {
                Toast.MakeText(Application.Context, "Wrong!", ToastLength.Short).Show();
            }
        }
    }
}
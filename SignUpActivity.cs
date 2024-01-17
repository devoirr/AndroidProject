using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace RomanApp
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {
        private EditText email, username, password, passwordConfirm;
        private ISharedPreferences sp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.signup1);
            FindViewById<Button>(Resource.Id.loginBtn).Click += Finish_Click;
            FindViewById<Button>(Resource.Id.backBtn).Click += SignUpActivity_Click;

            email = FindViewById<EditText>(Resource.Id.email);
            username = FindViewById<EditText>(Resource.Id.username);
            password = FindViewById<EditText>(Resource.Id.password);
            passwordConfirm = FindViewById<EditText>(Resource.Id.passwordConfirm);

            sp = this.GetSharedPreferences("details", FileCreationMode.Private);
        }

        private void SignUpActivity_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void Finish_Click(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(passwordConfirm.Text))
            {
                Toast.MakeText(Application.Context, "You didn't enter all the fields.", ToastLength.Short).Show();
            } else if (password.Text != passwordConfirm.Text)
            {
                Toast.MakeText(Application.Context, "Passwords are different.", ToastLength.Short).Show();
            } else
            {
                Toast.MakeText(Application.Context, "Success!", ToastLength.Short).Show();
                ISharedPreferencesEditor editor = sp.Edit();
                editor.PutString("username", username.Text);
                editor.PutString("password", password.Text);
                editor.Commit();

                Intent intent = new Intent(this, typeof(HomeActivity));
                StartActivity(intent);
            }
        }

    }
}
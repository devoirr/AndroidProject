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
    [Activity(Label = "ReservationActivity")]
    public class ReservationActivity : Activity
    {
        private Button date, time, save, about;
        private EditText name, amount;
        private TextView dateView, timeView;
        private AlertDialog d;
        private Dialog dialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.reservation);

            date = FindViewById<Button>(Resource.Id.dateBtn);
            time = FindViewById<Button>(Resource.Id.timeBtn);
            save = FindViewById<Button>(Resource.Id.saveBtn);
            about = FindViewById<Button>(Resource.Id.aboutBtn);

            name = FindViewById<EditText>(Resource.Id.nameEditText);
            amount = FindViewById<EditText>(Resource.Id.amountEditText);

            dateView = FindViewById<TextView>(Resource.Id.dateView);
            timeView = FindViewById<TextView>(Resource.Id.timeView);

            date.Click += Date_Click;
            time.Click += Time_Click;

            save.Click += Save_Click;
            about.Click += About_Click;
        }

        private void About_Click(object sender, EventArgs e)
        {
            CreateCustomDialog();
        }

        private void CreateCustomDialog()
        {
            dialog = new Dialog(this);
            dialog.SetContentView(Resource.Layout.customdialog);
            dialog.FindViewById<Button>(Resource.Id.closeBtn).Click += CloseBtnClickInDialog;
            dialog.Show();
        }

        private void CloseBtnClickInDialog(object sender, EventArgs e)
        {
            dialog.Dismiss();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Summary:");
            builder.SetMessage("Saved reservation to " + dateView.Text + " on " + timeView.Text);
            builder.SetPositiveButton("OK", okaction);
            builder.SetNegativeButton("Cancel", cancelaction);
            d = builder.Create();
            d.Show();
        }

        private void cancelaction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "your reservation is cancelled", ToastLength.Short).Show();
        }

        private void okaction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "Your reservation is saved", ToastLength.Long).Show();
            Finish();
        }

        private void Time_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Today;
            TimePickerDialog picktime = new TimePickerDialog(this, onTimeSet, time.Hour, time.Minute, true);
            picktime.Show();
        }

        private void Date_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            DatePickerDialog datedialog = new DatePickerDialog(this, OnDateSet, date.Year, date.Month - 1, date.Day);
            datedialog.Show();
        }

        private void onTimeSet(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            if (e.Minute < 10)
            {
                timeView.Text = e.HourOfDay.ToString() + ":0" + e.Minute;
            }
            else
            {
                timeView.Text = e.HourOfDay.ToString() + ":" + e.Minute;
            }
        }

        private void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            dateView.Text = e.Date.ToShortDateString();
        }
    }
}
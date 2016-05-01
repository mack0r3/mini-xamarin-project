using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MiNI___Xamarin_Project
{
    [Activity(Label = "Initial Activity", MainLauncher = true)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button LoginButton = FindViewById<Button>(Resource.Id.Main_LoginButton);
            LoginButton.Click += LoginButton_Click;


            Button RegisterButton = FindViewById<Button>(Resource.Id.Main_RegisterButton);
            RegisterButton.Click += RegisterButton_Click;

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }

     
    }
}


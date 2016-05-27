using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using MiNI___Xamarin_Project.Services;
using RestSharp;
using MiNI___Xamarin_Project.Interfaces;

namespace MiNI___Xamarin_Project
{
    [Activity(Label = "MenuActivity", Theme = "@style/AppBaseTheme", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class MenuActivity : AppCompatActivity
    {
        IApiService mApiService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuActivity_Layout);

            mApiService = new ApiService();



            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;

            

        }

        private void Button_Click(object sender, EventArgs e)
        {
            List<string> labels = mApiService.TestRequest();

            TextView text1 = FindViewById<TextView>(Resource.Id.textView1);
            TextView text2 = FindViewById<TextView>(Resource.Id.textView2);
            TextView text3 = FindViewById<TextView>(Resource.Id.textView3);


            text1.Text = labels[0];
            text2.Text = labels[1];
            text3.Text = labels[2];

        }
    }
}
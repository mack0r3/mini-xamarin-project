using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using System;
using RestSharp;
using MiNI___Xamarin_Project.Services;

namespace MiNI___Xamarin_Project
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppBaseTheme", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class LoginActivity : AppCompatActivity
    {
        LoginService mLoginService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginActivity_Layout);

            Button backButton = FindViewById<Button>(Resource.Id.backLoginButton);
            backButton.Click += Button_Click;

            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += LoginButton_Click;


            
        }
        
        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            string username = FindViewById<TextInputLayout>(Resource.Id.usernameLoginTextInputLayout).EditText.Text;
            string password = FindViewById<TextInputLayout>(Resource.Id.passwordLoginTextInputLayout).EditText.Text;

            mLoginService = new LoginService(username, password);

            try
            {
                mLoginService.Login();
                Console.WriteLine("Logowanie zakonczylo sie wynikiem pozytywnym");
                Finish();
                StartActivity(typeof(MenuActivity));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Finish();
        }
    }
}
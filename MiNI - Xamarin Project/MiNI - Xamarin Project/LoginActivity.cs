using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace MiNI___Xamarin_Project
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppBaseTheme", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginActivity_Layout);

            Button button = FindViewById<Button>(Resource.Id.backButton);
            button.Click += Button_Click;
            
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Finish();
        }
    }
}
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
using Android.Support.Design.Widget;

namespace MiNI___Xamarin_Project
{
    [Activity(Label = "RegisterActivity", Theme = "@style/AppBaseTheme", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class RegisterActivity : AppCompatActivity
    {
        private Button RegisterButton;

        private TextInputLayout FirstNameInput;
        private TextInputLayout LastNameInput;
        private TextInputLayout EmailInput;
        private TextInputLayout PasswordInput;
        private TextInputLayout ConfirmPasswordInput;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterActivity_Layout);

            RegisterButton = FindViewById<Button>(Resource.Id.registerButton);
            RegisterButton.Click += RegisterButton_Click;

            FirstNameInput = FindViewById<TextInputLayout>(Resource.Id.firstNameTextInputLayout);
            LastNameInput = FindViewById<TextInputLayout>(Resource.Id.lastNameTextInputLayout);
            EmailInput = FindViewById<TextInputLayout>(Resource.Id.emailTextInputLayout);
            PasswordInput = FindViewById<TextInputLayout>(Resource.Id.passwordTextInputLayout);
            ConfirmPasswordInput = FindViewById<TextInputLayout>(Resource.Id.confirmPasswordTextInputLayout);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            FirstNameInput.Error = "This field is required.";
            LastNameInput.Error = "This field is required.";
            EmailInput.Error = "This field is required.";
            PasswordInput.Error = "This field is required.";
            ConfirmPasswordInput.Error = "This field is required.";
        }
    }
}
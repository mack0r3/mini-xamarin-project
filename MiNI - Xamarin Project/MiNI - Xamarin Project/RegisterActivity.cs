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
using MiNI___Xamarin_Project.Validator;

namespace MiNI___Xamarin_Project
{
    [Activity(Label = "RegisterActivity", Theme = "@style/AppBaseTheme", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class RegisterActivity : AppCompatActivity
    {
        private TextInputLayout mFirstNameField;
        private TextInputLayout mLastNameField;
        private TextInputLayout mEmailField;
        private TextInputLayout mPasswordField;
        private TextInputLayout mConfirmPasswordField;

        private Form mForm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterActivity_Layout);
            initializeFields();

            Field field = new Field(mFirstNameField);
            mForm.AddField(field);
        }

        private void initializeFields()
        {
            mFirstNameField = FindViewById<TextInputLayout>(Resource.Id.firstNameField);
            mLastNameField = FindViewById<TextInputLayout>(Resource.Id.lastNameField);
            mEmailField = FindViewById<TextInputLayout>(Resource.Id.emailField);
            mPasswordField = FindViewById<TextInputLayout>(Resource.Id.passwordField);
            mConfirmPasswordField = FindViewById<TextInputLayout>(Resource.Id.confirmPasswordField);
        }

    }
}
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
using MiNI___Xamarin_Project.Validator.validations;

namespace MiNI___Xamarin_Project
{
    [Activity(Label = "RegisterActivity", Theme = "@style/AppBaseTheme", WindowSoftInputMode = SoftInput.AdjustResize)]
    public class RegisterActivity : AppCompatActivity
    {
        private EditText mFirstNameEditText;
        private EditText mLastNameEditText;
        private EditText mEmailEditText;
        private EditText mPasswordEditText;
        private EditText mConfirmPasswordEditText;

        private Form mForm;

        private Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterActivity_Layout);

            initializeEditTexts();
            initializeForm();
            handleLostFocusEvent();


            button = FindViewById<Button>(Resource.Id.registerButton);
            button.Click += Button_Click;
        }

        private void handleLostFocusEvent()
        {
            foreach(Field field in mForm.GetFields())
            {
                TextInputLayout input = (TextInputLayout)field.GetEditText().Parent;
                field.GetEditText().FocusChange += (sender, e) => {
                    if(!e.HasFocus)
                    {
                        
                        try
                        {
                            if(field.IsValid())
                            {
                                Console.WriteLine("Dobrze posz³o");
                                input.ErrorEnabled = false;
                                input.Error = null;
                            }
                        }
                        catch (FieldValidationException ex)
                        {
                            input.Error = ex.Message;
                        }
                    }
                };
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            if (mForm.IsValid()) Console.WriteLine("Register completed!");
        }

        private void initializeEditTexts()
        {
            mFirstNameEditText = FindViewById<EditText>(Resource.Id.firstNameEditText);
            mLastNameEditText = FindViewById<EditText>(Resource.Id.lastNameEditText);
            mEmailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            mPasswordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            mConfirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
        }

        private void initializeForm()
        {
            Field firstNameField = new Field(mFirstNameEditText);
            Field lastNameField = new Field(mLastNameEditText);
            Field emailField = new Field(mEmailEditText);
            Field passwordField = new Field(mPasswordEditText);
            Field confirmPasswordField = new Field(mConfirmPasswordEditText);

            firstNameField.Validate(new NotEmpty(this));
            lastNameField.Validate(new NotEmpty(this));
            emailField.Validate(new NotEmpty(this));
            passwordField.Validate(new NotEmpty(this));
            confirmPasswordField.Validate(new NotEmpty(this));

            mForm = new Form();

            mForm.AddField(firstNameField);
            mForm.AddField(lastNameField);
            mForm.AddField(emailField);
            mForm.AddField(passwordField);
            mForm.AddField(confirmPasswordField);
        }

    }
}
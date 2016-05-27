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
using RestSharp;
using MiNI___Xamarin_Project.Services;
using MiNI___Xamarin_Project.DTO;

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

        private Button mRegisterButton;
        private Button mBackButton;

        private RegisterService mRegisterService;
        private LoginService mLoginService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegisterActivity_Layout);

            initializeEditTexts();
            initializeForm();
            handleLostFocusEvent();
            
            mRegisterService = new RegisterService();

            mRegisterButton = FindViewById<Button>(Resource.Id.registerButton);
            mRegisterButton.Click += mRegisterButton_Click;

            mBackButton = FindViewById<Button>(Resource.Id.backRegisterButton);
            mBackButton.Click += mBackButton_Click;
        }

        
        private void handleLostFocusEvent()
        {
            foreach (Field field in mForm.GetFields())
            {
                TextInputLayout input = (TextInputLayout)field.GetEditText().Parent;
                field.GetEditText().FocusChange += (sender, e) =>
                {
                    if (!e.HasFocus)
                    {

                        try
                        {
                            if (field.IsValid())
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


        private void mRegisterButton_Click(object sender, EventArgs e)
        {
            if (mForm.IsValid())
            {
                string email = mEmailEditText.Text;
                string password = mPasswordEditText.Text;

                RegistrationDTO regDTO = new RegistrationDTO { Email = email, Password = password };
                try
                {
                    mRegisterService.Register(regDTO);
                    Console.WriteLine("Rejestracja zakonczyla sie wynikiem pozytywnym");

                    mLoginService = new LoginService(email, password);
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

        }

        private void mBackButton_Click(object sender, EventArgs e)
        {
            Finish();
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
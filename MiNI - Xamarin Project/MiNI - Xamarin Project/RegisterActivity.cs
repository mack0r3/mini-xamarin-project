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
using Android.Views.InputMethods;

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
            handleLostFocusEvents();
            
            mRegisterService = new RegisterService();

			initializeButtons();
			handleClickEvents();



			handleFinishEditing();
		}

		private void handleFinishEditing()
		{
			Field lastField = mForm.GetFields().Last();
			EditText lastEditText = lastField.GetEditText();
			TextInputLayout textInputLayout = (TextInputLayout)lastEditText.Parent;

			lastEditText.EditorAction += (sender, e) =>
			{
				try
				{
					if (lastField.IsValid())
					{
						textInputLayout.Error = null;
						//Set the remaining red underline to blue if succedeed.
						lastEditText.Background.SetColorFilter(Resources.GetColor(Resource.Color.appPrimaryColor), Android.Graphics.PorterDuff.Mode.SrcAtop);
						hideKeyboard();
					}
				}
				catch (FieldValidationException ex)
				{
					textInputLayout.Error = ex.Message;
				}

			};
		}

		private void handleLostFocusEvents()
		{
			foreach (Field field in mForm.GetFields())
			{
				TextInputLayout textInputLayout = (TextInputLayout)field.GetEditText().Parent;
				field.GetEditText().FocusChange += (sender, e) =>
				{
					if (!e.HasFocus)
					{
						try
						{
							if (field.IsValid())
							{
								textInputLayout.Error = null;
								//Set the remaining red underline to blue if succedeed.
								field.GetEditText().Background.SetColorFilter(Resources.GetColor(Resource.Color.appPrimaryColor), Android.Graphics.PorterDuff.Mode.SrcAtop);
							}
						}
						catch (FieldValidationException ex)
						{
							textInputLayout.Error = ex.Message;
						}
					}
				};
			}
		}

		private void handleClickEvents()
		{
			mRegisterButton.Click += mRegisterButton_Click;
			mBackButton.Click += mBackButton_Click;
		}

		private void backButtonOnClick(object sender, EventArgs e)
		{
			Finish();
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
		private void initializeButtons()
		{
			mRegisterButton = FindViewById<Button>(Resource.Id.registerButton);
			mBackButton = FindViewById<Button>(Resource.Id.backRegisterButton);
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
			emailField.Validate(new NotEmpty(this))
				.Validate(new IsEmail(this));
			passwordField.Validate(new NotEmpty(this));
			confirmPasswordField.Validate(new NotEmpty(this))
				.Validate(new IsTheSame(this, mPasswordEditText, mConfirmPasswordEditText));

			mForm = new Form();

			mForm.AddField(firstNameField);
			mForm.AddField(lastNameField);
			mForm.AddField(emailField);
			mForm.AddField(passwordField);
			mForm.AddField(confirmPasswordField);
		}

		private void hideKeyboard()
		{
			InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
			inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
		}

	}
}
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

namespace MiNI___Xamarin_Project.Validator.validations
{
    class IsTheSame : BaseValidation
    {
        private EditText pass;
        private EditText cpass;
        public IsTheSame(Context context, EditText pass, EditText cpass) : base(context)
        {
            this.pass = pass;
            this.cpass = cpass;
        }

        public override string GetErrorMessage()
        {
            return mContext.GetString(Resource.String.passwordsDoNotMatch);
        }

        public override bool IsValid(string text)
        {
            string passText = pass.Text;
            string cpassText = cpass.Text;

            return passText.Equals(cpassText);
        }
    }
}
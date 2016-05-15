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
    class NotEmpty : BaseValidation
    {
        public NotEmpty(Context context) : base(context)
        {
        }

        public override string GetErrorMessage()
        {
            return mContext.GetString(Resource.String.emptyFieldErrorMessage);
        }

        public override bool IsValid(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}
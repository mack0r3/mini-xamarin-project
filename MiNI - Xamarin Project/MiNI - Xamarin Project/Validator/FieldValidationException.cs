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

namespace MiNI___Xamarin_Project.Validator
{
    class FieldValidationException : Exception
    {
        private EditText mEditText;

        public FieldValidationException(string message, EditText editText) : base(message)
        {
            mEditText = editText;
        }

        public EditText GetEditText()
        {
            return mEditText;
        }
    }
}
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
using Android.Support.Design.Widget;

namespace MiNI___Xamarin_Project.Validator
{
    class Field
    {
        private TextInputLayout mEditText;

        public Field(TextInputLayout editText)
        {
            mEditText = editText;
        }
    }
}
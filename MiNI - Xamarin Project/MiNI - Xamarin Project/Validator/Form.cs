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
    class Form
    {
        private List<Field> mFields = new List<Field>();

        public void AddField(Field field)
        {
            mFields.Add(field);
        }

        public bool IsValid()
        {
            bool result = true;
            try
            {
                foreach (Field field in mFields)
                {
                    result &= field.IsValid();
                }
            }
            catch (FieldValidationException ex)
            {
                result = false;
                TextInputLayout textInputLayout = (TextInputLayout)ex.GetEditText().Parent;
                textInputLayout.Error = ex.Message;
            }

            return result;
        }
    }
}
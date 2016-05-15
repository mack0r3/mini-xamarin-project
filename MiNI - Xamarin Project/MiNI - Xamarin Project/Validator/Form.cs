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
    class Form
    {
        private List<Field> mFields = new List<Field>();

        public void AddField(Field field)
        {
            mFields.Add(field);
        }
    }
}
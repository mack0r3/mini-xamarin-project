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
	abstract class BaseValidation : IValidation
	{
		protected Context mContext;

		protected BaseValidation(Context context)
		{
			mContext = context;
		}
		public abstract string GetErrorMessage();

		public abstract bool IsValid(string text);
	}
}
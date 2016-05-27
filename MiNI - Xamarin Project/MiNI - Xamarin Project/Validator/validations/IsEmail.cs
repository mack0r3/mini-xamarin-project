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
using MiNI___Xamarin_Project.Validator.validations;
using System.Text.RegularExpressions;

namespace MiNI___Xamarin_Project.Validator
{
	class IsEmail : BaseValidation
	{
		public IsEmail(Context context) : base(context)
		{
		}

		public override string GetErrorMessage()
		{
			return mContext.GetString(Resource.String.invalidEmailErrorMessage);
		}

		public override bool IsValid(string text)
		{
			return Regex.IsMatch(text,
				@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
				RegexOptions.IgnoreCase);
		}
	}
}

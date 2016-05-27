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
using RestSharp;
using RestSharp.Authenticators;

namespace MiNI___Xamarin_Project.Authentication
{
    public class ResourceOwnerAuthenticator : IAuthenticator
    {

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("Authorization", $"Bearer {ApplicationState.AccessToken}");
        }

   
    }
}
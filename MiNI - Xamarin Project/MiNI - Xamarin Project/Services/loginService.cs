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
using MiNI___Xamarin_Project.Interfaces;
using RestSharp;
using MiNI___Xamarin_Project.Authentication;
using MiNI___Xamarin_Project.Configuration;

namespace MiNI___Xamarin_Project.Services
{
    public class LoginService : ILoginService
    {
        private string mUsername;
        private string mPassword;
        private readonly RestClient mClient;

        public LoginService(string username, string password)
        {
            mUsername = username;
            mPassword = password;
            mClient = new RestClient(Urls.ApiUrl)
            {
                Timeout = 10000,
            };
        }

        public void Login()
        {
            GetAccessToken(mClient);
        }

        private void GetAccessToken(IRestClient client)
        {
            var request = new RestRequest("token", Method.POST);
            request.AddParameter("username", mUsername);
            request.AddParameter("password", mPassword);
            request.AddParameter("grant_type", "password");

            var response = client.Execute<TokenServerResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Wyjebalo logowanie :((");

            ApplicationState.AccessToken = response.Data.access_token;


        }
    }
}
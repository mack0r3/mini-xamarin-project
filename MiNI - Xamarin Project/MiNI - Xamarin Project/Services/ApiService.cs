using System;
using System.Collections.Generic;
using MiNI___Xamarin_Project.Authentication;
using MiNI___Xamarin_Project.Configuration;
using MiNI___Xamarin_Project.Interfaces;
using RestSharp;

namespace MiNI___Xamarin_Project.Services
{
    public class ApiService : IApiService
    {
        private readonly RestClient mClient;

        public ApiService()
        {
            mClient = new RestClient(Urls.ApiUrl)
            {
                Timeout = 10000,
                Authenticator = new ResourceOwnerAuthenticator()
            };
        }

        public List<string> TestRequest()
        {
            var request = new RestRequest("api/test", Method.GET);

            var response = mClient.Execute<List<string>>(request);

            return response.Data;
        }
    }
}
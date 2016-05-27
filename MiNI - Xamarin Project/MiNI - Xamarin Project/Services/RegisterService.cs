using RestSharp;
using MiNI___Xamarin_Project.Configuration;
using System;
using MiNI___Xamarin_Project.DTO;

namespace MiNI___Xamarin_Project.Services
{
    public class RegisterService
    {
        private readonly RestClient mClient;

        public RegisterService()
        {
            mClient = new RestClient(Urls.ApiUrl)
            {
                Timeout = 10000,
            };
        }

        public void Register(RegistrationDTO info)
        {

            var request = new RestRequest("/api/Account/Register", Method.POST);
            request.AddParameter("Email", info.Email);
            request.AddParameter("Password", info.Password);
            request.AddParameter("ConfirmPassword", info.Password);

            var response = mClient.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Wyjebalem sie na rejestracji :((");
        }



    }
}
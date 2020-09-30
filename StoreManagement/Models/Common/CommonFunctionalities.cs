using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace StoreManagement.Models.Common
{
    public static class CommonFunctionalities
    {
        private static readonly RestClient restClient;

        static CommonFunctionalities()
        {
            restClient = new RestClient(ConfigurationManager.AppSettings["WebAPIUrl"]);
        }

        public static T ExecuteGetRequest<T, P>(string urlAction, P obj, Method M)
        {

            var request = new RestRequest(urlAction, M);
            request.RequestFormat = DataFormat.Json;
                var jsonBody = JsonConvert.SerializeObject(obj);
                request.AddJsonBody(jsonBody);
            var x = restClient.Execute(request);

            return JsonConvert.DeserializeObject<T>(x.Content);
        }

        public static T ExecuteGetRequest<T>(string urlAction, Method M)
        {

            var request = new RestRequest(urlAction, M);
            request.RequestFormat = DataFormat.Json;
            var x = restClient.Execute(request);

            return JsonConvert.DeserializeObject<T>(x.Content);
        }
    }
}
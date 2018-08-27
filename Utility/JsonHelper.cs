using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using System.Web.Script.Serialization;
using WebApi.Models;

namespace WebApiDemo.Utility
{
    public class JsonHelper :Controller
    {

        private string BaseUrl= "http://localhost/Webapi/";
        //get list Of type
        public async Task<List<T>> GetAllRequst<T>(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                var data = "";
                if (response.IsSuccessStatusCode)
                {
                     data = await response.Content.ReadAsStringAsync();
                }
                return ConvertJsonToObject.AsObjectList<T>(data);
            }
        }

        //get a type
        public async Task<T> GetRequst<T>(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                var data = "";
                if (response.IsSuccessStatusCode)
                {
                     data = await response.Content.ReadAsStringAsync();
                }
                    return ConvertJsonToObject.AsObject<T>(data);
            }
        }

        //post type
        public async Task<string> PostRequst<T>(string apiUrl,T t)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent contentPost = new StringContent(ConvertJsonToObject.AsJson<T>(t), Encoding.UTF8,
                "application/json");
                HttpResponseMessage response = await client.PostAsync(new Uri(apiUrl), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    return "Success";
                }
                return "Failed";
            }
        }

        //detele type

        public async Task<bool> DeleteRequst(string apiUrl)
        {

            HttpClient httpClient = new HttpClient();
            Uri CustUri = null;
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://online/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                CustUri = response.Headers.Location;
            }
           
            return true;

            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(BaseUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.DeleteAsync(apiUrl);
              
            //    if (response.IsSuccessStatusCode)
            //    {
            //        return true; //data = await response.Content.ReadAsStringAsync();
            //    }
            //    return false;// ConvertJsonToObject.AsObject<T>(data);
           // }
        }

    }
}
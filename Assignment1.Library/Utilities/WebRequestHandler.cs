﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Assignment1.Library.Utilities
{
    public class WebRequestHandler
    {
        private string host = "localhost";
        private string port = "7147";
        private HttpClient Employee { get; }
        public WebRequestHandler()
        {
            Employee = new HttpClient();
        }
        public async Task<string> Get(string url)
        {
            var fullUrl = $"https://{host}:{port}{url}";
            try
            {
                using (var employee = new HttpClient())
                {
                    var response = await employee
                        .GetStringAsync(fullUrl)
                        .ConfigureAwait(false);
                    return response;
                }
            } catch(Exception e)
            {

            }


            return null;
        }

        public async Task<string> Post(string url, object obj)
        {
            using(var employee = new HttpClient())
            {
                using(var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    using(var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using(var response = await employee
                            .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                            .ConfigureAwait(false))
                        {
                            if(response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            return "ERROR";
                        }
                    }
                }
            }
        }
    }
}

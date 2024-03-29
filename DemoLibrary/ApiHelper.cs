﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DemoLibrary
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } 

        public static void InitClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

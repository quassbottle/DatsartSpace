﻿using System.Net.Http.Headers;
using DatsartSpace.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DatsartSpace.API;

public class DatsSpace
{
    private HttpClient _httpClient;

    public DatsArtStages Stages { get; }
    
    public DatsSpace(string token = "643cd453323f8643cd453323fa")
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://api.datsart.dats.team/")
        };
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "643cd453323f8643cd453323fa");

        Stages = new DatsArtStages(_httpClient);
    }

    public class DatsArtStages
    {
        private HttpClient _httpClient;
        
        public DatsArtStages(HttpClient client)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress, "art/stage/");
        }
        
        public async Task<NextResponse> GetNextLevelAsync()
        {
            var result = await _httpClient.PostAsync("next", null);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = JsonConvert.DeserializeObject<NextResponse>(json["response"].ToString());
            return response;
        }

        public async Task<QueueResponse> StartNextLevelAsync(int imageId)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(imageId + ""), "imageId");
            content.Headers.Add("Content-Disposition", "form-data; name=\"imageId\" 5");

            var result = await _httpClient.PostAsync("next-start", content);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = JsonConvert.DeserializeObject<QueueResponse>(json["response"].ToString());
            return response;
        }
    
        public async Task<CurrentLevelResponse> GetInfoAsync()
        {
            var result = await _httpClient.PostAsync("info", null);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = JsonConvert.DeserializeObject<CurrentLevelResponse>(json["response"].ToString());
            return response;
        }
    
        public async Task<QueueResponse> FinishLevelAsync()
        {
            var result = await _httpClient.PostAsync("finish", null);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = JsonConvert.DeserializeObject<QueueResponse>(json["response"].ToString());
            return response;
        }
    }

    public class DatsArtFactory
    {
        private HttpClient _httpClient;
        
        public DatsArtFactory(HttpClient client)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress, "art/factory/");
        }
        
        public async Task<GenerateResponse> GenerateAsync()
        {
            var result = await _httpClient.PostAsync("generate", null);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = JsonConvert.DeserializeObject<GenerateResponse>(json["response"].ToString());
            return response;
        }
        
        public async Task<PickResponse> PickAsync(int num)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(num + ""), "num");

            var result = await _httpClient.PostAsync("pick", content);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = JsonConvert.DeserializeObject<PickResponse>(json["response"].ToString());
            return response;
        }
    }

    public class DatsArtColors
    {
        private HttpClient _httpClient;
        
        public DatsArtColors(HttpClient client)
        {
            _httpClient = client;
            _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress, "art/colors/");
        }
        
        public async Task<InfoResponse> GetNextLevelAsync()
        {
            var result = await _httpClient.PostAsync("info", null);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = JsonConvert.DeserializeObject<InfoResponse>(json["response"].ToString());
            return response;
        }
        
        public async Task<int> GetColorAmountAsync(int color)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(color + ""), "color");

            var result = await _httpClient.PostAsync("amount", content);
            var json = JObject.Parse(await result.Content.ReadAsStringAsync());
            var response = json["response"].Value<int>();
            return response;
        }
    }
}
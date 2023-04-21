// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.datsart.dats.art/")
};
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "643cd453323f8643cd453323fa");

//httpClient.PostAsync("/art/stage/next", )
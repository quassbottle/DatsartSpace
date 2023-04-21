// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Http.Headers;
using System.Text;
using DatsartSpace.API;

/*
var httpClient = new HttpClient
{
    BaseAddress = new Uri("http://api.datsart.dats.team/")
};
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "643cd453323f8643cd453323fa");


var content = new MultipartFormDataContent();
content.Add(new StringContent("5"), "imageId");
//content.Headers.Add("Content-Disposition", "form-data; name=\"imageId\" 5");

Console.WriteLine(content.Headers);

var result = await httpClient.PostAsync("art/stage/next-start", content);
Console.WriteLine(await result.Content.ReadAsStringAsync()); */

var api = new DatsSpace();
var result = await api.GetNextLevelAsync();
Console.WriteLine();
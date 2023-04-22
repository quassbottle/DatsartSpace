// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using DatsartSpace;
using DatsartSpace.API;
using DatsartSpace.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

// var api = new DatsSpaceApi();
// var result = await api.Ballista.ShootAsync(1, 1, 100,
//     new Dictionary<int, int> {
//     { 13320187, 1 }, { 2351959, 1 }
// });
// Console.WriteLine(JsonConvert.SerializeObject(result));


var api = new DatsSpaceApi();
var result = await api.Ballista.ShootAsync(0, 1, 500, new[]
{
    (16767779, 1),
    (7077751, 1)
});
var queue = await api.State.GetQueueAsync(1682156538367250466);
Console.WriteLine(JsonConvert.SerializeObject(queue));
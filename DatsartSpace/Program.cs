// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
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

var result = await httpClient.GetAsync("/art/factory/generate");
Console.WriteLine(await result.Content.ReadAsStringAsync()); */

var url = "http://s.datsart.dats.team/game/image/227/59.png";
using var wc = new WebClient();
using var stream = wc.OpenRead(url);
using var image = new Bitmap(stream);
int[] colors = {16777215};
for (int y = 0; y < image.Height; y++)
{
    for (int x = 0; x < image.Width; x++)
    {
        var color = image.GetPixel(x, y);
        int colorValue = color.ToArgb() * -1;

        if (!colors.Contains(colorValue))
            colors = colors.Append(colorValue).ToArray();
    }

    var api = new DatsSpaceApi();
    var result = await api.Factory.GenerateAsync();

    Console.WriteLine(result.Item1.First.Color);
    Console.WriteLine(result.Item1.Second.Color);
    Console.WriteLine(result.Item1.Third.Color);
    Console.WriteLine(result.Item2.tick);
}

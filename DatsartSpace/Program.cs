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

// var api = new DatsSpaceApi();
// var ballista = new Ballista();
// var calc = ballista.Calculate(50, 125, 2, 250);
// var result = await api.Ballista.ShootAsync(calc.angleH, calc.angleV, calc.power, new[]
// {
//     (16767779, 1),
//     (7077751, 1)
// });
// Console.WriteLine(JsonConvert.SerializeObject(result));

var api = new DatsSpaceApi();

var rrr = await api.Stages.GetInfoAsync();
Console.WriteLine(JsonConvert.SerializeObject(rrr));

return;
var url = "http://s.datsart.dats.team/game/image/227/59.png";
using var wc = new WebClient();
using var stream = wc.OpenRead(url);
var currentState = await api.Stages.GetInfoAsync();
var image = new Bitmap(await (await new HttpClient().GetAsync(currentState.SelectedImage.Url)).Content.ReadAsStreamAsync());
Bitmap bitmap = new Bitmap(250, 250);
int[] colors = { };
Point[] points = { };

for (int y = 0; y < image.Height; y++)
{
    for (int x = 0; x < image.Width; x++)
    {
        var color = image.GetPixel(x, y);
        int r = color.R << 16;
        int g = color.G << 8;
        int b = color.B;
        int rgb = r + g + b;

        if (rgb != 16777215)
        {
            colors = colors.Append(rgb).ToArray();
            points = points.Append(new Point(x, y)).ToArray();
        }
    }
}

for (int i = colors.Length - 1; i > -1; i--)
{
    try
    {
        Dictionary<string, int> colorsAmountAsync = await api.Colors.GetColorsAmountAsync();
        foreach (var res in colorsAmountAsync)
        {
            if (ColorUtils.AnySimilar(colors[i], Convert.ToInt32(res.Key), 30))
            {
                Console.WriteLine($"{res.Value} - {res.Key} = {points[i].X} - {points[i].Y}");
                Ballista ballista = new Ballista();

                var angle = ballista.Calculate(points[i].X, points[i].Y, res.Value, 250);
                var result = await api.Ballista.ShootAsync(angle.angleH,
                    angle.angleV, angle.power,
                    new (int, int)[] { (Convert.ToInt32(res.Key), res.Value) });
                Console.WriteLine(result.Queue.Id);
                Console.WriteLine(Convert.ToInt32(angle.angleH) + " - " + Convert.ToInt32(angle.angleV) +
                                  " - " + angle.power);
//await Task.Delay(1);
                break;
            }
        }
    }
    catch
    {
        Console.WriteLine("ПИЗДЕЦ!!!!!!");
        i--;
    }
}
//Console.WriteLine(JsonConvert.SerializeObject(result));
using DatsartSpace.API;

var api = new DatsSpaceApi();
var rnd = new Random();

while (true)
{
    var generateResult = await api.Factory.GenerateAsync();
    var pick = await api.Factory.PickAsync(rnd.Next(1, 4), generateResult.Item2);
    Console.WriteLine($"Picked: {pick.Color}; Amount: {pick.Amount}");
    await Task.Delay(1000);
}
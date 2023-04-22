using DatsartSpace.API;

var api = new DatsSpaceApi();
var rnd = new Random();

int colors = 0;
int total = 0;
Console.Title = $"Colors: {colors} | Total: {total}";
while (true)
{
    try
    {
        var generateResult = await api.Factory.GenerateAsync();
        var pick = await api.Factory.PickAsync(rnd.Next(1, 4), generateResult.Item2);
        Console.WriteLine($"Picked: {pick.Color}; Amount: {pick.Amount}");
        colors++;
        total += pick.Amount;
        await Task.Delay(1000);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Died: " + ex.ToString());
        await Task.Delay(10000);
    }
    Console.Title = $"Colors: {colors} | Total: {total}";
}
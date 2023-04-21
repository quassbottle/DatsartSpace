using DatsartSpace.API;
using DatsartSpace.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public DatsSpaceApi Api;
    
    public static long GeneratedTick { get; set; } = 0;
    
    public GenerateResponse GeneratedColors { get; set; }
    
    public Dictionary<string, int> ColorsAvailable { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Api = new DatsSpaceApi();
    }

    public async void OnGet()
    {
        
    }

    public void OnPost(int colorId)
    {
        var result = Api.Factory.PickAsync(colorId, GeneratedTick).GetAwaiter().GetResult();
        _logger.LogInformation(JsonConvert.SerializeObject(result));
    }
}
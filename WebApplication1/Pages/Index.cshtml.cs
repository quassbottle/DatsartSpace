using DatsartSpace.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public DatsSpaceApi Api;
    public Dictionary<string, int> ColorsAvailable;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Api = new DatsSpaceApi();
    }

    public void OnGet()
    {
        ColorsAvailable = Api.Colors.GetColorsAmountAsync().GetAwaiter().GetResult();
    }

    public void OnPost(int colorId)
    {
        var result = Api.Factory.PickAsync(colorId).GetAwaiter().GetResult();
        
    }
}
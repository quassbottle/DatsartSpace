using Newtonsoft.Json;

namespace DatsartSpace.API.Models;

public class GenerateResponse
{
    [JsonProperty("1")] 
    public FactoryColorAmount First { get; set; }
    
    [JsonProperty("2")] 
    public FactoryColorAmount Second { get; set; }
    
    [JsonProperty("3")] 
    public FactoryColorAmount Third { get; set; }
}
namespace DatsartSpace.API.Models;

public class TickResponse
{
    public long Tick { get; set; }
    public long StateTimeNs { get; set; }
    public long StateTimeMs { get; set; }
}
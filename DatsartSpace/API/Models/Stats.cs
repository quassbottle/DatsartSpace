namespace DatsartSpace.API.Models;

public class Stats
{
    public int UserStageId { get; set; }
    public int UserId { get; set; }
    public int LastLogId { get; set; }
    public int CommandCount { get; set; }
    public int Grade { get; set; }
    public int Pixels { get; set; }
    public int PixelsMisses { get; set; }
    public int Shoots { get; set; }
    public int ShootsMisses { get; set; }
    public int ShootsMissesPartially { get; set; }
}
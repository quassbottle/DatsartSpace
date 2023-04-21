namespace DatsartSpace.API.Models;

public class QueueStateResponse
{
    public int Command { get; set; }
    public long Id { get; set; }
    public object Log { get; set; }
    public long StateMachineId { get; set; }
    public int UserId { get; set; }
    public int UserStageId { get; set; }
    public int Status { get; set; }
    public Dto Dto { get; set; }
}
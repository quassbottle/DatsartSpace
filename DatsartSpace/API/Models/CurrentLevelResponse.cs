namespace DatsartSpace.API.Models;

public class CurrentLevelResponse : NextResponse
{
    public SelectedImage SelectedImage { get; set; }
    public Canvas Canvas { get; set; }
    public Stats Stats { get; set; }
}
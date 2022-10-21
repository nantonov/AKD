namespace DG.BLL.Models;

public class Drawing
{
    public int Id { get; set; }
    public string Description { get; set; }
    public Dictionary<string, Coords> Points { get; set; }
    public string DescriptionPhotoLink { get; set; }
    public string DrawingPhotoLink { get; set; }
}
//public record Drawing(
//    int Id, 
//    string Description,
//    Dictionary<string, Coords> Coords);

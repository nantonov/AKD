using DG.BLL.Models;

namespace DG.API.Models;

public class DrawingBodyModel
{
    public string Description { get; set; }
    public Dictionary<string, Coords> Points { get; set; }
    public string DescriptionPhotoLink { get; set; }
    public string DrawingPhotoLink { get; set; }
}
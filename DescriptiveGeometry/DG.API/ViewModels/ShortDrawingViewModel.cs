using DG.BLL.Models;

namespace DG.API.ViewModels;

public class ShortDrawingViewModel
{
    public string Description { get; set; }
    public Dictionary<string, Coords> Points { get; set; }
    public string DescriptionPhotoLink { get; set; }
    public string DrawingPhotoLink { get; set; }
}
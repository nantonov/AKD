namespace DG.BLL.Models;

public class Drawing
{
    public int Id { get; set; }
    public string DrawingPhotoLink { get; set; }
    public int DownloadsCount { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
    public DrawingDescription? Description { get; set; }
}
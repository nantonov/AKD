namespace DG.DAL.Entities;

public class DrawingRow
{
    public int Id { get; set; }
    public string DrawingPhotoLink { get; set; }
    public int DownloadsCount { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
    public DrawingDescriptionRow? Description { get; set; }
}
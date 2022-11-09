namespace DG.DAL.Entities;

public class DrawingEntity
{
    public int Id { get; set; }
    public string? DrawingPhotoLink { get; set; }
    public int DownloadsCount { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
    public DrawingDescriptionEntity? Description { get; set; }
}
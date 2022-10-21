namespace DG.DAL.Context.Entities;

public class DrawingRow
{
    public int Id { get; set; }
    public string DrawingPhotoLink { get; set; }
    public string DownLoadCount { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateUpdated { get; set; }
    public DrawingDescriptionRow? Description { get; set; }
}
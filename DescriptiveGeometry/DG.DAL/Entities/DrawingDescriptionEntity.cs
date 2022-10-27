namespace DG.DAL.Entities;

public class DrawingDescriptionEntity
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Points { get; set; }
    public string DescriptionPhotoLink { get; set; }
    public int DrawingId { get; set; }
    public DrawingEntity? Drawing { get; set; }
}
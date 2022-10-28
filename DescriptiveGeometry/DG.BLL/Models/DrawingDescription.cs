namespace DG.BLL.Models;

public class DrawingDescription
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Points { get; set; }
    public string DescriptionPhotoLink { get; set; }
    public int DrawingId { get; set; }
    public Drawing? Drawing { get; set; }
}
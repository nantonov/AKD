namespace DG.DAL.Context.Entities;

public class DrawingDescriptionRow
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Points { get; set; }
    public string DescriptionPhotoLink { get; set; }
    public DrawingRow? Drawing { get; set; }
}
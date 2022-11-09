using DG.DAL.Entities;

namespace DG.DAL.Tests.Helpers;

public static class DrawingEntityHelper
{
    public static DrawingEntity CreateValidEntity(int id) => new DrawingEntity()
    {
        Id = id,
        DrawingPhotoLink = $"TestDrawingPhotoLink{id}",
        DownloadsCount = id,
        DateCreated = DateTimeOffset.Now,
        DateUpdated = DateTimeOffset.Now,
        Description = new DrawingDescriptionEntity()
        {
            Id = id,
            Text = $"TestText{id}",
            Points = $"TestPoints{id}",
            DescriptionPhotoLink = $"TestDescriptionPhotoLink{id}",
            DrawingId = id
        }
    };

    public static DrawingEntity CreateInvalidEntity(int id) => new DrawingEntity()
    {
        Id = id
    };
}
using DG.DAL.Entities;

namespace DG.DAL.Tests.Helpers;

public static class DrawingEntityHelper
{
    public static DrawingEntity Create(int id) => new DrawingEntity()
    {
        Id = id,
        DrawingPhotoLink = $"TestDrawingPhotoLink{id}",
        DownloadsCount = id,
        DateCreated = DateTimeOffset.Now,
        DateUpdated = DateTimeOffset.Now,
        Description = new DrawingDescriptionEntity()
        {
            Id = id,
            Text = $"TestTextWithMinimumLength=10_{id}",
            Points = $"TestPointsWithMinimumLength=8_{id}",
            DescriptionPhotoLink = $"TestDescriptionPhotoLink{id}",
            DrawingId = id
        }
    };
}
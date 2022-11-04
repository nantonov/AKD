using DG.DAL.Entities;

namespace DG.API.Tests.Helpers;

public static class DrawingEntityHelper
{
    public static DrawingEntity Create(int id) => new DrawingEntity()
    {
        Id = id,
        DrawingPhotoLink = $"DrawingPhotoLink{id}",
        DownloadsCount = id,
        DateCreated = DateTimeOffset.Now,
        DateUpdated = DateTimeOffset.Now,
        Description = new DrawingDescriptionEntity()
        {
            Id = id,
            Text = $"Text{id}",
            Points = $"Points{id}",
            DescriptionPhotoLink = $"DescriptionPhotoLink{id}",
            DrawingId = id
        }
    };
}
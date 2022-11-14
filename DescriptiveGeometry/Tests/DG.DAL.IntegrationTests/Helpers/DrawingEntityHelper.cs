using DG.DAL.Entities;

namespace DG.DAL.IntegrationTests.Helpers;

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

    public static DrawingEntity CreateValidEntityWithoutId()
    {
        var random = new Random();
        var number = random.Next();

        return new DrawingEntity()
        {
            DrawingPhotoLink = $"TestDrawingPhotoLink{number}",
            DownloadsCount = number,
            DateCreated = DateTimeOffset.Now,
            DateUpdated = DateTimeOffset.Now,
            Description = new DrawingDescriptionEntity()
            {
                Text = $"TestText{number}",
                Points = $"TestPoints{number}",
                DescriptionPhotoLink = $"TestDescriptionPhotoLink{number}"
            }
        };
    }
}
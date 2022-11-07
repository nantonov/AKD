using DG.BLL.Models;

namespace DG.BLL.Tests.Helpers;

public static class DrawingModelHelper
{
    public static Drawing Create(int id) => new Drawing()
    {
        Id = id,
        DrawingPhotoLink = $"DrawingPhotoLink{id}",
        DownloadsCount = id,
        DateCreated = DateTimeOffset.Now,
        DateUpdated = DateTimeOffset.Now,
        Description = new DrawingDescription()
        {
            Id = id,
            Text = $"Text{id}",
            Points = $"Points{id}",
            DescriptionPhotoLink = $"DescriptionPhotoLink{id}",
            DrawingId = id
        }
    };
}
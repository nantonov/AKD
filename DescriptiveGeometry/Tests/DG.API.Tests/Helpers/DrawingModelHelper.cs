using DG.API.ViewModels;

namespace DG.API.Tests.Helpers;

public static class DrawingModelHelper
{
    public static ChangeDrawingViewModel CreateChangeDrawingViewModel(int id) => new ChangeDrawingViewModel()
    {
        DrawingPhotoLink = $"DrawingPhotoLink{id}",
        Description = new DrawingDescriptionViewModel()
        {
            Text = $"Text{id}",
            Points = $"Points{id}",
            DescriptionPhotoLink = $"DescriptionPhotoLink{id}"
        }
    };

    public static DrawingViewModel CreateDrawingViewModel(int id) => new DrawingViewModel()
    {
        Id = id,
        DrawingPhotoLink = $"DrawingPhotoLink{id}",
        Description = new DrawingDescriptionViewModel()
        {
            Text = $"Text{id}",
            Points = $"Points{id}",
            DescriptionPhotoLink = $"DescriptionPhotoLink{id}"
        }
    };
}
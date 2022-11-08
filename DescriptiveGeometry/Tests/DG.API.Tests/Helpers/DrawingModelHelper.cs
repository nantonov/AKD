using DG.API.ViewModels;

namespace DG.API.Tests.Helpers;

public static class DrawingModelHelper
{
    public static ChangeDrawingViewModel CreateChangeDrawingViewModel(int id) => new ChangeDrawingViewModel()
    {
        DrawingPhotoLink = $"TestDrawingPhotoLink{id}",
        Description = new DrawingDescriptionViewModel()
        {
            Text = $"TestTextWithMinimumLength=10_{id}",
            Points = $"TestPointsWithMinimumLength=8_{id}",
            DescriptionPhotoLink = $"TestDescriptionPhotoLink{id}"
        }
    };

    public static DrawingViewModel CreateDrawingViewModel(int id) => new DrawingViewModel()
    {
        Id = id,
        DrawingPhotoLink = $"TestDrawingPhotoLink{id}",
        Description = new DrawingDescriptionViewModel()
        {
            Text = $"TestTextWithMinimumLength=10_{id}",
            Points = $"TestPointsWithMinimumLength=8_{id}",
            DescriptionPhotoLink = $"TestDescriptionPhotoLink{id}"
        }
    };
}
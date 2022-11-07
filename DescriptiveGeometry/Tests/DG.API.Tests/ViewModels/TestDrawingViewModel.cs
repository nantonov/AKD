using DG.API.ViewModels;
using DG.API.Tests.Helpers;

namespace DG.API.Tests.ViewModels;

public static class TestDrawingViewModel
{
    public static ChangeDrawingViewModel ValidChangeDrawingViewModel = DrawingModelHelper.CreateChangeDrawingViewModel(1);
    public static DrawingViewModel ValidDrawingViewModel = DrawingModelHelper.CreateDrawingViewModel(1);
    public static DrawingViewModel ValidCreateDrawingViewModel = DrawingModelHelper.CreateDrawingViewModel(6);

    public static IEnumerable<ChangeDrawingViewModel> ValidChangeDrawingViewModels = new List<ChangeDrawingViewModel>()
    {
        DrawingModelHelper.CreateChangeDrawingViewModel(1),
        DrawingModelHelper.CreateChangeDrawingViewModel(2),
        DrawingModelHelper.CreateChangeDrawingViewModel(3),
        DrawingModelHelper.CreateChangeDrawingViewModel(4),
        DrawingModelHelper.CreateChangeDrawingViewModel(5)
    };

    public static IEnumerable<DrawingViewModel> ValidDrawingViewModels = new List<DrawingViewModel>()
    {
        DrawingModelHelper.CreateDrawingViewModel(1),
        DrawingModelHelper.CreateDrawingViewModel(2),
        DrawingModelHelper.CreateDrawingViewModel(3),
        DrawingModelHelper.CreateDrawingViewModel(4),
        DrawingModelHelper.CreateDrawingViewModel(5)
    };
}
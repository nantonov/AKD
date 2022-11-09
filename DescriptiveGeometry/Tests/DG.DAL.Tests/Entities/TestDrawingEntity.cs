using DG.DAL.Tests.Helpers;
using DG.DAL.Entities;

namespace DG.DAL.Tests.Entities;

public static class TestDrawingEntity
{
    internal static DrawingEntity ValidDrawingEntity = DrawingEntityHelper.CreateValidEntity(1);

    internal static IEnumerable<DrawingEntity> ValidDrawingEntities = new List<DrawingEntity>()
    {
        DrawingEntityHelper.CreateValidEntity(1),
        DrawingEntityHelper.CreateValidEntity(2),
        DrawingEntityHelper.CreateValidEntity(3),
        DrawingEntityHelper.CreateValidEntity(4),
        DrawingEntityHelper.CreateValidEntity(5)
    };

    internal static IEnumerable<DrawingEntity> InvalidDrawingEntities = new List<DrawingEntity>()
    {
        DrawingEntityHelper.CreateInvalidEntity(1),
        DrawingEntityHelper.CreateInvalidEntity(2),
        DrawingEntityHelper.CreateInvalidEntity(3),
        DrawingEntityHelper.CreateInvalidEntity(4),
        DrawingEntityHelper.CreateInvalidEntity(5)
    };

    public static IEnumerable<object[]> GetValidDrawingEntities()
    {
        foreach (var validDrawingEntity in ValidDrawingEntities)
        {
            yield return new object[] { validDrawingEntity };
        }
    }

    internal static IEnumerable<object[]> GetInvalidDrawingEntities()
    {
        foreach (var validDrawingEntity in InvalidDrawingEntities)
        {
            yield return new object[] { validDrawingEntity };
        }
    }
}

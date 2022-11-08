using DG.DAL.Tests.Helpers;
using DG.DAL.Entities;

namespace DG.DAL.Tests.Entities;

public static class TestDrawingEntity
{
    internal static DrawingEntity ValidDrawingEntity = DrawingEntityHelper.Create(1);

    internal static IEnumerable<DrawingEntity> ValidDrawingEntities = new List<DrawingEntity>()
    {
        DrawingEntityHelper.Create(1),
        DrawingEntityHelper.Create(2),
        DrawingEntityHelper.Create(3),
        DrawingEntityHelper.Create(4),
        DrawingEntityHelper.Create(5)
    };
}

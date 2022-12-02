using DG.DAL.IntegrationTests.Helpers;
using DG.DAL.Entities;

namespace DG.DAL.IntegrationTests.Entities;

public static class TestDrawingEntity
{
    internal static IEnumerable<DrawingEntity> GetValidDrawingEntitiesWithId() => new List<DrawingEntity>()
    {
        DrawingEntityHelper.CreateValidEntity(1),
        DrawingEntityHelper.CreateValidEntity(2),
        DrawingEntityHelper.CreateValidEntity(3),
        DrawingEntityHelper.CreateValidEntity(4),
        DrawingEntityHelper.CreateValidEntity(5)
    };

    internal static IEnumerable<DrawingEntity> GetValidCreatedDrawingEntities() => new List<DrawingEntity>()
        {
        DrawingEntityHelper.CreateValidEntityWithoutId(),
        DrawingEntityHelper.CreateValidEntityWithoutId(),
        DrawingEntityHelper.CreateValidEntityWithoutId(),
        DrawingEntityHelper.CreateValidEntityWithoutId(),
        DrawingEntityHelper.CreateValidEntityWithoutId()
        };

    public static IEnumerable<object[]> GetValidDrawingEntities()
    {
        foreach (var validCreatedDrawingEntity in GetValidCreatedDrawingEntities())
        {
            yield return new object[] { validCreatedDrawingEntity };
        }
    }
}

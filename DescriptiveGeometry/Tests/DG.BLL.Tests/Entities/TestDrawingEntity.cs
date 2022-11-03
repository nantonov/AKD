﻿using DG.BLL.Tests.Helpers;
using DG.DAL.Entities;

namespace DG.BLL.Tests.Entities;

public static class TestDrawingEntity
{
    public static DrawingEntity ValidDrawingEntity = DrawingEntityHelper.Create(1);

    public static IEnumerable<DrawingEntity> ValidDrawingEntities = new List<DrawingEntity>()
    {
        DrawingEntityHelper.Create(1),
        DrawingEntityHelper.Create(2),
        DrawingEntityHelper.Create(3),
        DrawingEntityHelper.Create(4),
        DrawingEntityHelper.Create(5)
    };
}

using AutoMapper;
using DG.BLL.Models;
using DG.DAL.Entities;
using FakeItEasy;
using Moq;
using Xunit;

namespace DG.BLL.Tests;
public class MapperTests
{
    private readonly IMapper _mapper;
    public MapperTests()
    {
        //_mapper = A.Fake<IMapper>();
        _mapper = new Mock<IMapper>().Object;
    }

    [Fact]
    public void MapDrawingToDrawingEntity_WithOK()
    {
        var drawingEntities = A.Fake<IEnumerable<DrawingEntity>>();
        var drawings = A.Fake<IEnumerable<Drawing>>();

        var drawingsAfterMap = _mapper.Map<IEnumerable<Drawing>>(drawingEntities);
        var drawingEntitiesAfterMap = _mapper.Map<IEnumerable<DrawingEntity>>(drawings);

        Assert.Equal(drawingsAfterMap, drawings);
        Assert.Equal(drawingEntitiesAfterMap, drawingEntities);
    }
}
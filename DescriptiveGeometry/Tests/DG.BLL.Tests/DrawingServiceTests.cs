using AutoMapper;
using DG.BLL.Models;
using Xunit;
using DG.DAL.Interfaces.Repositories;
using DG.BLL.Services;
using Moq;
using static DG.BLL.Tests.Models.TestDrawingModel;
using static DG.BLL.Tests.Entities.TestDrawingEntity;
using DG.DAL.Entities;

namespace DG.BLL.Tests;

public class DrawingServiceTests
{
    private readonly DrawingService _drawingService;
    private readonly Mock<IDrawingRepository> _drawingRepository;
    private readonly Mock<IMapper> _mapper;

    public DrawingServiceTests()
    {
        _drawingRepository = new Mock<IDrawingRepository>();
        _mapper = new Mock<IMapper>();
        _drawingService = new DrawingService(_drawingRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task DrawingService_Get_ReturnValidModelWithOK()
    {
        _drawingRepository
                .Setup(dr => dr.GetById(ValidDrawingModel.Id, default).Result)
                .Returns(ValidDrawingEntity);
        _mapper
            .Setup(m => m.Map<Drawing>(ValidDrawingEntity))
            .Returns(ValidDrawingModel);

        var result = await _drawingService.Get(ValidDrawingModel.Id, default);

        Assert.Equal(result.Id, ValidDrawingModel.Id);
        Assert.Equal(result.DrawingPhotoLink, ValidDrawingModel.DrawingPhotoLink);
    }

    [Fact]
    public async Task DrawingService_GetAll_ReturnListWithOK()
    {
        _drawingRepository
            .Setup(dr =>dr.GetAll(default).Result)
            .Returns(ValidDrawingEntities);
        _mapper
            .Setup(m =>m.Map<IEnumerable<Drawing>>(ValidDrawingEntities))
            .Returns(ValidDrawingModels);

        var result = await _drawingService.GetAll(default);
        
        Assert.Equal(result.Count, ValidDrawingEntities.Count());
    }

    [Fact]
    public async Task DrawingService_Create_ReturnValidModelWithOK()
    {
        _drawingRepository
            .Setup(dr => dr.Create(ValidDrawingEntity, default).Result)
            .Returns(ValidDrawingEntity);
        _mapper
            .Setup(m => m.Map<Drawing>(ValidDrawingEntity))
            .Returns(ValidDrawingModel);
        _mapper
            .Setup(m => m.Map<DrawingEntity>(ValidDrawingModel))
            .Returns(ValidDrawingEntity);

        var result = await _drawingService.Create(ValidDrawingModel, default);

        Assert.Equal(result.Id, ValidDrawingModel.Id);
        Assert.Equal(result.DrawingPhotoLink, ValidDrawingModel.DrawingPhotoLink);
    }

    [Fact]
    public async Task DrawingService_Update_ReturnValidModelWithOK()
    {
        _drawingRepository
            .Setup(dr => dr.Update(ValidDrawingEntity, default).Result)
            .Returns(ValidDrawingEntity);
        _mapper
            .Setup(m => m.Map<Drawing>(ValidDrawingEntity))
            .Returns(ValidDrawingModel);
        _mapper
            .Setup(m => m.Map<DrawingEntity>(ValidDrawingModel))
            .Returns(ValidDrawingEntity);

        var result = await _drawingService.Update(ValidDrawingModel, default);

        Assert.Equal(result.Id, ValidDrawingModel.Id);
        Assert.Equal(result.DrawingPhotoLink, ValidDrawingModel.DrawingPhotoLink);
    }
}

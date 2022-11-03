using AutoMapper;
using Moq;
using Xunit;
using DG.BLL.Models;
using DG.DAL.Interfaces.Repositories;
using DG.DAL.Entities;
using DG.BLL.Services;
using static DG.BLL.Tests.Models.TestDrawingModel;
using static DG.BLL.Tests.Entities.TestDrawingEntity;

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
    public async Task Get_ValidId_ReturnsDrawingModel()
    {
        _drawingRepository
                .Setup(dr => dr.GetById(ValidDrawingModel.Id, default))
                .ReturnsAsync(ValidDrawingEntity);
        _mapper
            .Setup(m => m.Map<Drawing>(ValidDrawingEntity))
            .Returns(ValidDrawingModel);

        var result = await _drawingService.Get(ValidDrawingModel.Id, default);

        Assert.Equal(result.Id, ValidDrawingModel.Id);
        Assert.Equal(result.DrawingPhotoLink, ValidDrawingModel.DrawingPhotoLink);
    }

    [Fact]
    public async Task GetAll_ReturnsDrawingModelList()
    {
        _drawingRepository
            .Setup(dr => dr.GetAll(default))
            .ReturnsAsync(ValidDrawingEntities);
        _mapper
            .Setup(m =>m.Map<IEnumerable<Drawing>>(ValidDrawingEntities))
            .Returns(ValidDrawingModels);

        var result = await _drawingService.GetAll(default);
        
        Assert.Equal(result.Count, ValidDrawingEntities.Count());
    }

    [Fact]
    public async Task Create_ValidDrawingModel_ReturnsDrawingModel()
    {
        _drawingRepository
            .Setup(dr => dr.Create(ValidDrawingEntity, default))
            .ReturnsAsync(ValidDrawingEntity);
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
    public async Task Update_ValidDrawingModel_ReturnsDrawingModel()
    {
        _drawingRepository
            .Setup(dr => dr.Update(ValidDrawingEntity, default))
            .ReturnsAsync(ValidDrawingEntity);
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

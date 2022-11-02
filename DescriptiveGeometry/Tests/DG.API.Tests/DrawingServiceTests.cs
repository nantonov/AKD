using System.Configuration;
using System.Net.Http.Headers;
using AutoMapper;
using DG.BLL.Interfaces;
using DG.BLL.Models;
using Xunit;
using FakeItEasy;
using FluentAssertions;
using DG.DAL.Interfaces.Repositories;
using DG.BLL.Services;
using DG.DAL.Entities;
using Moq;
using DG.BLL.Tests.Helpers;
using DG.DAL.Repositories;

namespace DG.BLL.Tests;

public class DrawingServiceTests
{
    private readonly DrawingService _drawingService;
    private readonly IDrawingRepository _drawingRepository;
    private readonly IMapper _mapper;

    //public DrawingServiceTests()
    //{
    //    _drawingRepository = new Mock<IDrawingRepository>().Object;
    //    _mapper = new Mock<IMapper>().Object;
    //    _drawingService = new DrawingService(_drawingRepository.Object, _mapper);
    //}

    public DrawingServiceTests()
    {
        _drawingRepository = A.Fake<IDrawingRepository>();
        _mapper = A.Fake<IMapper>();
        _drawingService = new DrawingService(_drawingRepository, _mapper);
    }

    [Fact]
    public async Task DrawingService_Get_ReturnNotNullWithOK()
    {
        

        
        var rnd = new Random();
        var num = rnd.Next();

        var result = await _drawingService.Get(num, new CancellationToken());

        result.Should().BeNull();
    }

    [Fact]
    public async Task DrawingService_GetAll_ReturnNotNullWithOK()
    {
        //IEnumerable<DrawingEntity> drawingEntities = new List<DrawingEntity>()
        //{
        //    DrawingEntityHelper.Create(1),
        //    DrawingEntityHelper.Create(2),
        //    DrawingEntityHelper.Create(3),
        //    DrawingEntityHelper.Create(4),
        //    DrawingEntityHelper.Create(5)
        //};

        //_drawingRepository.Setup(dr => dr.GetAll(default).Result).Returns(drawingEntities);

        IEnumerable<DrawingEntity> drawingEntities = new List<DrawingEntity>()
        {
            DrawingEntityHelper.Create(1),
            DrawingEntityHelper.Create(2),
            DrawingEntityHelper.Create(3),
            DrawingEntityHelper.Create(4),
            DrawingEntityHelper.Create(5)
        };
        A.CallTo(() => _drawingRepository.GetAll(default)).Returns(drawingEntities);

        //var drawing = _mapper.Map<Drawing>(DrawingEntityHelper.Create(1));

        var result = await _drawingService.GetAll(default);

        result.Should().NotBeNull();
    }
}

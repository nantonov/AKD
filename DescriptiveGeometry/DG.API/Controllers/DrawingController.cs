using AutoMapper;
using DG.API.ViewModels;
using DG.BLL.Interfaces;
using DG.BLL.Models;

using Microsoft.AspNetCore.Mvc;

namespace DG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrawingController : Controller
{
    private readonly IDrawingService _drawingService;
    private readonly IMapper _mapper;

    public DrawingController(
        IDrawingService drawingService,
        IMapper mapper)
    {
        _drawingService = drawingService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<DrawingViewModel> Get(
        int id,
        CancellationToken cancellationToken)
    {
        var drawing = await _drawingService
            .Get(id, cancellationToken);

        return _mapper.Map<DrawingViewModel>(drawing);
    }

    [HttpGet]
    public async Task<IEnumerable<DrawingViewModel>> GetAll(
        CancellationToken cancellationToken)
    {
        var drawings = await _drawingService
            .GetAll(cancellationToken);

        return _mapper.Map<IEnumerable<DrawingViewModel>>(drawings); ;
    }

    [HttpPost]
    public async Task<DrawingViewModel> Create(
        [FromBody] ChangeDrawingViewModel changeDrawingViewModel,
        CancellationToken cancellationToken)
    {
        var drawingModel = _mapper.Map<Drawing>(changeDrawingViewModel);

        var drawing = await _drawingService
            .Create(drawingModel, cancellationToken);

        return _mapper.Map<DrawingViewModel>(drawing);
    }

    [HttpPut("{id}")]
    public async Task<DrawingViewModel> Update(
        int id,
        [FromBody] ChangeDrawingViewModel changeDrawingViewModel,
      CancellationToken cancellationToken)
    {
        var drawingModel = _mapper.Map<Drawing>(changeDrawingViewModel);
        drawingModel.Id = id;

        var result = await _drawingService
            .Update(drawingModel, cancellationToken);

        return _mapper.Map<DrawingViewModel>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(
        int id,
        CancellationToken cancellationToken)
    {
        return _drawingService.Delete(id, cancellationToken);
    }
}
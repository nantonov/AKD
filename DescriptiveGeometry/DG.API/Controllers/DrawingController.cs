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

    public DrawingController(
        IDrawingService drawingService)
    {
        _drawingService = drawingService;
    }

    [HttpGet("{id}")]
    public async Task<Drawing> Get(
        [FromQuery] int id,
        CancellationToken cancellationToken)
    {
        var result = await _drawingService
            .Get(id, cancellationToken);

        return result;
    }
    
    [HttpGet("description")]
    public async Task<List<Drawing>> GetByDescription(
        [FromQuery] string description,
        CancellationToken cancellationToken)
    {
        var result = await _drawingService
            .GetByDescription(description, cancellationToken);

        return result;
    }
    
    [HttpGet]
    public async Task<List<Drawing>> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _drawingService
            .GetAll(cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<Drawing> Create(
        [FromBody] ShortDrawingViewModel drawingViewModel,
        CancellationToken cancellationToken)
    {
        var result = await _drawingService
            .Create(
                MapToDrawing(drawingViewModel),
                cancellationToken);

        return result;
    }

    [HttpPut]
    public async Task<Drawing> Update(
        [FromQuery] int id,
        [FromBody] ShortDrawingViewModel drawingViewModel,
      CancellationToken cancellationToken)
    {
        var drawing = MapToDrawing(drawingViewModel);
        drawing.Id = id;

        var result = await _drawingService
            .Update(drawing,cancellationToken);

        return result;
    }

    [HttpDelete]
    public Task Delete(
        [FromQuery] int id,
        CancellationToken cancellationToken)
    {
        return _drawingService.Delete(id, cancellationToken);
    }

    private static Drawing MapToDrawing(ShortDrawingViewModel drawing)
    {
        return new Drawing()
        {
            Description = drawing.Description,
            Points = drawing.Points,
            DescriptionPhotoLink = drawing.DescriptionPhotoLink,
            DrawingPhotoLink = drawing.DrawingPhotoLink
        };
    }
}
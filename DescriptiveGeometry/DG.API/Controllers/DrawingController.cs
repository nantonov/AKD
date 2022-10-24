using DG.API.Models;
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

    [HttpGet("id{id}")]
    public async Task<Drawing> Get(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Get(id, cancellationToken);

        return result;
    }
    
    [HttpGet("search")]
    public async Task<List<Drawing>> FindByDescription(
        [FromQuery] string description,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetByQuery(description, cancellationToken);

        return result;
    }
    
    [HttpGet("all")]
    public async Task<List<Drawing>> GetDrawings(
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetDrawings(cancellationToken);

        return result;
    }

    [HttpGet("ids")]
    public async Task<List<int>> GetIds(
        [FromQuery] string description,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetIds(description, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] DrawingBodyModel drawingBodyModel,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Create(
                MapToDrawing(drawingBodyModel),
                cancellationToken);

        return result ? BadRequest() : Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update(
        [FromQuery] int id,
        [FromBody] DrawingBodyModel drawingBodyModel,
      CancellationToken cancellationToken = default)
    {
        var drawing = MapToDrawing(drawingBodyModel);
        drawing.Id = id;

        var result = await _drawingService
            .Update(drawing,cancellationToken);

        return result ? BadRequest() : Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService.Delete(id, cancellationToken);

        return result ? BadRequest() : Ok();
    }

    private static Drawing MapToDrawing(DrawingBodyModel drawing)
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
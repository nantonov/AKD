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
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Get(id, cancellationToken);

        return result;
    }

    [HttpGet("description/{description}")]
    public async Task<List<Drawing>> FindByDescription(
        [FromRoute] string description,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetByQuery(description, cancellationToken);

        return result;
    }

    [HttpGet]
    public async Task<List<Drawing>> GetDrawings(
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetDrawings(cancellationToken);

        return result;
    }

    [HttpGet("ids/description/{description}")]
    public async Task<List<int>> GetId(
        [FromRoute] string description,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetIds(description, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<int> Create(
      [FromBody] Drawing drawing,
      CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Create(drawing, cancellationToken);

        return result;
    }

    [HttpPut]
    public async Task<int> Update(
      [FromBody] Drawing drawing,
      CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Update(drawing, cancellationToken);

        return result;
    }

    [HttpDelete]
    public async Task Delete(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        await _drawingService.Delete(id, cancellationToken);
    }
}
using DG.BLL.Models;
using DG.BLL.Services.Contract;

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
    public async Task<ActionResult<Drawing>> Get(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Get(id);

        return result;
    }

    [HttpGet("query/{query}")]
    public async Task<List<Drawing>> FindByDescription(
        [FromRoute] string query,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetByQuery(query);

        return result;
    }

    [HttpGet]
    public async Task<List<Drawing>> GetDrawings(
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetDrawings();

        return result;
    }

    [HttpGet("ids/query/{query}")]
    public async Task<List<int>> GetId(
        [FromRoute] string query,
        CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .GetIds(query);

        return result;
    }

    [HttpPost]
    public async Task<int> Create(
      [FromBody] Drawing drawing,
      CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Create(drawing);

        return result;
    }

    [HttpPut]
    public async Task<int> Update(
      [FromBody] Drawing drawing,
      CancellationToken cancellationToken = default)
    {
        var result = await _drawingService
            .Update(drawing);

        return result;
    }

    [HttpDelete]
    public async Task Delete(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        await _drawingService.Delete(id);
    }
}
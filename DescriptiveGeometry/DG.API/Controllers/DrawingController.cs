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

    [HttpGet("id{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Drawing>> Get(
    [FromRoute] int id)
    {
        var result = await _drawingService
            .Get(id)
            .ConfigureAwait(false);

        return result;
    }

    [HttpGet("q-{query}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Drawing>>> GetByQuery(
        [FromRoute] string query)
    {
        var result = await _drawingService
            .GetByQuery(query)
            .ConfigureAwait(false);

        return result;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Drawing>>> GetDrawings()
    {
        var result = await _drawingService
            .GetDrawings()
            .ConfigureAwait(false);

        return result;
    }

    [HttpGet("ids/q-{query}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<int>>> GetId(
        [FromRoute] string query)
    {
        var result = await _drawingService
            .GetId(query)
            .ConfigureAwait(false);

        return result;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Create(
      [FromBody] Drawing drawing)
    {
        var result = await _drawingService
            .Create(drawing)
            .ConfigureAwait(false);

        return result;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Update(
      [FromBody] Drawing drawing)
    {
        var result = await _drawingService
            .Update(drawing)
            .ConfigureAwait(false);

        return result;
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Delete(
        [FromRoute] int id)
    {
        var result = await _drawingService
            .Delete(id)
            .ConfigureAwait(false);

        return result;
    }
}
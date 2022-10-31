using DG.BLL.Interfaces;
using DG.BLL.Models;
using DG.DAL.Interfaces.Repositories;

namespace DG.BLL.Services;

public class DrawingBlService : IDrawingBlService
{
    public DrawingBlService(
        IDrawingRepository drawingRepository)
    {
        _drawingRepository = drawingRepository;
    }

    private readonly IDrawingRepository _drawingRepository;
    public Exception GetException { get; set; } = new ArgumentException("The drawing is not found");
    public Exception CreateException { get; set; } = new ArgumentException("Description already exists");
    public Exception UpdateException { get; set; } = new ArgumentException();
    public Exception DeleteException { get; set; } = new ArgumentException("The drawing is not found");

    public async Task<bool> Create(Drawing drawing, CancellationToken cancellationToken)
    {
        var drawingEntities = await _drawingRepository.GetAll(cancellationToken);

        if (drawing.Description is null)
        {
            return true;
        }

        return !drawingEntities.Any(d => 
            d.Description != null 
            && d.Description.Text == drawing.Description.Text);
    }
    
    public async Task<bool> Update(Drawing drawing, CancellationToken cancellationToken)
    {
        if (await _drawingRepository.GetById(drawing.Id, cancellationToken) is null)
        {
            UpdateException = new ArgumentException("The drawing is not found");
            return false;
        }

        if (drawing.Description is null)
        {
            return true;
        }

        var drawingEntities = await _drawingRepository.GetAll(cancellationToken);

        var result = !drawingEntities.Any(d =>
            d.Description != null
            && d.Description.Text == drawing.Description.Text
            && d.Id != drawing.Id);

        if (!result)
        {
            UpdateException = new ArgumentException("Description already exists");
        }

        return result;
    }
}

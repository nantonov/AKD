using DG.BLL.Exceptions;
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
    public Exception GetException { get; set; } = new NotImplementedException();
    public Exception CreateException { get; set; } = new NotImplementedException();
    public Exception UpdateException { get; set; } = new NotImplementedException();
    public Exception DeleteException { get; set; } = new NotImplementedException();

    public async Task<bool> IsPossibleGet(int id, CancellationToken cancellationToken)
    {
        var drawing = await _drawingRepository.GetById(id, cancellationToken);

        if (drawing is null)
        {
            GetException = new NotFoundException("The drawing is not found");
        }

        return drawing is not null; 
    }

    public async Task<bool> IsPossibleCreate(Drawing drawing, CancellationToken cancellationToken)
    {
        var drawingEntities = await _drawingRepository.GetAll(cancellationToken);

        if (drawing.Description is null)
        {
            return true;
        }

        if (drawingEntities.Any(d =>
                d.Description != null
                && d.Description.Text == drawing.Description.Text))
        {
            CreateException = new ArgumentException("Description already exists");

            return false;
        }

        return true;
    }
    
    public async Task<bool> IsPossibleUpdate(Drawing drawing, CancellationToken cancellationToken)
    {
        if (await _drawingRepository.GetById(drawing.Id, cancellationToken) is null)
        {
            UpdateException = new NotFoundException("The drawing is not found");

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

    public async Task<bool> IsPossibleDelete(int id, CancellationToken cancellationToken)
    {
        var drawing = await _drawingRepository.GetById(id, cancellationToken);

        if (drawing is null)
        {
            DeleteException = new NotFoundException("The drawing is not found");
        }

        return drawing is not null;
    }
}

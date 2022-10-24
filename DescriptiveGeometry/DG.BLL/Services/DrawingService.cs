using DG.BLL.Interfaces;
using DG.BLL.Models;

namespace DG.BLL.Services;

public class DrawingService : IDrawingService
{
    public Task<Drawing> Create(Drawing drawing, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Drawing> Get(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Drawing>> GetAll(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Drawing>> GetByDescription(string query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Drawing> Update(Drawing drawing, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

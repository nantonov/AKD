using DG.BLL.Interfaces;
using DG.BLL.Models;

namespace DG.BLL.Services;

public class DrawingService : IDrawingService
{
    //private readonly DrawingsDbContext _dbContext;

    //public DrawingService(
    //    DrawingsDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    public Task<Drawing> Get(int id,
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<List<Drawing>> GetByQuery(string query,
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<List<Drawing>> GetDrawings(
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<List<int>> GetIds(string query,
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<bool> Create(Drawing drawing,
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<bool> Update(Drawing drawing, 
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<bool> Delete(int id,
        CancellationToken cancellationToken = default)
    {
        return null;
    }
}
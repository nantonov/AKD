using DG.BLL.Models;
using DG.BLL.Services.Contract;

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

    public Task<int> Create(Drawing drawing,
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<int> Update(Drawing drawing, 
        CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task<int> Delete(int id,
        CancellationToken cancellationToken = default)
    {
        return null;
    }
}
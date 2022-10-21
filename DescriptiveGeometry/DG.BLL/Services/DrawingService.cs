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

    public Task<Drawing> Get(int id)
    {
        return null;
    }

    public Task<List<Drawing>> GetByQuery(string query)
    {
        return null;
    }

    public Task<List<Drawing>> GetDrawings()
    {
        return null;
    }

    public Task<string> GetName(int id)
    {
        return null;
    }

    public Task<List<int>> GetId(string query)
    {
        return null;
    }

    public Task<int> Create(Drawing drawing)
    {
        return null;
    }

    public Task<int> Update(Drawing drawing)
    {
        return null;
    }

    public Task<int> Delete(int id)
    {
        return null;
    }
}
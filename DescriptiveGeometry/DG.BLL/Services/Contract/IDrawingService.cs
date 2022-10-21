using DG.BLL.Models;

namespace DG.BLL.Services.Contract;

public interface IDrawingService
{
    Task<Drawing> Get(int id);

    Task<List<Drawing>> GetByQuery(string query);

    Task<List<Drawing>> GetDrawings();

    Task<string> GetName(int id);

    Task<List<int>> GetId(string query);

    Task<int> Create(Drawing drawing);

    Task<int> Update(Drawing drawing);

    Task<int> Delete(int id);
}

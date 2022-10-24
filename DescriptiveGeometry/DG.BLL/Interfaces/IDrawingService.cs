using DG.BLL.Models;

namespace DG.BLL.Interfaces;

public interface IDrawingService
{
    Task<Drawing> Get(int id,
        CancellationToken cancellationToken = default);

    Task<List<Drawing>> GetByQuery(string query,
        CancellationToken cancellationToken = default);

    Task<List<Drawing>> GetDrawings(
        CancellationToken cancellationToken = default);

    Task<List<int>> GetIds(string query,
        CancellationToken cancellationToken = default);

    Task<int> Create(Drawing drawing,
        CancellationToken cancellationToken = default);

    Task<int> Update(Drawing drawing,
        CancellationToken cancellationToken = default);

    Task<int> Delete(int id,
        CancellationToken cancellationToken = default);
}

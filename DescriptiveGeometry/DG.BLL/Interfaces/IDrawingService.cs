using DG.BLL.Models;

namespace DG.BLL.Interfaces;

public interface IDrawingService
{
    Task<Drawing> Get(int id,
        CancellationToken cancellationToken = default);

    Task<List<Drawing>> GetByDescription(string description,
        CancellationToken cancellationToken = default);

    Task<List<Drawing>> GetAll(
        CancellationToken cancellationToken = default);

    Task<Drawing> Create(Drawing drawing,
        CancellationToken cancellationToken = default);

    Task<Drawing> Update(Drawing drawing,
        CancellationToken cancellationToken = default);

    Task Delete(int id,
        CancellationToken cancellationToken = default);
}

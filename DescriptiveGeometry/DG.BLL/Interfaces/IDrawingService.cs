using DG.BLL.Models;

namespace DG.BLL.Interfaces;

public interface IDrawingService
{
    Task<Drawing> Get(int id,
        CancellationToken cancellationToken);

    Task<List<Drawing>> GetByDescription(string description,
        CancellationToken cancellationToken);

    Task<List<Drawing>> GetAll(
        CancellationToken cancellationToken);

    Task<Drawing> Create(Drawing drawing,
        CancellationToken cancellationToken);

    Task<Drawing> Update(Drawing drawing,
        CancellationToken cancellationToken);

    Task Delete(int id,
        CancellationToken cancellationToken);
}

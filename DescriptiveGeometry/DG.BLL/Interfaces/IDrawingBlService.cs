using DG.BLL.Models;

namespace DG.BLL.Interfaces;

public interface IDrawingBlService
{
    Exception GetException { get; set; }
    Exception CreateException { get; set; }
    Exception UpdateException { get; set; }
    Exception DeleteException { get; set; }
    Task<bool> IsPossibleGet(int id,
        CancellationToken cancellationToken);
    Task<bool> IsPossibleCreate(Drawing drawing,
        CancellationToken cancellationToken);
    Task<bool> IsPossibleUpdate(Drawing drawing,
        CancellationToken cancellationToken);
    Task<bool> IsPossibleDelete(int id,
        CancellationToken cancellationToken);
}

using DG.BLL.Models;

namespace DG.BLL.Interfaces;

public interface IDrawingBlService
{
    Exception GetException { get; set; }
    Exception CreateException { get; set; }
    Exception UpdateException { get; set; }
    Exception DeleteException { get; set; }
    Task<bool> Create(Drawing drawing,
        CancellationToken cancellationToken);

    Task<bool> Update(Drawing drawing,
        CancellationToken cancellationToken);
}

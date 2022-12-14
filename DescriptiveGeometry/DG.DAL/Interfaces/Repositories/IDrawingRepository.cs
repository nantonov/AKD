using DG.DAL.Entities;

namespace DG.DAL.Interfaces.Repositories;
public interface IDrawingRepository
{
    Task<IEnumerable<DrawingEntity>> GetAll(CancellationToken cancellationToken);
    Task<DrawingEntity?> GetById(int id, CancellationToken cancellationToken);
    Task<DrawingEntity> Create(DrawingEntity drawing, CancellationToken cancellationToken);
    Task<DrawingEntity> Update(DrawingEntity drawing, CancellationToken cancellationToken);
    Task Delete(DrawingEntity drawing, CancellationToken cancellationToken);
}
using DG.DAL.Context;
using DG.DAL.Entities;
using DG.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DG.DAL.Repositories;

public class DrawingRepository : IDrawingRepository
{
    private readonly DatabaseContext _db;

    public DrawingRepository(DatabaseContext db)
    {
        _db = db;
    }
    public async Task<DrawingEntity> Create(DrawingEntity drawing, CancellationToken cancellationToken)
    {
        var drawingEntity = await _db.Drawings.AddAsync(drawing, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);

        return drawingEntity.Entity;
    }

    public async Task Delete(DrawingEntity drawing, CancellationToken cancellationToken)
    {
        _db.Drawings.Remove(drawing);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<DrawingEntity?> GetById(int id, CancellationToken cancellationToken)
    {
        return await _db.Drawings
            .AsNoTracking()
            .Include(d => d.Description)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<DrawingEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await _db.Drawings
            .AsNoTracking()
            .Include(d => d.Description)
            .ToListAsync(cancellationToken);
    }

    public async Task<DrawingEntity> Update(DrawingEntity drawing, CancellationToken cancellationToken)
    {
        _db.Entry(drawing).State = EntityState.Modified;

        if (drawing.Description is not null)
        {
            drawing.Description.DrawingId = drawing.Id;
            drawing.Description.Id = drawing.Id;
            _db.Entry(drawing.Description).State = EntityState.Modified;
        }

        await _db.SaveChangesAsync(cancellationToken);

        return drawing;
    }
}

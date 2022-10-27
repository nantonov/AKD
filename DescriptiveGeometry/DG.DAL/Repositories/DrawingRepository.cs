using DG.DAL.Context;
using DG.DAL.Entities;
using DG.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading;

namespace DG.DAL.Repositories;

public class DrawingRepository : IDrawingRepository
{
    private readonly DatabaseContext _db;

    public DrawingRepository(DatabaseContext db)
    {
        _db = db;
    }
    public async Task Create(DrawingEntity drawing, CancellationToken cancellationToken)
    {
        await _db.Drawings.AddAsync(drawing, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
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

    public async Task Update(DrawingEntity drawing, CancellationToken cancellationToken)
    {
        _db.Entry(drawing).State = EntityState.Modified;
        await _db.SaveChangesAsync(cancellationToken);
    }
}

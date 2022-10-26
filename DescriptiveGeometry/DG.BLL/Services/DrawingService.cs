using System.Text.Json;
using AutoMapper;
using DG.BLL.Interfaces;
using DG.BLL.Models;
using DG.DAL.Context;
using DG.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DG.BLL.Services;

public class DrawingService : IDrawingService
{
    private readonly DatabaseContext _dbContext;
    private readonly IMapper _mapper;

    public DrawingService(
        DatabaseContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Drawing> Create(Drawing drawing, CancellationToken cancellationToken)
    {
        var drawingRow = _mapper.Map<DrawingRow>(drawing);
        drawingRow.DateCreated = DateTimeOffset.Now;
        drawingRow.DateUpdated = DateTimeOffset.Now;
        drawingRow.DownloadsCount = 0;

        await _dbContext.Drawings.AddAsync(drawingRow, cancellationToken);

        var drawingDescriptionRow = _mapper.Map<DrawingDescriptionRow>(drawing);
        drawingDescriptionRow.Drawing = drawingRow;

        await _dbContext.DrawingDescription.AddAsync(drawingDescriptionRow, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        drawing.Id = drawingRow.Id;

        return drawing;
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var drawing = await _dbContext.Drawings
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        if (drawing is not null)
        {
            _dbContext.Drawings.Remove(drawing);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<Drawing> Get(int id, CancellationToken cancellationToken)
    {
        var drawingRow = await _dbContext.Drawings
            .Include(d => d.Description)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        return _mapper.Map<Drawing>(drawingRow);
    }

    public async Task<List<Drawing>> GetAll(CancellationToken cancellationToken)
    {
        var drawingRows = _dbContext.Drawings
            .Include(d => d.Description);

        return await ConvertToList(drawingRows, cancellationToken);
    }

    public async Task<List<Drawing>> GetByDescription(string description, CancellationToken cancellationToken)
    {
        var drawingRows = _dbContext.Drawings
            .Include(d => d.Description)
            .Where(d => d.Description.Text == description);

        return await ConvertToList(drawingRows, cancellationToken);
    }

    public async Task<Drawing> Update(Drawing drawing, CancellationToken cancellationToken)
    {
        var drawingRow = await _dbContext.Drawings
            .FirstOrDefaultAsync(d => d.Id == drawing.Id, cancellationToken);
      
        if (drawingRow is not null)
        {
            drawingRow.DrawingPhotoLink = drawing.DrawingPhotoLink;
            drawingRow.DateUpdated = DateTimeOffset.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        var descriptionDrawingRow = await _dbContext.DrawingDescription
            .FirstOrDefaultAsync(d => d.Id == drawing.Id, cancellationToken);

        if (descriptionDrawingRow is not null)
        {
            descriptionDrawingRow.Text = drawing.Description;
            descriptionDrawingRow.Points = JsonSerializer.Serialize(drawing.Points);
            descriptionDrawingRow.DescriptionPhotoLink = drawing.DescriptionPhotoLink;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        return drawing;
    }

    private async Task<List<Drawing>> ConvertToList(
        IQueryable<DrawingRow> drawingRows,
        CancellationToken cancellationToken)
    {
        var drawingRowsList = await drawingRows.ToListAsync(cancellationToken);

        var drawings = new List<Drawing>();

        foreach (var drawingRow in drawingRowsList)
        {
            drawings.Add(_mapper.Map<Drawing>(drawingRow));
        }

        return drawings;
    }
}

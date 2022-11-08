using DG.DAL.Context;
using DG.DAL.Interfaces.Repositories;
using DG.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static DG.DAL.Tests.Entities.TestDrawingEntity;

namespace DG.DAL.Tests;

public class DrawingRepositoryTests
{
    private readonly IDrawingRepository _drawingRepository;
    private readonly DatabaseContext _context;

    public DrawingRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "test_dal_db")
            .Options;

        _context = new DatabaseContext(options);

        _drawingRepository = new DrawingRepository(_context);
    }

    [Fact]
    public async Task GetById_ValidId_ReturnsDrawingEntity()
    {
        await _drawingRepository.Create(ValidDrawingEntity, default);

        var drawing = await _drawingRepository.GetById(ValidDrawingEntity.Id, default);

        Assert.NotNull(drawing);
        Assert.Equal(ValidDrawingEntity.Id, drawing?.Id);

        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task GetById_InvalidId_ReturnsNull()
    {
        await _drawingRepository.Create(ValidDrawingEntity, default);

        var drawing = await _drawingRepository.GetById(ValidDrawingEntity.Id + 1, default);

        Assert.Null(drawing);

        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task GetAll_ReturnsDrawingEntities()
    {
        foreach (var validEntity in ValidDrawingEntities)
        {
            await _drawingRepository.Create(validEntity, default);
        }

        var drawings = await _drawingRepository.GetAll(default);

        Assert.NotNull(drawings);
        Assert.Equal(ValidDrawingEntities.Count(), drawings?.Count());

        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task GetAll_ReturnsEmptyList()
    {
        var drawings = await _drawingRepository.GetAll(default);
       
        Assert.NotNull(drawings);
        Assert.Equal(0, drawings?.Count());

        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task Create_ValidDrawingEntity_ReturnsValidDrawingEntity()
    {
        var drawing = await _drawingRepository.Create(ValidDrawingEntity, default);

        Assert.NotNull(drawing);
        Assert.Equal(ValidDrawingEntity.Id, drawing?.Id);

        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task Update_ValidDrawingEntity_ReturnsUpdatedDrawingEntity()
    {
        await _drawingRepository.Create(ValidDrawingEntity, default);

        var updatedDrawingEntity = ValidDrawingEntity;
        updatedDrawingEntity.DownloadsCount += 1;

        var responseDrawing = await _drawingRepository.Update(updatedDrawingEntity, default);

        Assert.NotNull(responseDrawing);
        Assert.Equal(ValidDrawingEntity.DownloadsCount, responseDrawing?.DownloadsCount);

        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task Update_InvalidDrawingEntity_ReturnsException()
    {
        await _drawingRepository.Create(ValidDrawingEntity, default);

        var updatedDrawingEntity = ValidDrawingEntity;
        updatedDrawingEntity.Id += 1;

        try
        {
            await _drawingRepository.Update(updatedDrawingEntity, default);
            Assert.True(false);
        }
        catch
        {
            Assert.True(true);
        }

        await _context.Database.EnsureDeletedAsync();
    }
    
    [Fact]
    public async Task Delete_ValidId_ReturnsOK()
    {
        await _drawingRepository.Create(ValidDrawingEntity, default);

        try
        {
            await _drawingRepository.Delete(ValidDrawingEntity, default);
            Assert.True(true);
        }
        catch
        {
            Assert.True(false);
        }

        await _context.Database.EnsureDeletedAsync();
    }

    [Fact]
    public async Task Delete_InvalidId_ReturnsException()
    {
        await _drawingRepository.Create(ValidDrawingEntity, default);

        var deletedDrawingEntity = ValidDrawingEntity;
        deletedDrawingEntity.Id += 1;

        try
        {
            await _drawingRepository.Delete(deletedDrawingEntity, default);
            Assert.True(false);
        }
        catch
        {
            Assert.True(true);
        }
        finally
        {
            await _context.Database.EnsureDeletedAsync();
        }
    }
}
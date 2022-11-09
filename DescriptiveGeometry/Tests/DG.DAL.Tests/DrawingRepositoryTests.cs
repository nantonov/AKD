using DG.DAL.Context;
using DG.DAL.Entities;
using DG.DAL.Interfaces.Repositories;
using DG.DAL.Repositories;
using DG.DAL.Tests.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Xunit;
using static DG.DAL.Tests.Entities.TestDrawingEntity;

namespace DG.DAL.Tests;

public class DrawingRepositoryTests : IDisposable
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

    public async void Dispose() => await _context.Database.EnsureDeletedAsync();

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task GetById_ValidId_ReturnsDrawingEntity(DrawingEntity expectedDrawing)
    {
        await _drawingRepository.Create(expectedDrawing, default);
        var actualDrawing = await _drawingRepository.GetById(expectedDrawing.Id, default);

        Assert.NotNull(actualDrawing);
        Assert.Equal(expectedDrawing.Id, actualDrawing?.Id);
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task GetById_InvalidId_ReturnsNull(DrawingEntity expectedValidDrawing)
    {
        await _drawingRepository.Create(expectedValidDrawing, default);

        var actualDrawing = await _drawingRepository.GetById(int.MaxValue, default);

        Assert.Null(actualDrawing);
    }

    [Fact]
    public async Task GetAll_ReturnsDrawingEntities()
    {
        await _context.Drawings.AddRangeAsync(ValidDrawingEntities);
        await _context.SaveChangesAsync();

        var actualDrawings = await _drawingRepository.GetAll(default);

        Assert.NotNull(actualDrawings);
        Assert.Equal(ValidDrawingEntities.Count(), actualDrawings?.Count());
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Create_ValidDrawingEntity_ReturnsDrawingEntity(
        DrawingEntity expectedValidDrawing)
    {
        var actualDrawing = await _drawingRepository.Create(expectedValidDrawing, default);

        Assert.NotNull(actualDrawing);
        Assert.Equal(expectedValidDrawing.Id, actualDrawing?.Id);
        Assert.Equal(expectedValidDrawing.Description, actualDrawing?.Description);
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Update_ValidDrawingEntity_ReturnsUpdatedDrawingEntity(
        DrawingEntity expectedValidDrawing)
    {
        await _drawingRepository.Create(expectedValidDrawing, default);

        var updatedDrawingEntity = expectedValidDrawing;
        updatedDrawingEntity.DownloadsCount += 1;

        var actualDrawing = await _drawingRepository.Update(updatedDrawingEntity, default);

        Assert.NotNull(actualDrawing);
        Assert.Equal(expectedValidDrawing.DownloadsCount, actualDrawing?.DownloadsCount);
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Update_InvalidDrawingEntity_ThrowsException(
        DrawingEntity expectedValidDrawing)
    {
        await _drawingRepository.Create(expectedValidDrawing, default);

        var updatedDrawingEntity = expectedValidDrawing;
        updatedDrawingEntity.Id += 1;
        
        try
        {
            await _drawingRepository.Update(updatedDrawingEntity, default);
            Assert.True(false);
        }
        catch(InvalidOperationException)
        {
            Assert.True(true);
        }
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Delete_ValidId_OK(DrawingEntity expectedValidDrawing)
    {
        await _drawingRepository.Create(expectedValidDrawing, default);

        try
        {
            await _drawingRepository.Delete(expectedValidDrawing, default);
            Assert.True(true);
        }
        catch
        {
            Assert.True(false);
        }
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Delete_InvalidId_ThrowsException(DrawingEntity expectedValidDrawing)
    {
        try
        {
            await _drawingRepository.Delete(expectedValidDrawing, default);
            Assert.True(false);
        }
        catch(DbUpdateConcurrencyException)
        {
            Assert.True(true);
        }
    }
}
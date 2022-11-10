using DG.DAL.Context;
using DG.DAL.Entities;
using DG.DAL.Interfaces.Repositories;
using DG.DAL.Repositories;
using DG.DAL.Tests.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;
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
        await _context.Drawings.AddAsync(expectedDrawing, default);
        await _context.SaveChangesAsync();

        var actualDrawing = await _drawingRepository.GetById(expectedDrawing.Id, default);

        actualDrawing.ShouldNotBe(null);
        actualDrawing?.Id.ShouldBe(expectedDrawing.Id);
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task GetById_InvalidId_ReturnsNull(DrawingEntity expectedDrawing)
    {
        await _context.Drawings.AddAsync(expectedDrawing, default);
        await _context.SaveChangesAsync();

        var actualDrawing = await _drawingRepository.GetById(int.MaxValue, default);
        
        actualDrawing.ShouldBe(null);
    }

    [Fact]
    public async Task GetAll_ReturnsDrawingEntities()
    {
        await _context.Drawings.AddRangeAsync(ValidDrawingEntities);
        await _context.SaveChangesAsync();

        ////Refactoring

        var actualDrawings = await _drawingRepository.GetAll(default);
        
        actualDrawings.ShouldNotBe(null);
        actualDrawings?.Count().ShouldBe(ValidDrawingEntities.Count());
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Create_ValidDrawingEntity_EntityIsCreated(
        DrawingEntity expectedValidDrawing)
    {
        var actualDrawing = await _drawingRepository.Create(expectedValidDrawing, default);

        actualDrawing.ShouldNotBe(null);
        actualDrawing?.Id.ShouldBe(expectedValidDrawing.Id);
        actualDrawing?.Description.ShouldBe(expectedValidDrawing.Description);
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
        
        actualDrawing.ShouldNotBe(null);
        actualDrawing.DownloadsCount.ShouldBe(expectedValidDrawing.DownloadsCount);

    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Update_InvalidDrawingEntity_ThrowsException(
        DrawingEntity expectedValidDrawing)
    {
        await _drawingRepository.Create(expectedValidDrawing, default);

        var updatedDrawingEntity = expectedValidDrawing;
        updatedDrawingEntity.Id += 1;

        await Should.ThrowAsync<InvalidOperationException>
            (async () => await _drawingRepository.Update(updatedDrawingEntity, default));
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Delete_ValidId_EntityIsDeleted(DrawingEntity expectedValidDrawing)
    {
        await _drawingRepository.Create(expectedValidDrawing, default);

        await Should.NotThrowAsync(
            async () => await _drawingRepository.Delete(expectedValidDrawing, default));

        var deletedDrawing = await _drawingRepository.GetById(expectedValidDrawing.Id, default);

        deletedDrawing.ShouldBe(null);
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Delete_InvalidId_ThrowsException(DrawingEntity expectedValidDrawing)
    {
        await Should.ThrowAsync<DbUpdateConcurrencyException>(
            async () => await _drawingRepository.Delete(expectedValidDrawing, default));
    }
}
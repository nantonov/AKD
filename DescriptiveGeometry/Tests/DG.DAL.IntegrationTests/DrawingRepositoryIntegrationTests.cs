using DG.DAL.Context;
using DG.DAL.Entities;
using DG.DAL.Interfaces.Repositories;
using DG.DAL.Repositories;
using DG.DAL.IntegrationTests.Entities;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using static DG.DAL.IntegrationTests.Entities.TestDrawingEntity;

namespace DG.DAL.IntegrationTests;

public class DrawingRepositoryIntegrationTests : IDisposable
{
    private readonly IDrawingRepository _drawingRepository;
    private readonly DatabaseContext _context;

    public DrawingRepositoryIntegrationTests()
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
        await AddAsync(_context, expectedDrawing);

        var actualDrawing = await _drawingRepository.GetById(expectedDrawing.Id, default);

        actualDrawing.ShouldNotBe(null);
        actualDrawing?.Id.ShouldBe(expectedDrawing.Id);
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task GetById_InvalidId_ReturnsNull(DrawingEntity expectedDrawing)
    {
        await AddAsync(_context, expectedDrawing);

        var actualDrawing = await _drawingRepository.GetById(int.MaxValue, default);
        
        actualDrawing.ShouldBe(null);
    }

    [Fact]
    public async Task GetAll_ReturnsDrawingEntities()
    {
        await AddAsync(_context, ValidDrawingEntities);

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
    public async Task Update_ValidDrawingEntity_EntityIsUpdated(
        DrawingEntity expectedValidDrawing)
    {
        await AddAsync(_context, expectedValidDrawing);

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
        await AddAsync(_context, expectedValidDrawing);

        var updatedDrawingEntity = expectedValidDrawing;
        updatedDrawingEntity.Id += 1;

        await Should.ThrowAsync<InvalidOperationException>
            (async () => await _drawingRepository.Update(updatedDrawingEntity, default));
    }

    [Theory]
    [MemberData(nameof(GetValidDrawingEntities), MemberType = typeof(TestDrawingEntity))]
    public async Task Delete_ValidId_EntityIsDeleted(DrawingEntity expectedValidDrawing)
    {
        await AddAsync(_context, expectedValidDrawing);

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

    private static async Task AddAsync(DatabaseContext context, DrawingEntity drawingEntity)
    {
        await context.Drawings.AddAsync(drawingEntity, default);
        await context.SaveChangesAsync();
    }

    private static async Task AddAsync(DatabaseContext context, IEnumerable<DrawingEntity> drawingEntities)
    {
        await context.Drawings.AddRangeAsync(drawingEntities, default);
        await context.SaveChangesAsync();
    }
}
//using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using DG.API;
using AutoMapper;
using DG.BLL.Services;
using DG.DAL.Interfaces.Repositories;
using Moq;
using System.Net.Http.Json;
using DG.API.ViewModels;
using DG.DAL.Context;
using DG.API.Tests.Entities;

namespace DG.API.Tests;

public class DrawingControllerTests 
{
    [Fact]
    public async Task GetAll_ReturnsDrawingModels()
    {
        await using var application = new DrawingApi();

        using (var scope = application.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            using (var dbContext = provider.GetRequiredService<DatabaseContext>())
            {
                await dbContext.Database.EnsureCreatedAsync();

                await dbContext.Drawings.AddRangeAsync(TestDrawingEntity.ValidDrawingEntities);
                await dbContext.SaveChangesAsync();
            }
        }

        var client = application.CreateClient();
        var notes = await client.GetFromJsonAsync<IEnumerable<DrawingViewModel>>("/api/drawing");

        //Assert.IsNotNull(notes);
        //Assert.IsTrue(notes.Count == 0);

        //_drawingRepository
        //        .Setup(dr => dr.GetById(ValidDrawingModel.Id, default))
        //        .ReturnsAsync(ValidDrawingEntity);
        //_mapper
        //    .Setup(m => m.Map<Drawing>(ValidDrawingEntity))
        //    .Returns(ValidDrawingModel);

        //var result = await _drawingService.Get(ValidDrawingModel.Id, default);

        //Assert.Equal(result.Id, ValidDrawingModel.Id);
        //Assert.Equal(result.DrawingPhotoLink, ValidDrawingModel.DrawingPhotoLink);
    }
}
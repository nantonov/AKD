using DG.API.Validators;
using DG.API.ViewModels;
using DG.BLL.DI;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDrawings(builder.Configuration);
builder.Services
    .AddAutoMapper(typeof(DG.API.AutoMapper.MappingProfile), typeof(DG.BLL.AutoMapper.MappingProfile));
builder.Services.AddScoped<IValidator<ChangeDrawingViewModel>, ChangeDrawingViewModelValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
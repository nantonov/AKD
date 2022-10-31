﻿using AutoMapper;
using DG.BLL.Interfaces;
using DG.BLL.Models;
using DG.DAL.Entities;
using DG.DAL.Interfaces.Repositories;

namespace DG.BLL.Services;

public class DrawingService : IDrawingService
{
    private readonly IDrawingRepository _drawingRepository;
    private readonly IDrawingBlService _drawingBlService;
    private readonly IMapper _mapper;

    public DrawingService(
        IDrawingRepository drawingRepository,
        IDrawingBlService drawingBlService,
        IMapper mapper)
    {
        _drawingRepository = drawingRepository;
        _drawingBlService = drawingBlService;
        _mapper = mapper;
    }

    public async Task<Drawing> Create(Drawing drawing, CancellationToken cancellationToken)
    {
        if (!await _drawingBlService.Create(drawing, cancellationToken))
        {
            throw _drawingBlService.CreateException;
        }

        var drawingEntity = _mapper.Map<DrawingEntity>(drawing);
        var createdDrawing = await _drawingRepository.Create(drawingEntity, cancellationToken);

        return _mapper.Map<Drawing>(createdDrawing);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var drawing = await _drawingRepository.GetById(id, cancellationToken);
        
        if (drawing is null)
        {
            throw _drawingBlService.DeleteException;
        }

        await _drawingRepository.Delete(drawing, cancellationToken);
    }

    public async Task<Drawing> Get(int id, CancellationToken cancellationToken)
    {
        var drawing = await _drawingRepository.GetById(id, cancellationToken);

        if (drawing is null)
        {
            throw _drawingBlService.GetException;
        }

        return _mapper.Map<Drawing>(drawing);
    }

    public async Task<List<Drawing>> GetAll(CancellationToken cancellationToken)
    {
        var drawings = await _drawingRepository.GetAll(cancellationToken);

        return _mapper.Map<List<Drawing>>(drawings); 
    }

    public async Task<Drawing> Update(Drawing drawing, CancellationToken cancellationToken)
    {
        if (!await _drawingBlService.Update(drawing, cancellationToken))
        {
            throw _drawingBlService.UpdateException;
        }

        var drawingEntity = _mapper.Map<DrawingEntity>(drawing);
        await _drawingRepository.Update(drawingEntity, cancellationToken);

        return drawing;
    }
}

using AutoMapper;

using DG.BLL.Models;
using DG.DAL.Entities;

using System.Text.Json;

namespace DG.BLL.AutoMapper.Profiles;

public class DrawingToDrawingDescriptionRowProfile : Profile
{
    public DrawingToDrawingDescriptionRowProfile()
    {
        CreateMap<Drawing, DrawingDescriptionRow>()
            .ForMember(ddr => ddr.Text, opt =>
                opt.MapFrom(d => d.Description))
            .ForMember(ddr => ddr.Points, opt =>
                opt.MapFrom(d => SerializeToString(d.Points)));
    }

    private static string SerializeToString(Dictionary<string, Coords> points)
    {
        return  JsonSerializer.Serialize(points);
    }
}
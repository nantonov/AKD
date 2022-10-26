using AutoMapper;
using DG.BLL.Models;
using DG.DAL.Entities;
using System.Text.Json;

namespace DG.BLL.AutoMapper.Profiles;

public class DrawingRowToDrawingProfile : Profile
{
    public DrawingRowToDrawingProfile()
    {
        CreateMap<DrawingRow, Drawing>()
            .ForMember(d => d.Description, opt =>
                opt.MapFrom(dr => dr.Description.Text))
            .ForMember(d => d.Points, opt =>
                opt.MapFrom(dr => DeserializeToPoints(dr.Description.Points)))
            .ForMember(d => d.DescriptionPhotoLink, opt =>
                opt.MapFrom(dr => dr.Description.DescriptionPhotoLink));//DrawingPhotoLink
    }

    private static Dictionary<string, Coords> DeserializeToPoints(string str)
    {
        return JsonSerializer.Deserialize<Dictionary<string, Coords>>(str);
    }
}

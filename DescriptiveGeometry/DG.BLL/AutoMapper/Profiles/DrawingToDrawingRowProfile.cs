using AutoMapper;

using DG.BLL.Models;
using DG.DAL.Entities;

namespace DG.BLL.AutoMapper.Profiles;

public class DrawingToDrawingRowProfile : Profile
{
    public DrawingToDrawingRowProfile()
    {
        CreateMap<Drawing, DrawingRow>()
            .ForMember(ddr => ddr.Description, opt =>
                opt.MapFrom(d => d));
    }
}
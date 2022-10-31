using AutoMapper;
using DG.BLL.Models;
using DG.DAL.Entities;

namespace DG.BLL.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DrawingEntity, Drawing>().ReverseMap();
        CreateMap<DrawingDescriptionEntity, DrawingDescription>().ReverseMap();
    }
}

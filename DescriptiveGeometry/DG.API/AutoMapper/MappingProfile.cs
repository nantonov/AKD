using AutoMapper;
using DG.API.ViewModels;
using DG.BLL.Models;

namespace DG.API.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DrawingViewModel, Drawing>().ReverseMap();
        CreateMap<ChangeDrawingViewModel, Drawing>().ReverseMap();
        CreateMap<DrawingDescriptionViewModel, DrawingDescription>().ReverseMap();
    }
}
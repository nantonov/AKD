using AutoMapper;
using DG.API.ViewModels;
using DG.BLL.Models;

namespace DG.API.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Drawing, DrawingViewModel>().ReverseMap();
        CreateMap<Drawing, ChangeDrawingViewModel>().ReverseMap();
    }
}

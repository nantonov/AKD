using AutoMapper;
using DG.API.ViewModels;
using DG.BLL.Models;

namespace DG.API.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DrawingViewModel, Drawing>()
            .ForMember(
                d => d.Description,
                opt =>
                    opt.MapFrom(d => new DrawingDescription()
                    {
                        Text = d.DescriptionText,
                        Points = d.Points,
                        DescriptionPhotoLink = d.DescriptionPhotoLink
                    }));
        CreateMap<Drawing, DrawingViewModel>()
            .ForMember(
                d => d.DescriptionText,
                opt =>
                    opt.MapFrom(d => (d.Description == null) ? "" : d.Description.Text))
            .ForMember(
                d => d.Points,
                opt =>
                    opt.MapFrom(d => (d.Description == null) ? "" : d.Description.DescriptionPhotoLink))
            .ForMember(
                d => d.DescriptionPhotoLink,
                opt =>
                    opt.MapFrom(d => (d.Description == null) ? "" : d.Description.DescriptionPhotoLink));
        CreateMap<ChangeDrawingViewModel, Drawing>()
            .ForMember(
                d => d.Description,
                opt =>
                    opt.MapFrom(d => new DrawingDescription()
                    {
                        Text = d.DescriptionText,
                        Points = d.Points,
                        DescriptionPhotoLink = d.DescriptionPhotoLink
                    }));
        CreateMap<Drawing, ChangeDrawingViewModel>()
            .ForMember(
                d => d.DescriptionText,
                opt =>
                    opt.MapFrom(d => (d.Description == null) ? "" : d.Description.Text))
            .ForMember(
                d => d.Points,
                opt =>
                    opt.MapFrom(d => (d.Description == null) ? "" : d.Description.DescriptionPhotoLink))
            .ForMember(
                d => d.DescriptionPhotoLink,
                opt =>
                    opt.MapFrom(d => (d.Description == null) ? "" : d.Description.DescriptionPhotoLink));
    }
}
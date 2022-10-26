using AutoMapper;

using DG.BLL.AutoMapper.Profiles;

namespace DG.BLL.AutoMapper;

public class MappingProfile
{
    public static MapperConfiguration InitializeAutoMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DrawingToDrawingRowProfile());
            cfg.AddProfile(new DrawingToDrawingDescriptionRowProfile());
        });

        return config;
    }
}
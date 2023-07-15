using AutoMapper;
using ProductTaskCRUD.Models;
using ProductTaskCRUD.Models.ViewModels;

namespace ProductTaskCRUD.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProductViewModel, Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(dest => dest.Description))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(dest => dest.Category))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(dest => dest.Price))
            .ForMember(dest => dest.Count, opt => opt.MapFrom(dest => dest.Count))
            .ForMember(dest => dest.ImageURl, opt => opt.MapFrom(dest => dest.ImageLink))
            .ReverseMap();
    }
}

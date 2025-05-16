using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.Menus;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuAddDto, Menu>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<MenuUpdateDto, Menu>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Menu, MenuUpdateDto>();
        }
    }
}

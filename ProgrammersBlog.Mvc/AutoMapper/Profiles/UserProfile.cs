using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos.UsersDto;

namespace ProgrammersBlog.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto > ();
            CreateMap<UserUpdateDto, User>();

        }
    }
}

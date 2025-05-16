using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos.UsersDto
{
    public class UserDto:DtoGetBase
    {
        public User  User { get; set; }
    }
}

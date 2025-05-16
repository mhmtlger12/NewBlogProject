
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos.UsersDto
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
      
    }
}


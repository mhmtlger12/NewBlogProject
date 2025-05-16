using ProgrammersBlog.Entities.Dtos.Categories;
using ProgrammersBlog.Entities.Dtos.UsersDto;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
        public UserUpdateDto  UserUpdateDto { get; set; }
        public string UserUpdatePartial { get; set; }
        public UserDto UserDto  { get; set; }
    }
}

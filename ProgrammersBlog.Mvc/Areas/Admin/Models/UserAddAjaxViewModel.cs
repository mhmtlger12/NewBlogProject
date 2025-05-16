using ProgrammersBlog.Entities.Dtos.Categories;
using ProgrammersBlog.Entities.Dtos.UsersDto;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto UserAddDto { get; set; }
        public string UserAddPartial { get; set; }
        public UserDto UserDto  { get; set; }
    }
}

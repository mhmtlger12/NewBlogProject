using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos.Menus
{
    public class MenuListDto : DtoGetBase
    {
        public IList<Menu> Menus { get; set; }
    }
}

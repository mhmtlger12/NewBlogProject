using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos.Menus
{
    public class MenuDto : DtoGetBase
    {
        public Menu Menu { get; set; }
    }
}

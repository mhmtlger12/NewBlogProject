using ProgrammersBlog.Entities.Dtos.Menus;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class MenuAddAjaxViewModel
    {
        public MenuAddDto MenuAddDto { get; set; }
        public string MenuAddPartial { get; set; }
        public MenuDto MenuDto { get; set; }
    }
}

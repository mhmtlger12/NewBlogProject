using ProgrammersBlog.Entities.Dtos.Menus;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class MenuUpdateAjaxViewModel
    {
        public MenuUpdateDto MenuUpdateDto { get; set; }
        public string MenuUpdatePartial { get; set; }
        public MenuDto MenuDto { get; set; }
    }
}

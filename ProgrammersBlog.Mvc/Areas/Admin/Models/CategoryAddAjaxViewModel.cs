using ProgrammersBlog.Entities.Dtos.Categories;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto CategoryAddDto { get; set; }
        public string CategoryAddPartial { get; set; }
        public CategoryDto CategoryDto  { get; set; }
    }
}

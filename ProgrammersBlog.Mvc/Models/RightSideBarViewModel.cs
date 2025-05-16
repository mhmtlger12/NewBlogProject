
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Models
{
    public class RightSideBarViewModel
    {
        public IList<Menu> Menus { get; set; }
        public IList<Article> Articles { get; set; }
    }
}

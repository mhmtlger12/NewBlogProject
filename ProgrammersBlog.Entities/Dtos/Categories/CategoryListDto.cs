using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos.Categories
{
    public class CategoryListDto:DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}

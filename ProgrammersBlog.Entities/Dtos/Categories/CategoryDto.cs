
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos.Categories
{
    public class CategoryDto:DtoGetBase
    {
        public Category  Category { get; set; }
    }
}

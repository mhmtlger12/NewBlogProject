using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos.Articles
{
    public class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        public Guid? MenuId { get; set; }
    }
}

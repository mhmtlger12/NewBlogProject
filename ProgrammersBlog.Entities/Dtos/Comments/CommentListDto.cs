
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Entities.Dtos.Comments
{
    public class CommentListDto
    {
        public IList<Comment> Comments { get; set; }
    }
}

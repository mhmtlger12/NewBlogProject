using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Comment:EntityBase,IEntity
    {
        public string Text { get; set; }

        //Bir yorumda bir tane makaleye sahip olabilir
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public string? IpAddress { get; set; }
        
        // Yanıt özelliği için gerekli alanlar
        public Guid? ParentCommentId { get; set; } // Eğer bu bir yanıtsa, yanıt verilen yorumun ID'si
        public Comment? ParentComment { get; set; } // Yanıt verilen yorum
        public ICollection<Comment>? Replies { get; set; } // Bu yoruma verilen yanıtlar
        
        // Beğeni sayısı
        public int LikeCount { get; set; }
    }
}

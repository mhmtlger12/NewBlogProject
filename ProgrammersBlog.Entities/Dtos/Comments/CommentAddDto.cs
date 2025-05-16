using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ProgrammersBlog.Entities.Dtos.Comments
{
    public class CommentAddDto
    {
        [DisplayName("Yorum")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Text { get; set; }
        [DisplayName("Adınız")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string CreatedByName { get; set; }
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public Guid ArticleId { get; set; }
        public string? IpAddress { get; set; } 
        
        // Yanıt verilen yorumun ID'si, null ise ana yorum demektir
        public Guid? ParentCommentId { get; set; }
        
        // Yorumun aktif olup olmadığı, yanıtlar için false olarak ayarlanır (admin onayı gerekir)
        public bool IsActive { get; set; } = true;
    }
}

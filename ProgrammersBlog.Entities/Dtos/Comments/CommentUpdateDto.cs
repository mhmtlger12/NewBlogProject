using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ProgrammersBlog.Entities.Dtos.Comments
{
    public class CommentUpdateDto
    {
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public Guid Id { get; set; }
        [DisplayName("Yorum")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Text { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public Guid ArticleId { get; set; }
    }
}

using ProgrammersBlog.Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProgrammersBlog.Entities.Dtos.Articles
{
    public class ArticleUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Yazar Bilgisi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Etiketler")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoTags { get; set; }

        [DisplayName("Menü")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }

        [DisplayName("Aktif mi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsActive { get; set; }

        [DisplayName("Silinsin mi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}

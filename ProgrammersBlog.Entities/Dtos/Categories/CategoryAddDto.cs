using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.Dtos.Categories
{
    /// <summary>
    /// Kategori ekleme işlemi için kullanılan DTO (Data Transfer Object) sınıfıdır.
    /// </summary>
    public class CategoryAddDto
    {
        /// <summary>
        /// Kategori adı. Boş geçilemez ve 3-70 karakter arasında olmalıdır.
        /// </summary>
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir")] // {0} -> "Kategori Adı"
        [MaxLength(70, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")] // {1} -> 70
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")] // {1} -> 3
        public string Name { get; set; }

        /// <summary>
        /// Kategori açıklaması. Zorunlu değildir. En az 3, en fazla 500 karakter olabilir.
        /// </summary>
        [DisplayName("Kategori Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")]
        public string? Description { get; set; }

        /// <summary>
        /// Kategoriye özel not alanı. Zorunlu değildir. En az 3, en fazla 500 karakter olabilir.
        /// </summary>
        [DisplayName("Kategori Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")]
        public string? Note { get; set; }

        /// <summary>
        /// Kategorinin aktif olup olmadığını belirten alan. Boş bırakılamaz.
        /// </summary>
        [DisplayName("Aktif Mi ?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        public bool IsActive { get; set; }
    }
}

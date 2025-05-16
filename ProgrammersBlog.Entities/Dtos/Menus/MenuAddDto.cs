using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.Dtos.Menus
{
    /// <summary>
    /// Menü ekleme işlemi için kullanılan DTO (Data Transfer Object) sınıfıdır.
    /// </summary>
    public class MenuAddDto
    {
        /// <summary>
        /// Menü adı. Boş geçilemez ve 3-70 karakter arasında olmalıdır.
        /// </summary>
        [DisplayName("Menü Adı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir")]
        [MaxLength(70, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")]
        public string Name { get; set; }

        /// <summary>
        /// Menü açıklaması. Zorunlu değildir. En az 3, en fazla 500 karakter olabilir.
        /// </summary>
        [DisplayName("Menü Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")]
        public string? Description { get; set; }

        /// <summary>
        /// Menü URL'si. Zorunlu değildir. En fazla 250 karakter olabilir.
        /// </summary>
        [DisplayName("Menü URL")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        public string? Url { get; set; }

        /// <summary>
        /// Menü ikonu. Zorunlu değildir. En fazla 100 karakter olabilir.
        /// </summary>
        [DisplayName("Menü İkonu")]
        [MaxLength(100, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        public string? Icon { get; set; }

        /// <summary>
        /// Menü sırası. Boş geçilemez.
        /// </summary>
        [DisplayName("Menü Sırası")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir")]
        public int Order { get; set; }

        /// <summary>
        /// Üst menü ID'si. Zorunlu değildir.
        /// </summary>
        [DisplayName("Üst Menü")]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Menüye özel not alanı. Zorunlu değildir. En az 3, en fazla 500 karakter olabilir.
        /// </summary>
        [DisplayName("Menü Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük Olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olmamalıdır")]
        public string? Note { get; set; }

        /// <summary>
        /// Menünün aktif olup olmadığını belirten alan. Boş bırakılamaz.
        /// </summary>
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        public bool IsActive { get; set; }
    }
}

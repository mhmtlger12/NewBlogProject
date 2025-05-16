using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProgrammersBlog.Entities.Concrete
{
    public class AboutUsPageInfo
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Header { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(1500, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Content { get; set; }
        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(200, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(200, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoTags { get; set; }
        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(200, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoAuthor { get; set; }
        public string HeroSubtitle { get; set; }
        public string AboutTextParagraph1 { get; set; }
        public string AboutTextParagraph2 { get; set; }
        public string ValuesTitle { get; set; }
        public ValueItem[] Values { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Stats Stats { get; set; }
        public Gallery Gallery { get; set; }
        public string GalleryTitle { get; set; }
        public District[] Districts { get; set; }
        public string DistrictsTitle { get; set; }
        public string DistrictsDescription { get; set; }
        public Event[] Events { get; set; }
        public string EventsTitle { get; set; }
        public string EventsDescription { get; set; }
        public VisitorGuide VisitorGuide { get; set; }
    }

    public class ValueItem
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ContactInfo
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Hours { get; set; }
    }

    public class Stats
    {
        public string Title { get; set; }
        public StatItem[] Items { get; set; }
    }

    public class StatItem
    {
        public string Number { get; set; }
        public string Label { get; set; }
    }

    public class Gallery
    {
        public GalleryItem[] Items { get; set; }
    }

    public class GalleryItem
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }

    public class District
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Event
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class VisitorGuide
    {
        public string Title { get; set; }
        public GuideItem[] Items { get; set; }
    }

    public class GuideItem
    {
        public string Icon { get; set; }
        public string Text { get; set; }
    }
}
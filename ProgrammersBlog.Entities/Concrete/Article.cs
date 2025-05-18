using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    // Makale sınıfı, EntityBase sınıfından miras alarak ortak özellikleri kullanır.
    // Ayrıca, IEntity arabirimini uygular.
    public class Article : EntityBase, IEntity
    {
        // Makalenin başlığı
        public string Title { get; set; }

        // Makalenin içeriği
        public string Content { get; set; }

        // Makalenin küçük resim yolu
        public string Thumbnail { get; set; }

        // Makalenin yayınlandığı tarih (eski alan, geriye uyumluluk için korunuyor)
        public DateTime Date { get; set; }
        
        // Makalenin ilk yayınlanma tarihi (sıralama için kullanılır ve güncelleme yapılsa bile değişmez)
        public DateTime PublishDate { get; set; }

        // Makalenin görüntülenme sayısı
        public int ViewsCount { get; set; } = 0;

        // Makaleye yapılan yorum sayısı
        public int CommentCount { get; set; } = 0;

        // SEO için yazar adı
        public string SeoAuthor { get; set; }

        // SEO için açıklama
        public string SeoDescription { get; set; }

        // SEO için etiketler
        public string SeoTags { get; set; }

        // Makalenin hangi menüye ait olduğunu belirten foreign key
        public Guid MenuId { get; set; }

        // Navigation Property: Makalenin ait olduğu menü
        public virtual Menu Menu { get; set; }

        // Makaleyi yazan kullanıcının ID'si
        public Guid UserId { get; set; }

        // Navigation Property: Makalenin yazarı
        public virtual User User { get; set; }
        //Bir makale birden çok yoruma sahip olabilir
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

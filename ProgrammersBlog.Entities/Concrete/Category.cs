using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    // Kategori sınıfı, EntityBase sınıfından miras alarak ortak özellikleri kullanır.
    // Ayrıca, IEntity arabirimini uygular.
    public class Category : EntityBase, IEntity
    {
        // Kategorinin adı
        public string Name { get; set; }

        // Kategoriye ait açıklama
        public string? Description { get; set; }

        // Bir kategorinin birden fazla makalesi olabilir. (1'e N ilişki)
        public virtual ICollection<Article> Articles { get; set; }
    }
}

























//Çok - a - çok ilişkiler için biraz daha farklı bir yaklaşım sergilememiz gerekiyor. Sizlere bir örnek olabilmesi açısından çalıştığım başka bir projede ProductCategory ilişkisini baz alan çok-a-çok ilişkili bir konfigürasyonu eklemek istiyorum.

//Product Class:
//public ICollection<ProductCategory> ProductCategories { get; set; }
//Category Class:
//public ICollection<ProductCategory> ProductCategories { get; set; }
//ProductCategory Class

// public int ProductId { get; set; }
//public Product Product { get; set; }
//public int CategoryId { get; set; }
//public Category Category { get; set; }
//ProductCategoryMap Class:

//public void Configure(EntityTypeBuilder<ProductCategory> builder)
//{
//    // Hem ProductId, hem de CategoryId Primary Key'dir.
//    builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });
//    // Bir Product birden fazla ProductCategory'ye sahip olabilir.
//    builder.HasOne<Product>(pc => pc.Product).WithMany(p => p.ProductCategories)
//        .HasForeignKey(pc => pc.ProductId);
//    // Bir Category birden fazla ProductCategory'ye sahip olabilir.
//    builder.HasOne<Category>(pc => pc.Category).WithMany(c => c.ProductCategories)
//        .HasForeignKey(pc => pc.CategoryId);
//    builder.ToTable("ProductCategories");
//}
//Sonuç olarak bir Product birden fazla Category'ye sahip olabileceği gibi, Bir Category'de birden fazla Product'a sahip olabilir. Aynı mantığı ArticleCategory için de uygulayabilirsiniz.
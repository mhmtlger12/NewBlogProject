using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        // Varsayılan ikonlar için yardımcı metot
        private string GetRandomIcon()
        {
            string[] icons = new string[]
            {
                "bi bi-house-door-fill",
                "bi bi-journal-text",
                "bi bi-geo-alt-fill",
                "bi bi-info-circle-fill",
                "bi bi-telephone-fill"
            };
            
            // Rastgele bir ikon seç
            Random random = new Random();
            return icons[random.Next(icons.Length)];
        }
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            // **Tablo Adı**
            builder.ToTable("Menus").HasComment("Menüler");
            
            // Menü ikonu yoksa varsayılan bir ikon ata
            builder.Property(m => m.Icon)
                .HasConversion(
                    v => string.IsNullOrEmpty(v) ? GetRandomIcon() : v,
                    v => v
                );

            // Primary Key tanımı
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            // Property tanımlamaları
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(m => m.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(m => m.Url)
                .IsRequired(false)
                .HasMaxLength(250);

            builder.Property(m => m.Icon)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(m => m.Order)
                .IsRequired();

            // Ortak alanlar
            builder.Property(m => m.CreatedByName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.ModifiedByName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.CreatedDate)
                .IsRequired();

            builder.Property(m => m.ModifiedDate)
                .IsRequired();

            builder.Property(m => m.IsActive)
                .IsRequired();

            builder.Property(m => m.IsDeleted)
                .IsRequired();

            builder.Property(m => m.Note)
                .HasMaxLength(500);

            // İlişki tanımlamaları
            builder.HasOne(m => m.Parent)
                .WithMany(m => m.SubMenus)
                .HasForeignKey(m => m.ParentId);

            // Örnek menü verileri
            // Self-referencing relationship (kendi kendine ilişki)
            builder.HasOne(m => m.Parent)
                .WithMany(m => m.SubMenus)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Örnek menü verileri
            builder.HasData(
                // Ana Menüler
                new Menu
                {
                    Id = Guid.Parse("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
                    Name = "Ana Sayfa",
                    Description = "Ana Sayfa Menüsü",
                    Url = "/",
                    Icon = "bi bi-house-door-fill",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Ana Sayfa Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    Name = "Makaleler",
                    Description = "Tüm makaleler",
                    Url = "/makaleler",
                    Icon = "bi bi-journal-text",
                    Order = 2,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Makaleler Ana Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    Name = "Muğla",
                    Description = "Muğla hakkında bilgiler",
                    Url = "/mugla",
                    Icon = "bi bi-geo-alt-fill",
                    Order = 3,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Muğla Ana Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
                    Name = "Hakkımızda",
                    Description = "Hakkımızda sayfası",
                    Url = "/hakkimizda",
                    Icon = "bi bi-info-circle-fill",
                    Order = 4,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Hakkımızda Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"),
                    Name = "İletişim",
                    Description = "İletişim sayfası",
                    Url = "/iletisim",
                    Icon = "bi bi-telephone-fill",
                    Order = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "İletişim Menüsü"
                },
                
                // Makaleler Alt Menüleri
                new Menu
                {
                    Id = Guid.Parse("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
                    Name = "Gezi Rehberi",
                    Description = "Gezi rehberi makaleleri",
                    Url = "/makaleler/gezi-rehberi",
                    Icon = "bi bi-map-fill",
                    Order = 1,
                    ParentId = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Gezi Rehberi Alt Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
                    Name = "Tarih ve Kültür",
                    Description = "Tarih ve kültür makaleleri",
                    Url = "/makaleler/tarih-kultur",
                    Icon = "bi bi-bank",
                    Order = 2,
                    ParentId = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Tarih ve Kültür Alt Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("e75e6faa-6c4c-4bd6-95f5-2c2e82c8ed03"),
                    Name = "Doğa ve Aktiviteler",
                    Description = "Doğa ve aktivite makaleleri",
                    Url = "/makaleler/doga-aktiviteler",
                    Icon = "bi bi-tree-fill",
                    Order = 3,
                    ParentId = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Doğa ve Aktiviteler Alt Menüsü"
                },
                
                // Muğla Alt Menüleri
                new Menu
                {
                    Id = Guid.Parse("7e29265f-d672-42a7-9d84-47b564ebad69"),
                    Name = "Bodrum",
                    Description = "Bodrum hakkında bilgiler",
                    Url = "/mugla/bodrum",
                    Icon = "bi bi-geo-fill",
                    Order = 1,
                    ParentId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Bodrum Alt Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
                    Name = "Marmaris",
                    Description = "Marmaris hakkında bilgiler",
                    Url = "/mugla/marmaris",
                    Icon = "bi bi-geo-fill",
                    Order = 2,
                    ParentId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Marmaris Alt Menüsü"
                },
                new Menu
                {
                    Id = Guid.Parse("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
                    Name = "Fethiye",
                    Description = "Fethiye hakkında bilgiler",
                    Url = "/mugla/fethiye",
                    Icon = "bi bi-geo-fill",
                    Order = 3,
                    ParentId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Fethiye Alt Menüsü"
                }
            );
        }
    }
}

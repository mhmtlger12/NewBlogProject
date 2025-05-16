using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            // **Tablo Adı**
            builder.ToTable("Menus").HasComment("Menüler");

            //primaryKey tanımladık
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Url).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.Icon).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Order).IsRequired();

            //ortak alanlar
            builder.Property(x => x.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).IsRequired(false).HasMaxLength(500);

            // İlişkiler
            // Self-referencing relationship (kendi kendine ilişki)
            builder.HasOne(m => m.Parent)
                .WithMany(m => m.SubMenus)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Örnek menü verileri
            builder.HasData(
                new Menu
                {
                    Id = Guid.Parse("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
                    Name = "Ana Sayfa",
                    Description = "Ana Sayfa Menüsü",
                    Url = "/",
                    Icon = "bi bi-house",
                    Order = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Ana Sayfa Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    Name = "Gezi Rehberi",
                    Description = "Gezi Rehberi Menüsü",
                    Url = "#",
                    Icon = "bi bi-map",
                    Order = 2,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Gezi Rehberi Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
                    Name = "Plajlar",
                    Description = "Plajlar Alt Menüsü",
                    Url = "/Plajlar",
                    Icon = "bi bi-water",
                    Order = 1,
                    ParentId = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Plajlar Alt Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
                    Name = "Tarihi Yerler",
                    Description = "Tarihi Yerler Alt Menüsü",
                    Url = "/TarihiYerler",
                    Icon = "bi bi-building-fill",
                    Order = 2,
                    ParentId = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Tarihi Yerler Alt Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("dfa25617-9fdb-4f9b-bba9-726404d6d87b"),
                    Name = "Doğa Yürüyüşleri",
                    Description = "Doğa Yürüyüşleri Alt Menüsü",
                    Url = "/DogaYuruyusleri",
                    Icon = "bi bi-tree-fill",
                    Order = 3,
                    ParentId = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Doğa Yürüyüşleri Alt Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    Name = "Muğla ve İlçeleri",
                    Description = "Muğla ve İlçeleri Menüsü",
                    Url = "#",
                    Icon = "bi bi-geo-alt",
                    Order = 3,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Muğla ve İlçeleri Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("7e29265f-d672-42a7-9d84-47b564ebad69"),
                    Name = "Bodrum",
                    Description = "Bodrum Alt Menüsü",
                    Url = "/Home/Index?menuId=7e29265f-d672-42a7-9d84-47b564ebad69",
                    Icon = "bi bi-geo-fill",
                    Order = 1,
                    ParentId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Bodrum Alt Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
                    Name = "Marmaris",
                    Description = "Marmaris Alt Menüsü",
                    Url = "/Home/Index?menuId=b33b442b-58b3-400b-a2f5-9231e58a1ff7",
                    Icon = "bi bi-pin-map",
                    Order = 2,
                    ParentId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Marmaris Alt Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
                    Name = "Fethiye",
                    Description = "Fethiye Alt Menüsü",
                    Url = "/Home/Index?menuId=97b6d8c7-6a07-4ef1-8764-d71ab72f812a",
                    Icon = "bi bi-compass",
                    Order = 3,
                    ParentId = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Fethiye Alt Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
                    Name = "Hakkımızda",
                    Description = "Hakkımızda Menüsü",
                    Url = "/Home/About",
                    Icon = "bi bi-info-circle",
                    Order = 4,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Hakkımızda Menüsü",
                },
                new Menu
                {
                    Id = Guid.Parse("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"),
                    Name = "İletişim",
                    Description = "İletişim Menüsü",
                    Url = "/Home/Contact",
                    Icon = "bi bi-telephone",
                    Order = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "İletişim Menüsü",
                }
            );
        }
    }
}

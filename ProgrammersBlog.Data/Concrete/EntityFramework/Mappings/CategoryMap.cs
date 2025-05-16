using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // **Tablo Adı**
            builder.ToTable("Categories").HasComment("Kategoriler");

            //primaryKey tanımladık
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);

            //ortak alanlar
            builder.Property(x => x.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();


            builder.HasData(
    new Category
    {
        Id = Guid.Parse("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
        Name = "C#",
        Description = "C# Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "C# Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
        Name = "C++",
        Description = "C++ Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "C++ Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
        Name = "JavaScript",
        Description = "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "JavaScript Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
        Name = "Typescript",
        Description = "Typescript Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "Typescript Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("dfa25617-9fdb-4f9b-bba9-726404d6d87b"),
        Name = "Java",
        Description = "Java Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "Java Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
        Name = "Python",
        Description = "Python Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "Python Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("7e29265f-d672-42a7-9d84-47b564ebad69"),
        Name = "Php",
        Description = "Php Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "Php Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
        Name = "Kotlin",
        Description = "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "Kotlin Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
        Name = "Swift",
        Description = "Swift Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "Swift Blog Kategorisi",
    },
    new Category
    {
        Id = Guid.Parse("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
        Name = "Ruby",
        Description = "Ruby Programlama Dili ile İlgili En Güncel Bilgiler",
        IsActive = true,
        IsDeleted = false,
        CreatedByName = "InitialCreate",
        CreatedDate = DateTime.Now,
        ModifiedByName = "InitialCreate",
        ModifiedDate = DateTime.Now,
        Note = "Ruby Blog Kategorisi",
    }
);

        }
    }
}
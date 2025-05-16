using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("Roles");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(100);
            builder.Property(u => u.NormalizedName).HasMaxLength(100);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            builder.HasData(
                new Role
                {
                    Id = Guid.Parse("f7b90591-d678-462d-9f3d-5497dbd43c5d"),
                    Name = "Category.Create",
                    NormalizedName = "CATEGORY.CREATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("65cb04f5-bdd6-4b3b-9611-9a243c2f982b"),
                    Name = "Category.Read",
                    NormalizedName = "CATEGORY.READ",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("cc5c2c3b-e013-4317-8a6d-387f6e6b4e70"),
                    Name = "Category.Update",
                    NormalizedName = "CATEGORY.UPDATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("46e3b3b3-bb4f-4755-8257-68fe1b6bca34"),
                    Name = "Category.Delete",
                    NormalizedName = "CATEGORY.DELETE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("f2c6c3a5-d7e6-4bd4-8a2f-3b0e8175a1d7"),
                    Name = "Menu.Create",
                    NormalizedName = "MENU.CREATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("a8b2c7e3-d5f6-4e9a-8c1d-7b3e9f5a2c4d"),
                    Name = "Menu.Read",
                    NormalizedName = "MENU.READ",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("d9e4a7b2-c5f8-4e1d-9b3a-8c7e6f5a4d2b"),
                    Name = "Menu.Update",
                    NormalizedName = "MENU.UPDATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("e7c9b1a4-d8f2-4e5c-9b7a-8d6e5f4c3b2a"),
                    Name = "Menu.Delete",
                    NormalizedName = "MENU.DELETE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("d1c1d472-1a4d-4d43-9f85-05b8975f9e23"),
                    Name = "Article.Create",
                    NormalizedName = "ARTICLE.CREATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2"),
                    Name = "Article.Read",
                    NormalizedName = "ARTICLE.READ",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("0730f01f-58f5-4f99-a28c-d51c121694f2"),
                    Name = "Article.Update",
                    NormalizedName = "ARTICLE.UPDATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("b7f3894d-d399-479a-a9cf-5d195f02b984"),
                    Name = "Article.Delete",
                    NormalizedName = "ARTICLE.DELETE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("c9fc3b36-73f4-4e5b-bb16-cf84d1740189"),
                    Name = "User.Create",
                    NormalizedName = "USER.CREATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("cf8d7b2a-69de-467f-b496-f56ed8c8d019"),
                    Name = "User.Read",
                    NormalizedName = "USER.READ",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("b28789c7-1a4d-4a58-8043-50499e39a0f1"),
                    Name = "User.Update",
                    NormalizedName = "USER.UPDATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("ed14e6e9-05b4-4065-b300-213589e16ff3"),
                    Name = "User.Delete",
                    NormalizedName = "USER.DELETE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("9a20d3de-e7c0-44b7-b446-d287453064f1"),
                    Name = "Role.Create",
                    NormalizedName = "ROLE.CREATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("e1bc238f-4d9c-4261-b2d5-bbe8d6e6b6ca"),
                    Name = "Role.Read",
                    NormalizedName = "ROLE.READ",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("30e26bb1-c7b7-4c10-98da-b775b861bc7a"),
                    Name = "Role.Update",
                    NormalizedName = "ROLE.UPDATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("8b07b9e4-1b7b-4525-a22a-b3d98d4e647d"),
                    Name = "Role.Delete",
                    NormalizedName = "ROLE.DELETE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("6d5878d7-8a8f-46a6-8808-b9717421b021"),
                    Name = "Comment.Create",
                    NormalizedName = "COMMENT.CREATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("e1b835c9-d8a7-4ca4-9cc4-c6e5e3deaa45"),
                    Name = "Comment.Read",
                    NormalizedName = "COMMENT.READ",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("b4cf3987-e4ac-4da7-b931-bbd59c4d20ed"),
                    Name = "Comment.Update",
                    NormalizedName = "COMMENT.UPDATE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("8a9418f1-c27f-4303-a256-48736d06bbed"),
                    Name = "Comment.Delete",
                    NormalizedName = "COMMENT.DELETE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d"),
                    Name = "AdminArea.Home.Read",
                    NormalizedName = "ADMINAREA.HOME.READ",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = Guid.Parse("ab56d30e-7d6c-4b47-80e5-7cbce544e925"),
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );

        }
    }
}

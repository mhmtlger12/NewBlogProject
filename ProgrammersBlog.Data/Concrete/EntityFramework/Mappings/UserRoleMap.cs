using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });
            // Maps to the AspNetUserRoles table
            builder.ToTable("UserRoles");
            builder.HasData(
                // Admin kullanıcısı için tüm roller (SuperAdmin ve diğer roller)
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("ab56d30e-7d6c-4b47-80e5-7cbce544e925") // SuperAdmin
                },
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d") // AdminArea.Home.Read
                },

                // Category yetkileri - adminuser
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("f7b90591-d678-462d-9f3d-5497dbd43c5d") // Category.Create
                },
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("65cb04f5-bdd6-4b3b-9611-9a243c2f982b") // Category.Read
                },
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("cc5c2c3b-e013-4317-8a6d-387f6e6b4e70") // Category.Update
                },
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("46e3b3b3-bb4f-4755-8257-68fe1b6bca34") // Category.Delete
                },

                // Article yetkileri - adminuser
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("d1c1d472-1a4d-4d43-9f85-05b8975f9e23") // Article.Create
                },
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2") // Article.Read
                },
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("0730f01f-58f5-4f99-a28c-d51c121694f2") // Article.Update
                },
                new UserRole
                {
                    UserId = Guid.Parse("9f34e61b-78fc-46d3-a179-6c32e62ac195"), // adminuser
                    RoleId = Guid.Parse("b7f3894d-d399-479a-a9cf-5d195f02b984") // Article.Delete
                },

                // Editor kullanıcısı için roller
                // Article yetkileri - editoruser
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("d1c1d472-1a4d-4d43-9f85-05b8975f9e23") // Article.Create
                },
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2") // Article.Read
                },
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("0730f01f-58f5-4f99-a28c-d51c121694f2") // Article.Update
                },
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("b7f3894d-d399-479a-a9cf-5d195f02b984") // Article.Delete
                },

                // Comment yetkileri - editoruser
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("6d5878d7-8a8f-46a6-8808-b9717421b021") // Comment.Create
                },
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("e1b835c9-d8a7-4ca4-9cc4-c6e5e3deaa45") // Comment.Read
                },
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("b4cf3987-e4ac-4da7-b931-bbd59c4d20ed") // Comment.Update
                },
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("8a9418f1-c27f-4303-a256-48736d06bbed") // Comment.Delete
                },

                // Category yetkileri - editoruser (sadece okuma)
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("65cb04f5-bdd6-4b3b-9611-9a243c2f982b") // Category.Read
                },

                // AdminArea erişimi - editoruser
                new UserRole
                {
                    UserId = Guid.Parse("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), // editoruser
                    RoleId = Guid.Parse("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d") // AdminArea.Home.Read
                }
            );
        }
    }
}
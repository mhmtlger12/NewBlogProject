using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgrammersBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Kategoriler");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Callsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: true),
                    RequestQueryString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Menüler");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    InstagramLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    GitHubLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WebsiteLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Makaleler");

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                },
                comment: "Yorumlar");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7306), "Ruby Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7307), "Ruby", "Ruby Blog Kategorisi" },
                    { new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7283), "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7284), "JavaScript", "JavaScript Blog Kategorisi" },
                    { new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7287), "Typescript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7287), "Typescript", "Typescript Blog Kategorisi" },
                    { new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7297), "Php Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7298), "Php", "Php Blog Kategorisi" },
                    { new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7303), "Swift Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7304), "Swift", "Swift Blog Kategorisi" },
                    { new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7276), "C# Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7276), "C#", "C# Blog Kategorisi" },
                    { new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7300), "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7301), "Kotlin", "Kotlin Blog Kategorisi" },
                    { new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7294), "Python Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7294), "Python", "Python Blog Kategorisi" },
                    { new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7280), "C++ Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7281), "C++", "C++ Blog Kategorisi" },
                    { new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7291), "Java Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(7291), "Java", "Java Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Icon", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note", "Order", "ParentId", "Url" },
                values: new object[,]
                {
                    { new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8841), "Hakkımızda sayfası", "bi bi-info-circle-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8841), "Hakkımızda", "Hakkımızda Menüsü", 4, null, "/hakkimizda" },
                    { new Guid("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8844), "İletişim sayfası", "bi bi-telephone-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8845), "İletişim", "İletişim Menüsü", 5, null, "/iletisim" },
                    { new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8828), "Ana Sayfa Menüsü", "bi bi-house-door-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8829), "Ana Sayfa", "Ana Sayfa Menüsü", 1, null, "/" },
                    { new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8837), "Muğla hakkında bilgiler", "bi bi-geo-alt-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8837), "Muğla", "Muğla Ana Menüsü", 3, null, "/mugla" },
                    { new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8833), "Tüm makaleler", "bi bi-journal-text", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8833), "Makaleler", "Makaleler Ana Menüsü", 2, null, "/makaleler" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0730f01f-58f5-4f99-a28c-d51c121694f2"), "37afaa6b-fbc3-45f4-97dc-b26e00034f88", "Article.Update", "ARTICLE.UPDATE" },
                    { new Guid("30e26bb1-c7b7-4c10-98da-b775b861bc7a"), "e167c7f6-5bb9-4675-aa59-e0fba25d8387", "Role.Update", "ROLE.UPDATE" },
                    { new Guid("46e3b3b3-bb4f-4755-8257-68fe1b6bca34"), "55dc3d1c-d90a-489c-9dfe-8999743e2f76", "Category.Delete", "CATEGORY.DELETE" },
                    { new Guid("65cb04f5-bdd6-4b3b-9611-9a243c2f982b"), "7704b35c-22a7-4e96-975e-bb4168b1b588", "Category.Read", "CATEGORY.READ" },
                    { new Guid("6d5878d7-8a8f-46a6-8808-b9717421b021"), "7f7bbba4-cf02-44d1-82ae-45b5c79d99cd", "Comment.Create", "COMMENT.CREATE" },
                    { new Guid("8a9418f1-c27f-4303-a256-48736d06bbed"), "d0cb5b38-bbbf-4d69-aa05-b73c6cda3930", "Comment.Delete", "COMMENT.DELETE" },
                    { new Guid("8b07b9e4-1b7b-4525-a22a-b3d98d4e647d"), "563df562-68b3-4f2a-9fdb-ecbf391a268e", "Role.Delete", "ROLE.DELETE" },
                    { new Guid("9a20d3de-e7c0-44b7-b446-d287453064f1"), "9d7fb89d-01b1-415f-b7b1-75ae16a34ecd", "Role.Create", "ROLE.CREATE" },
                    { new Guid("a8b2c7e3-d5f6-4e9a-8c1d-7b3e9f5a2c4d"), "a7d77479-6a29-417e-be95-ab3bdd5a9de1", "Menu.Read", "MENU.READ" },
                    { new Guid("ab56d30e-7d6c-4b47-80e5-7cbce544e925"), "4347a60f-2b87-4892-a933-ad1be3da9bd2", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b28789c7-1a4d-4a58-8043-50499e39a0f1"), "93a6d54d-64a6-466a-be2e-75c9bcc2cb18", "User.Update", "USER.UPDATE" },
                    { new Guid("b4cf3987-e4ac-4da7-b931-bbd59c4d20ed"), "2000d65a-5f32-4291-938b-a24abc005d08", "Comment.Update", "COMMENT.UPDATE" },
                    { new Guid("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d"), "ee02497c-f727-4cb4-9535-c782453ee213", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { new Guid("b7f3894d-d399-479a-a9cf-5d195f02b984"), "1d3e3e95-3071-4eca-9b55-1e48bb7aeb70", "Article.Delete", "ARTICLE.DELETE" },
                    { new Guid("c9fc3b36-73f4-4e5b-bb16-cf84d1740189"), "208657c1-6783-437c-837e-0e208d33e123", "User.Create", "USER.CREATE" },
                    { new Guid("cc5c2c3b-e013-4317-8a6d-387f6e6b4e70"), "75f2a00d-23fc-4307-a97e-a2bbef1e92ea", "Category.Update", "CATEGORY.UPDATE" },
                    { new Guid("cf8d7b2a-69de-467f-b496-f56ed8c8d019"), "48a74e77-2c90-4e88-b21b-dac219397fb2", "User.Read", "USER.READ" },
                    { new Guid("d1c1d472-1a4d-4d43-9f85-05b8975f9e23"), "c815c58e-06aa-4b8d-b09d-59c1d66359f6", "Article.Create", "ARTICLE.CREATE" },
                    { new Guid("d9e4a7b2-c5f8-4e1d-9b3a-8c7e6f5a4d2b"), "cd41deae-ead4-4cc9-9fff-b1cc1455b1de", "Menu.Update", "MENU.UPDATE" },
                    { new Guid("e1b835c9-d8a7-4ca4-9cc4-c6e5e3deaa45"), "62250339-a388-45c8-ba91-26c7435d58ad", "Comment.Read", "COMMENT.READ" },
                    { new Guid("e1bc238f-4d9c-4261-b2d5-bbe8d6e6b6ca"), "7e10caa5-fb87-4613-8ea9-9ad3092b51ce", "Role.Read", "ROLE.READ" },
                    { new Guid("e7c9b1a4-d8f2-4e5c-9b7a-8d6e5f4c3b2a"), "6e9f1217-53ae-4a21-a2aa-eb12a314b45c", "Menu.Delete", "MENU.DELETE" },
                    { new Guid("ed14e6e9-05b4-4065-b300-213589e16ff3"), "c5b56672-9847-42fb-9c04-8f84129304a5", "User.Delete", "USER.DELETE" },
                    { new Guid("f2c6c3a5-d7e6-4bd4-8a2f-3b0e8175a1d7"), "02058e29-af92-4179-b2bc-97d0cdaaa893", "Menu.Create", "MENU.CREATE" },
                    { new Guid("f7b90591-d678-462d-9f3d-5497dbd43c5d"), "c2b46a20-7baf-41aa-b230-76c2a88d6d96", "Category.Create", "CATEGORY.CREATE" },
                    { new Guid("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2"), "a351c309-e920-4595-8236-23d773dddbc9", "Article.Read", "ARTICLE.READ" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), "Admin User of ProgrammersBlog", 0, "9f8813de-c185-45fd-ac17-4cea05e3a1d8", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAIAAYagAAAAEABDxUs4O3I9fddmN/dS8cEHMiw29Qq0lI2sAYKp1IEHtQ7G7DoW447haT4qtFKTog==", "+905555555555", true, "/userImages/defaultUser.png", "a396a679-c353-4118-ab90-e2dbf0dcda65", "https://twitter.com/adminuser", false, "adminuser", "https://programmersblog.com/", "https://youtube.com/adminuser" },
                    { new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), "Editor User of ProgrammersBlog", 0, "e1673020-9edb-4001-b84d-c0827f016cd4", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAIAAYagAAAAEOYc4jhAs5elic803lwhl9Y1h5hbT2QXAe/97fUhh1kg0BpLwlUMPdMPTGx1OqkPRQ==", "+905555555555", true, "/userImages/defaultUser.png", "81ce7770-3b46-454d-9f6b-8057853d60c4", "https://twitter.com/editoruser", false, "editoruser", "https://programmersblog.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "MenuId", "ModifiedByName", "ModifiedDate", "Note", "PublishDate", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("3d8533eb-3c9e-4d29-97e6-7c4e7244e4f8"), null, 12, "Marmaris'in kristal berraklığındaki koylarını tekne turuyla keşfedin. Cennet Adası, Fosforlu Mağara, Akvaryum Koyu ve Kızkumu Plajı gibi eşsiz doğal güzelliklere sahip noktalara yapılan günlük tekne turları unutulmaz anılar bırakıyor.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6517), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6515), true, false, new Guid("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6517), "Marmaris tekne turları makalesi", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6516), "Muğla Gezi Rehberi", "Marmaris tekne turları ve popüler rota önerileri", "Marmaris, tekne turu, Cennet Adası, Kızkumu", "postImages/marmaris-tekne.jpg", "Marmaris'te Tekne Turu Rotaları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 8940 },
                    { new Guid("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"), null, 1, "Muğla il merkezi, Osmanlı ve Cumhuriyet dönemlerinden kalma tarihi yapıları, müzeleri ve geleneksel Türk mimarisini yansıtan evleriyle tam bir açık hava müzesi niteliğindedir. 'Beyaz Kent' olarak da anılan Muğla'nın tarihi dokusunu en iyi yansıtan Saburhane Mahallesi, restore edilmiş geleneksel Muğla evleriyle ünlüdür. Bacaları ve cumbalı evleriyle dikkat çeken bu mahalle, fotoğraf tutkunları için de eşsiz kareler sunmaktadır. Kent merkezindeki Kurşunlu Cami, Ulu Cami ve Konakaltı Han gibi tarihi yapılar, Osmanlı mimarisinin en güzel örnekleri arasındadır. Bu makalede, Muğla merkezdeki tarihi ve kültürel değerleri tanıtacak, ziyaretçilere öneriler sunacağız.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6476), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6474), true, false, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6476), "Muğla merkez kültür ve tarih rehberi", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6475), "Muğla Kültür Rehberi", "Muğla merkez'in tarihi ve kültürel değerleri hakkında detaylı rehber", "Muğla, Saburhane, kültür, tarih", "postImages/mugla-merkez.jpg", "Muğla Merkez'in Tarihi ve Kültürel Değerleri", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 750 },
                    { new Guid("42eb2c71-47f5-4bec-b31e-e71e11c39c28"), null, 0, "Muğla Rehberi, Türkiye'nin en güzel illerinden biri olan Muğla'nın doğal güzelliklerini, tarihi ve kültürel zenginliklerini tanıtmak amacıyla kurulmuş bir platformdur. Amacımız, Muğla'nın eşsiz koylarını, plajlarını, antik kentlerini, lezzetli mutfağını ve zengin kültürünü hem yerli hem de yabancı turistlere tanıtmak ve bölgeye gelen ziyaretçilere rehberlik etmektir. Ekibimiz, Muğla'yı karış karış gezen, bölgeyi iyi tanıyan ve seven uzmanlardan oluşmaktadır. Sitemizde Bodrum, Marmaris, Fethiye, Datça, Köyceğiz gibi popüler tatil beldelerinin yanı sıra, Muğla'nın daha az bilinen güzelliklerini de keşfedebilirsiniz. Sizlere en doğru ve güncel bilgileri sunmak için sürekli olarak içeriğimizi güncelliyor ve genişletiyoruz. Muğla Rehberi olarak, sizlerin Muğla'da unutulmaz bir tatil geçirmeniz için elimizden gelen her şeyi yapmaya hazırız.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6483), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6482), true, false, new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6484), "Hakkımızda sayfası", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6482), "Muğla Rehberi Ekibi", "Muğla Rehberi hakkında bilgiler ve misyonumuz", "Muğla Rehberi, hakkımızda, misyon, vizyon, Muğla tanıtım", "postImages/mugla-rehberi-logo.jpg", "Muğla Rehberi Hakkında", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 500 },
                    { new Guid("a25d2b14-7f5c-4d2f-9c98-b3c6e8b3a2d1"), null, 8, "Muğla'nın incisi Fethiye, Türkiye'nin en güzel koylarına ve plajlarına ev sahipliği yapıyor. Ölüdeniz'in turkuaz suları ve beyaz kumsalı, dünyaca ünlü Kelebekler Vadisi, saklı cennet Kabak Koyu ve tekne turlarıyla keşfedebileceğiniz 12 Adalar, her yıl binlerce turisti ağırlıyor.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6504), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6503), true, false, new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6505), "Fethiye plajları makalesi", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6504), "Muğla Gezi Rehberi", "Fethiye'nin muhteşem koyları ve plajları hakkında detaylı rehber", "Fethiye, Ölüdeniz, Kelebekler Vadisi, Kabak Koyu, plajlar", "postImages/fethiye-plajlar.jpg", "Fethiye'nin Eşsiz Koyları ve Plajları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 15420 },
                    { new Guid("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"), null, 0, "Muğla'nın iç kesimlerinde yer alan Kavaklıdere ve Yatağan ilçeleri, el değmemiş doğası ve zengin tarihi mirası ile keşfedilmeyi bekleyen gizli hazinelerdir. Kavaklıdere, ismini verimli topraklarında yetişen kavak ağaçlarından almış olup, bağcılık ve şarapçılık kültürü ile ünlüdür. İlçenin dağlık alanlarında bulunan Menteşe Yaylası, serin iklimi ve muhteşem manzarasıyla yazın bunaltan sıcaklardan kaçmak isteyenler için ideal bir sığınak. Yatağan ise antik dönemden kalma Stratonikeia Antik Kenti ile ünlüdür. 'Mermer Şehir' olarak da bilinen bu antik kent, Roma, Helenistik ve Bizans dönemlerine ait kalıntılarıyla tarih meraklıları için vazgeçilmez bir durak. Yatağan aynı zamanda geleneksel Türk kılıcı olan 'yatağan'ın üretim merkezi olarak da tarihe geçmiştir. Bölgede yer alan Bozüyük ve Turgut gibi eski Türk yerleşimleri, yüzlerce yıllık çınar ağaçları, tarihi camileri ve geleneksel Türk köy yaşamını yansıtan dokusuyla otantik bir atmosfer sunuyor. Yerel halk tarafından hala yaşatılan geleneksel el sanatları, özellikle halıcılık ve dokumacılık, bölgenin kültürel zenginliklerini tamamlıyor.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6498), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6497), true, false, new Guid("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6499), "Kavaklıdere ve Yatağan", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6497), "Muğla Rehberi", "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri", "Kavaklıdere, Yatağan, Stratonikeia, bağcılık, yaylalar, tarih, Muğla", "postImages/defaultThumbnail.jpg", "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 26777 },
                    { new Guid("c20558d8-b0fd-4142-a527-0da9910deefc"), null, 0, "Muğla, Türkiye'nin güneybatısında yer alan, eşsiz doğal güzellikleri, zengin tarihi ve kültürel mirasıyla öne çıkan bir ilimizdir. Bodrum, Marmaris, Fethiye gibi dünyaca ünlü tatil beldeleriyle her yıl milyonlarca turisti ağırlayan Muğla, aynı zamanda antik kentleri, koyları, plajları ve yemek kültürüyle de ziyaretçilerine unutulmaz deneyimler sunmaktadır.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6427), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6425), true, false, new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6428), "Ana sayfa tanıtım makalesi", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6426), "Muğla Rehberi", "Muğla'nın güzellikleri ve gezilecek yerleri hakkında genel bilgiler", "Muğla, Bodrum, Marmaris, Fethiye, tatil, gezi, rehber", "postImages/mugla-genel.jpg", "Muğla'ya Hoş Geldiniz", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 1500 },
                    { new Guid("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"), null, 0, "Muğla Rehberi ekibi olarak, sorularınız, önerileriniz ve işbirliği talepleriniz için her zaman hizmetinizdeyiz. Aşağıdaki iletişim kanallarından bize ulaşabilirsiniz:\n\n**E-posta:** info@muglarehberi.com\n\n**Telefon:** +90 252 123 45 67\n\n**Adres:** Kavaklıdere Mah. Atatürk Cad. No:123, 48000 Muğla Merkez\n\n**Sosyal Medya Hesaplarımız:**\n- Instagram: @muglarehberi\n- Facebook: Muğla Rehberi\n- Twitter: @muglarehberi\n\nMuğla'da gezilecek yerler, konaklama, ulaşım ve diğer konularda bilgi almak için bizimle iletişime geçebilirsiniz. Ayrıca Muğla ile ilgili deneyimlerinizi ve fotoğraflarınızı bizimle paylaşmak isterseniz, sosyal medya hesaplarımızda bizi etiketleyebilir veya e-posta adresimize gönderebilirsiniz. Sizden gelecek her türlü geri bildirim, sitemizi ve hizmetlerimizi geliştirmemize yardımcı olacaktır.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6492), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6490), true, false, new Guid("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6492), "İletişim sayfası", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6491), "Muğla Rehberi Ekibi", "Muğla Rehberi iletişim bilgileri ve iletişim formu", "iletişim, Muğla Rehberi, telefon", "postImages/iletisim.jpg", "Bizimle İletişime Geçin", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 400 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Icon", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note", "Order", "ParentId", "Url" },
                values: new object[,]
                {
                    { new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8854), "Tarih ve kültür makaleleri", "bi bi-bank", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8855), "Tarih ve Kültür", "Tarih ve Kültür Alt Menüsü", 2, new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "/makaleler/tarih-kultur" },
                    { new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8850), "Gezi rehberi makaleleri", "bi bi-map-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8850), "Gezi Rehberi", "Gezi Rehberi Alt Menüsü", 1, new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "/makaleler/gezi-rehberi" },
                    { new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8863), "Bodrum hakkında bilgiler", "bi bi-geo-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8863), "Bodrum", "Bodrum Alt Menüsü", 1, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "/mugla/bodrum" },
                    { new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8872), "Fethiye hakkında bilgiler", "bi bi-geo-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8873), "Fethiye", "Fethiye Alt Menüsü", 3, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "/mugla/fethiye" },
                    { new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8868), "Marmaris hakkında bilgiler", "bi bi-geo-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8868), "Marmaris", "Marmaris Alt Menüsü", 2, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "/mugla/marmaris" },
                    { new Guid("e75e6faa-6c4c-4bd6-95f5-2c2e82c8ed03"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8859), "Doğa ve aktivite makaleleri", "bi bi-tree-fill", true, false, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(8859), "Doğa ve Aktiviteler", "Doğa ve Aktiviteler Alt Menüsü", 3, new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "/makaleler/doga-aktiviteler" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0730f01f-58f5-4f99-a28c-d51c121694f2"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("46e3b3b3-bb4f-4755-8257-68fe1b6bca34"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("65cb04f5-bdd6-4b3b-9611-9a243c2f982b"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("ab56d30e-7d6c-4b47-80e5-7cbce544e925"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("b7f3894d-d399-479a-a9cf-5d195f02b984"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("cc5c2c3b-e013-4317-8a6d-387f6e6b4e70"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("d1c1d472-1a4d-4d43-9f85-05b8975f9e23"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("f7b90591-d678-462d-9f3d-5497dbd43c5d"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2"), new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195") },
                    { new Guid("0730f01f-58f5-4f99-a28c-d51c121694f2"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("65cb04f5-bdd6-4b3b-9611-9a243c2f982b"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("6d5878d7-8a8f-46a6-8808-b9717421b021"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("8a9418f1-c27f-4303-a256-48736d06bbed"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("b4cf3987-e4ac-4da7-b931-bbd59c4d20ed"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("b7f3894d-d399-479a-a9cf-5d195f02b984"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("d1c1d472-1a4d-4d43-9f85-05b8975f9e23"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("e1b835c9-d8a7-4ca4-9cc4-c6e5e3deaa45"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") },
                    { new Guid("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2"), new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4") }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "MenuId", "ModifiedByName", "ModifiedDate", "Note", "PublishDate", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"), null, 2, "Antik çağda Halikarnas olarak bilinen Bodrum, dünyanın yedi harikasından biri olan Mausoleum'a ev sahipliği yapmıştır. Günümüzde Bodrum Kalesi içinde yer alan Sualtı Arkeoloji Müzesi, dünyanın en önemli sualtı arkeoloji müzelerinden biridir. Bodrum'un beyaz badanalı, mavi pencereli evleri, dar sokakları ve renkli begonvilleri ile süslü sokakları, kentin karakteristik özelliklerini oluşturmaktadır. Bodrum Antik Tiyatrosu, Myndos Kapısı, Pedasa Antik Kenti ve Zeki Müren Sanat Müzesi gibi kültürel miras alanları, Bodrum'un zengin tarihini yansıtmaktadır. Bu makalede, Bodrum'un tarihi ve kültürel zenginliklerini keşfedecek, ziyaretçilerin görmesi gereken yerleri ve Bodrum'un kültürel yaşamını detaylı olarak inceleyeceğiz.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6456), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6455), true, false, new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6457), "Bodrum'un tarihi ve kültürel değerleri", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6455), "Muğla Kültür Rehberi", "Bodrum'un tarihi ve kültürel zenginlikleri hakkında detaylı rehber", "Bodrum, Kalesi, Halikarnas, Mausoleum, Müze", "postImages/bodrum-kalesi.jpg", "Bodrum'un Tarihi ve Kültürel Zenginlikleri", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 850 },
                    { new Guid("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"), null, 6, "Muğla'nın incisi Fethiye, Türkiye'nin en güzel koylarına ve plajlarına ev sahipliği yapmaktadır. Ölüdeniz'in turkuaz suları ve beyaz kumsalı, dünyaca ünlü Kelebekler Vadisi, saklı cennet Kabak Koyu ve tekne turlarıyla keşfedebileceğiniz 12 Adalar, her yıl binlerce turisti ağırlamaktadır. Fethiye'nin berrak sularında yüzmek, Belcekız Plajı'nda güneşlenmek ve Gemiler Adası'nı keşfetmek, unutulmaz bir tatil deneyimi yaşatmaktadır. Bu makalede, Fethiye'nin en güzel koylarını ve plajlarını tanıtacak, ziyaretçilere öneriler sunacağız.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6469), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6468), true, false, new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6470), "Fethiye'nin plajları ve koyları", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6468), "Muğla Plaj Rehberi", "Fethiye'nin eşsiz koyları ve plajları hakkında detaylı rehber", "Fethiye, Ölüdeniz, plajlar, koylar", "postImages/fethiye-oludeniz.jpg", "Fethiye'nin Eşsiz Koyları ve Plajları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 1300 },
                    { new Guid("1c20d2d7-27d1-4d25-90b9-bba97e5ea56f"), null, 5, "Bodrum Kalesi, kentin simgesi olan muhteşem bir Ortaçağ yapısı. Sualtı Arkeoloji Müzesi olarak hizmet veren kale, dünyanın en önemli sualtı arkeolojisi merkezlerinden biri. Antik batıklardan çıkarılan eserler burada sergileniyor.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6511), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6509), true, false, new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6511), "Bodrum Kalesi tanıtım makalesi", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6510), "Muğla Gezi Rehberi", "Bodrum Kalesi ve Sualtı Arkeoloji Müzesi detaylı gezi rehberi", "Bodrum Kalesi, Sualtı Müzesi, tarih, arkeoloji", "postImages/bodrum-kalesi.jpg", "Bodrum'un Tarihi Kalesi ve Sualtı Müzesi", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 12350 },
                    { new Guid("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"), null, 0, "Muğla'nın göz bebeği Marmaris, eşsiz doğal güzellikleriyle her yıl milyonlarca turisti ağırlıyor. İçmeler, Turunç ve Selimiye gibi muhteşem koylarıyla ünlü olan Marmaris, yat turizmi için de ideal bir destinasyon. Marmaris Marina ve Netsel Marina'da demirlemiş lüks yatlar, bölgenin prestijiyle bütünleşiyor. Marmaris'in turkuaz renkli koylarında tekne turu yapmak, Kleopatra Plajı'nda denizin tadını çıkarmak ve Cennet Adası'nı keşfetmek, burada yapılabilecek en keyifli aktiviteler arasında. Bunun yanı sıra doğa tutkunları için Marmaris'in çevresindeki ormanlar, trekking, kano ve safari turları için mükemmel fırsatlar sunuyor. Turgut Şelalesi'nin serinletici suları, Günnücek Mesire Yeri'nin yeşil örtüsü ve Nimara Mağarası'nın gizemli atmosferi, Marmaris'in keşfedilmeyi bekleyen doğal hazineleri. Ayrıca, Marmaris Kale ve Müzesi, tarihi İbrahim Ağa Camii ve antik Amos kenti, bölgenin kültürel zenginliğini yansıtan önemli eserler arasında yer alıyor.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6450), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6449), true, false, new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6450), "Marmaris'in turistik değerleri", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6449), "Muğla Rehberi", "Marmaris'te Deniz ve Doğa Turizmi", "Marmaris, İçmeler, Turunç, marina, Muğla", "postImages/defaultThumbnail.jpg", "Marmaris'te Deniz ve Doğa Turizmi", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 12 },
                    { new Guid("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"), null, 4, "Muğla'nın en popüler tatil beldelerinden biri olan Marmaris, muhteşem doğası ve berrak deniziyle her yıl binlerce turisti ağırlamaktadır. İçmeler, Turunç, Selimiye ve Bozburun gibi güzel koylara sahip olan Marmaris, aynı zamanda yat turizmi için de önemli bir merkezdir. Marmaris Marina ve Netsel Marina'da demirlemiş lüks yatlar, bölgenin prestijini yansıtmaktadır. Marmaris'in turkuaz renkli koylarında tekne turu yapmak, Kleopatra Plajı'nda yüzmek ve Cennet Adası'nı keşfetmek, ziyaretçilerin en sevdiği aktiviteler arasındadır. Ayrıca Turgut Şelalesi, Nimara Mağarası ve Marmaris Milli Parkı gibi doğal güzellikler de bölgenin çekiciliğini artırmaktadır. Bu makalede, Marmaris'in en güzel plajlarını, koylarını ve doğal güzelliklerini keşfedecek, ziyaretçilere öneriler sunacağız.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6463), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6461), true, false, new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6463), "Marmaris'in doğal güzellikleri ve plajları", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6462), "Muğla Doğa Rehberi", "Marmaris'in doğal güzellikleri ve plajları hakkında detaylı rehber", "Marmaris, İçmeler, plajlar, koylar", "postImages/marmaris-plaj.jpg", "Marmaris'in Doğal Güzellikleri ve Plajları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 1100 },
                    { new Guid("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"), null, 5, "Muğla sahilleri, Türkiye'nin en güzel plajlarına ve koylarına ev sahipliği yapmaktadır. Ölüdeniz, Çalış Plajı, İçmeler, Akyaka ve Cleopatra Plajı gibi dünyaca ünlü plajların yanı sıra, Kelebekler Vadisi, Kabak Koyu ve Gökova Koyu gibi el değmemiş doğal güzellikleriyle de turistleri kendine çekmektedir. Bu rehberde, Muğla'nın en güzel plajlarını ve koylarını keşfedecek, her birinin özellikleri ve nasıl ulaşılacağı hakkında detaylı bilgilere ulaşacaksınız.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6436), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6435), true, false, new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6437), "Muğla plajları ve koyları rehberi", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6435), "Muğla Gezi Rehberi", "Muğla'nın en güzel plajları ve koyları hakkında detaylı rehber", "Muğla, plajlar, koylar, Ölüdeniz, İçmeler", "postImages/mugla-plajlar.jpg", "Muğla'nın En Güzel Plajları ve Koyları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 1250 },
                    { new Guid("e5a67c9f-3c2a-4b6e-9c8f-09f1c3c903d3"), null, 3, "Muğla, antik Karya ve Likya medeniyetlerinin izlerini taşıyan önemli bir tarih merkezidir. Bölgede Knidos, Stratonikeia, Kaunos, Tlos ve Letoon gibi önemli antik kentler bulunmaktadır. Bodrum'daki Halikarnas Mozolesi (Mausoleum), antik dünyanın yedi harikasından biri olarak kabul edilmektedir. Ayrıca Bodrum Kalesi, Marmaris Kalesi, Fethiye Kaya Mezarları ve Kayaköy gibi tarihi yerler de bölgenin zengin kültürel mirasını yansıtmaktadır. Bu makalede, Muğla'daki en önemli tarihi yerleri ve antik kentleri tanıtacak, ziyaretçilerin bu bölgelerde neler görebileceğini ve nasıl ulaşabileceğini detaylı olarak anlatacağız.", "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6443), new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6442), true, false, new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6444), "Muğla'nın tarihi zenginlikleri", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(6442), "Muğla Tarih Rehberi", "Muğla'daki antik kentler ve tarihi yerler hakkında detaylı rehber", "Muğla, antik kentler, Knidos, tarih", "postImages/mugla-antik-kentler.jpg", "Muğla'daki Antik Kentler ve Tarihi Yerler", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 950 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IpAddress", "IsActive", "IsDeleted", "LikeCount", "ModifiedByName", "ModifiedDate", "Note", "ParentCommentId", "Text" },
                values: new object[,]
                {
                    { new Guid("253e472e-21ac-4e18-91d7-49b599a4f9b9"), new Guid("c20558d8-b0fd-4142-a527-0da9910deefc"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9860), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9861), "C# Makale Yorumu", null, "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { new Guid("9a5cef5c-8276-4c8e-933e-95c5f29cdab1"), new Guid("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9901), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9902), "Ruby Makale Yorumu", null, "Lorem Ipsum，ong established fact that a reader will be distracted by the readable conten" },
                    { new Guid("a4edb8d2-6c4f-4186-b4f6-0bf664011d5e"), new Guid("42eb2c71-47f5-4bec-b31e-e71e11c39c28"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9893), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9893), "Kotlin Makale Yorumu", null, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { new Guid("e257f068-5e76-4587-8e99-a9b58bea2b5f"), new Guid("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9888), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9889), "Php Makale Yorumu", null, "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { new Guid("fd7e2485-5ca0-4a3c-9b0b-5f62ddb7c3f9"), new Guid("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9897), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9898), "Swift Makale Yorumu", null, "ong established fact that a reader will be distracted by the readable conten" },
                    { new Guid("1a099dbb-af9f-4a8a-b67a-96c8d957a7b2"), new Guid("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9865), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9865), "C++ Makale Yorumu", null, "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { new Guid("3f8b6590-12f5-4d2a-b97d-57e75f0a2a75"), new Guid("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9879), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9880), "Java Makale Yorumu", null, "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { new Guid("7c4c7d74-5187-4a7d-9a96-bd7a321e3340"), new Guid("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9883), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9884), "Python Makale Yorumu", null, "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { new Guid("d86f1fb4-8c1e-45c8-8677-46ee89af8db3"), new Guid("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9874), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9874), "Typescript Makale Yorumu", null, "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { new Guid("f0756c5c-6d1d-4683-9d3d-7ddbbc561f42"), new Guid("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"), "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9869), null, true, false, 0, "InitialCreate", new DateTime(2025, 5, 18, 19, 21, 46, 691, DateTimeKind.Local).AddTicks(9870), "JavaScript Makale Yorumu", null, "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MenuId",
                table: "Articles",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

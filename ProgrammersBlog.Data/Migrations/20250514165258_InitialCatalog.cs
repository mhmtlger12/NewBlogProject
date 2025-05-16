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
                    Message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Callsite = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Exception = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
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
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                },
                comment: "Yorumlar");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5053), "Ruby Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5053), "Ruby", "Ruby Blog Kategorisi" },
                    { new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5027), "JavaScript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5027), "JavaScript", "JavaScript Blog Kategorisi" },
                    { new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5030), "Typescript Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5031), "Typescript", "Typescript Blog Kategorisi" },
                    { new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5042), "Php Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5042), "Php", "Php Blog Kategorisi" },
                    { new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5049), "Swift Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5050), "Swift", "Swift Blog Kategorisi" },
                    { new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5018), "C# Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5019), "C#", "C# Blog Kategorisi" },
                    { new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5045), "Kotlin Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5046), "Kotlin", "Kotlin Blog Kategorisi" },
                    { new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5038), "Python Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5039), "Python", "Python Blog Kategorisi" },
                    { new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5023), "C++ Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5023), "C++", "C++ Blog Kategorisi" },
                    { new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5034), "Java Programlama Dili ile İlgili En Güncel Bilgiler", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5035), "Java", "Java Blog Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Icon", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note", "Order", "ParentId", "Url" },
                values: new object[,]
                {
                    { new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6540), "Hakkımızda Menüsü", "bi bi-info-circle", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6540), "Hakkımızda", "Hakkımızda Menüsü", 4, null, "/Home/About" },
                    { new Guid("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6545), "İletişim Menüsü", "bi bi-telephone", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6545), "İletişim", "İletişim Menüsü", 5, null, "/Home/Contact" },
                    { new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6495), "Ana Sayfa Menüsü", "bi bi-house", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6496), "Ana Sayfa", "Ana Sayfa Menüsü", 1, null, "/" },
                    { new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6521), "Muğla ve İlçeleri Menüsü", "bi bi-geo-alt", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6522), "Muğla ve İlçeleri", "Muğla ve İlçeleri Menüsü", 3, null, "#" },
                    { new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6501), "Gezi Rehberi Menüsü", "bi bi-map", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6502), "Gezi Rehberi", "Gezi Rehberi Menüsü", 2, null, "#" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0730f01f-58f5-4f99-a28c-d51c121694f2"), "5ea26ac1-44a5-46c9-90b2-bcc45ef4ad18", "Article.Update", "ARTICLE.UPDATE" },
                    { new Guid("30e26bb1-c7b7-4c10-98da-b775b861bc7a"), "b8a12495-c591-4bbb-8f99-de5eb1899f37", "Role.Update", "ROLE.UPDATE" },
                    { new Guid("46e3b3b3-bb4f-4755-8257-68fe1b6bca34"), "2f99b4e2-9f7c-4bb8-9e58-11975edf5e21", "Category.Delete", "CATEGORY.DELETE" },
                    { new Guid("65cb04f5-bdd6-4b3b-9611-9a243c2f982b"), "78ba3c39-e357-4a69-85b4-24d9e8753f08", "Category.Read", "CATEGORY.READ" },
                    { new Guid("6d5878d7-8a8f-46a6-8808-b9717421b021"), "e9b0e1c7-5da6-43b9-ad89-7ca0a67fe6c5", "Comment.Create", "COMMENT.CREATE" },
                    { new Guid("8a9418f1-c27f-4303-a256-48736d06bbed"), "7775fc34-9f60-40a7-b3f8-bf227f88d611", "Comment.Delete", "COMMENT.DELETE" },
                    { new Guid("8b07b9e4-1b7b-4525-a22a-b3d98d4e647d"), "af0e3f82-ed3e-4eae-bff0-f334d4ec87b8", "Role.Delete", "ROLE.DELETE" },
                    { new Guid("9a20d3de-e7c0-44b7-b446-d287453064f1"), "3fcf34dd-cafb-409d-a11b-bff57e58e0ef", "Role.Create", "ROLE.CREATE" },
                    { new Guid("a8b2c7e3-d5f6-4e9a-8c1d-7b3e9f5a2c4d"), "d9e7f1bd-0bd7-4786-a703-54d28d045441", "Menu.Read", "MENU.READ" },
                    { new Guid("ab56d30e-7d6c-4b47-80e5-7cbce544e925"), "8ad425dd-1fbf-4840-afe6-3266c492efcf", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b28789c7-1a4d-4a58-8043-50499e39a0f1"), "55105de6-525e-4b56-8ada-241bea0c16ff", "User.Update", "USER.UPDATE" },
                    { new Guid("b4cf3987-e4ac-4da7-b931-bbd59c4d20ed"), "7dd33954-0149-4ba7-bdcd-410c974e39d0", "Comment.Update", "COMMENT.UPDATE" },
                    { new Guid("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d"), "5892a882-28a8-46eb-bcb4-f546576e21d2", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { new Guid("b7f3894d-d399-479a-a9cf-5d195f02b984"), "6496a14d-0150-474a-8a94-7a54a129b0a8", "Article.Delete", "ARTICLE.DELETE" },
                    { new Guid("c9fc3b36-73f4-4e5b-bb16-cf84d1740189"), "9d160d6b-5c27-4934-91d4-a9e0a9e735e0", "User.Create", "USER.CREATE" },
                    { new Guid("cc5c2c3b-e013-4317-8a6d-387f6e6b4e70"), "bae8d77e-cf92-486c-b8f7-aff0a575d9c4", "Category.Update", "CATEGORY.UPDATE" },
                    { new Guid("cf8d7b2a-69de-467f-b496-f56ed8c8d019"), "863401c1-1b84-4f60-b00f-c841fbd215c0", "User.Read", "USER.READ" },
                    { new Guid("d1c1d472-1a4d-4d43-9f85-05b8975f9e23"), "f99d8779-7bdd-4b53-98a8-90486e630adb", "Article.Create", "ARTICLE.CREATE" },
                    { new Guid("d9e4a7b2-c5f8-4e1d-9b3a-8c7e6f5a4d2b"), "33649e62-ab44-49c3-aa7c-050febfb687a", "Menu.Update", "MENU.UPDATE" },
                    { new Guid("e1b835c9-d8a7-4ca4-9cc4-c6e5e3deaa45"), "9fe8be5d-7650-4a69-9798-ed5c0ed8cceb", "Comment.Read", "COMMENT.READ" },
                    { new Guid("e1bc238f-4d9c-4261-b2d5-bbe8d6e6b6ca"), "5c6039b8-a1a0-4e2c-b210-914370b7339c", "Role.Read", "ROLE.READ" },
                    { new Guid("e7c9b1a4-d8f2-4e5c-9b7a-8d6e5f4c3b2a"), "b13a21d1-b73e-448b-a719-066cc0b1ca90", "Menu.Delete", "MENU.DELETE" },
                    { new Guid("ed14e6e9-05b4-4065-b300-213589e16ff3"), "ac53501c-1ae3-4120-ae6c-3e367c77f99f", "User.Delete", "USER.DELETE" },
                    { new Guid("f2c6c3a5-d7e6-4bd4-8a2f-3b0e8175a1d7"), "b152031a-4ca5-403f-9421-9f28db31ad2b", "Menu.Create", "MENU.CREATE" },
                    { new Guid("f7b90591-d678-462d-9f3d-5497dbd43c5d"), "5e850380-ff30-483d-b4b8-0c2db50d4b70", "Category.Create", "CATEGORY.CREATE" },
                    { new Guid("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2"), "52a0609d-321b-47f5-aff0-aa0ba5cc027d", "Article.Read", "ARTICLE.READ" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), "Admin User of ProgrammersBlog", 0, "1f35368b-63b0-431b-b20d-5d89ff03ed07", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAIAAYagAAAAEPx+ZeGxiszfKLGog16j0Nq/5EFeTr8j/u8NOazsoJuye7qAM6qgAsa1paeOrhN6dw==", "+905555555555", true, "/userImages/defaultUser.png", "cad88bad-df14-44dc-9fe8-e6fd23da1370", "https://twitter.com/adminuser", false, "adminuser", "https://programmersblog.com/", "https://youtube.com/adminuser" },
                    { new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"), "Editor User of ProgrammersBlog", 0, "081996ee-79c5-4359-a40b-f51e1a1ee576", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAIAAYagAAAAEE+0VGPoiGRDJz6KHXqCMmGt3iKflUbzABhCIgfh5NAkKOEk8OWN+YePTzDTAZv9LQ==", "+905555555555", true, "/userImages/defaultUser.png", "3298139f-6630-4d36-b95f-a33aca897eb6", "https://twitter.com/editoruser", false, "editoruser", "https://programmersblog.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "MenuId", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"), null, 0, "Muğla'nın en eski yerleşim yerlerinden biri olan Milas, zengin tarihi dokusu ve kültürel mirası ile dikkat çekiyor. Antik Karya uygarlığının başkenti olan Milas, Helenistik, Roma, Bizans, Selçuklu ve Osmanlı dönemlerine ait birçok tarihi esere ev sahipliği yapıyor. Şehir merkezinde bulunan Hekatomnos Anıt Mezarı ve Müzesi, dünyada türünün en iyi korunmuş örneklerinden biri olarak UNESCO Dünya Mirası Geçici Listesi'nde yer alıyor. Ünlü Beçin Kalesi ve etrafındaki Osmanlı dönemi yerleşimi, İasos Antik Kenti, Labranda Antik Kenti ve Zeus Tapınağı bölgenin önemli tarihi değerleri arasında. Ayrıca Milas, geleneksel Türk mimarisinin en güzel örneklerinden olan konakları ve camileriyle de ünlü. Milas halıları, el dokuması kilimler ve zeytin ürünleri yörenin en önemli kültürel simgeleri arasında. Bafa Gölü Tabiat Parkı da doğa tutkunları için muhteşem manzaralar sunuyor. Göl kenarında bulunan Herakleia Antik Kenti kalıntıları ise doğa ve tarihin buluştuğu eşsiz bir atmosfer yaratıyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4085), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4084), true, false, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4085), "Milas tarihi", "Muğla Rehberi", "Milas'ın Tarihi ve Kültürel Zenginlikleri", "Milas, Hekatomnos, Beçin Kalesi, İasos, Labranda, Bafa Gölü, Muğla", "postImages/defaultThumbnail.jpg", "Milas'ın Tarihi ve Kültürel Zenginlikleri", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 9999 },
                    { new Guid("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"), null, 0, "Muğla'nın en popüler ilçelerinden biri olan Bodrum, tarih boyunca birçok medeniyete ev sahipliği yapmış önemli bir kültür merkezidir. Antik dünyanın yedi harikasından biri olan Mausoleum'un kalıntıları, UNESCO Dünya Mirası Listesi'nde yer alan Bodrum Kalesi ve içindeki Sualtı Arkeoloji Müzesi mutlaka ziyaret edilmesi gereken yerlerdir. Bodrum Antik Tiyatrosu, Myndos Kapısı ve Pedasa Antik Kenti de tarihi yolculuğunuzu tamamlayan önemli duraklardır. Bunun yanı sıra, geleneksel Bodrum evleri ile ünlü Gümbet ve Ortakent gibi mahalleler, bembeyaz badanalı, mavi pencereli evleriyle Ege mimarisinin en güzel örneklerini sergiliyor. Bodrum, aynı zamanda canlı gece hayatı, lüks marinası ve dünyaca ünlü plajlarıyla da turistlerin gözdesi. Türkbükü, Gümüşlük ve Yalıkavak gibi beldeleriyle her zevke hitap eden Bodrum, yemek kültürü ve el sanatlarıyla da ziyaretçilerini büyülüyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4057), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4056), true, false, new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4058), "Bodrum'un tarihi zenginlikleri", "Muğla Rehberi", "Bodrum'da Gezilecek Tarihi Mekanlar", "Bodrum, Bodrum Kalesi, Mausoleum, Antik Tiyatro, Muğla, tarih", "postImages/defaultThumbnail.jpg", "Bodrum'da Gezilecek Tarihi Mekanlar", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 295 },
                    { new Guid("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"), null, 0, "Muğla'nın iç kesimlerinde yer alan Kavaklıdere ve Yatağan ilçeleri, el değmemiş doğası ve zengin tarihi mirası ile keşfedilmeyi bekleyen gizli hazinelerdir. Kavaklıdere, ismini verimli topraklarında yetişen kavak ağaçlarından almış olup, bağcılık ve şarapçılık kültürü ile ünlüdür. İlçenin dağlık alanlarında bulunan Menteşe Yaylası, serin iklimi ve muhteşem manzarasıyla yazın bunaltan sıcaklardan kaçmak isteyenler için ideal bir sığınak. Yatağan ise antik dönemden kalma Stratonikeia Antik Kenti ile ünlüdür. 'Mermer Şehir' olarak da bilinen bu antik kent, Roma, Helenistik ve Bizans dönemlerine ait kalıntılarıyla tarih meraklıları için vazgeçilmez bir durak. Yatağan aynı zamanda geleneksel Türk kılıcı olan 'yatağan'ın üretim merkezi olarak da tarihe geçmiştir. Bölgede yer alan Bozüyük ve Turgut gibi eski Türk yerleşimleri, yüzlerce yıllık çınar ağaçları, tarihi camileri ve geleneksel Türk köy yaşamını yansıtan dokusuyla otantik bir atmosfer sunuyor. Yerel halk tarafından hala yaşatılan geleneksel el sanatları, özellikle halıcılık ve dokumacılık, bölgenin kültürel zenginliklerini tamamlıyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4114), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4113), true, false, new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4115), "Kavaklıdere ve Yatağan", "Muğla Rehberi", "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri", "Kavaklıdere, Yatağan, Stratonikeia, bağcılık, yaylalar, tarih, Muğla", "postImages/defaultThumbnail.jpg", "Kavaklıdere ve Yatağan'ın Doğal ve Tarihi Zenginlikleri", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 26777 },
                    { new Guid("c20558d8-b0fd-4142-a527-0da9910deefc"), null, 0, "Muğla'nın incisi Fethiye, Türkiye'nin en güzel koylarına ve plajlarına ev sahipliği yapıyor. Ölüdeniz'in turkuaz suları ve beyaz kumsalı, dünyaca ünlü Kelebekler Vadisi, saklı cennet Kabak Koyu ve tekne turlarıyla keşfedebileceğiniz 12 Adalar, her yıl binlerce turisti ağırlıyor. Fethiye'nin berrak sularında yüzmek, Belcekız Plajı'nda güneşlenmek ve Gemiler Adası'nı keşfetmek unutulmaz bir tatil deneyimi yaşatıyor. Ayrıca Fethiye merkezdeki tarihi Kayaköy (Levissi) harabeleri, Antik Likya uygarlığından kalma kaya mezarları ve Tlos antik kenti de bölgenin zengin tarihini gözler önüne seriyor. Fethiye aynı zamanda yamaç paraşütü tutkunları için dünyanın en iyi noktalarından biri olan Babadağ'a ev sahipliği yapıyor. 1975 metre yükseklikteki Babadağ'dan Ölüdeniz manzarası eşliğinde yapılan uçuşlar, adrenalin tutkunlarına unutulmaz anlar yaşatıyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4049), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4048), true, false, new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4050), "Fethiye'nin doğal güzellikleri", "Muğla Rehberi", "Fethiye'nin Eşsiz Koyları ve Plajları", "Fethiye, Ölüdeniz, Kelebekler Vadisi, Babadağ, Muğla, plajlar, koylar", "postImages/defaultThumbnail.jpg", "Fethiye'nin Eşsiz Koyları ve Plajları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 100 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Icon", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note", "Order", "ParentId", "Url" },
                values: new object[,]
                {
                    { new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6507), "Plajlar Alt Menüsü", "bi bi-water", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6508), "Plajlar", "Plajlar Alt Menüsü", 1, new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "/Plajlar" },
                    { new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6512), "Tarihi Yerler Alt Menüsü", "bi bi-building-fill", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6513), "Tarihi Yerler", "Tarihi Yerler Alt Menüsü", 2, new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "/TarihiYerler" },
                    { new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6526), "Bodrum Alt Menüsü", "bi bi-geo-fill", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6527), "Bodrum", "Bodrum Alt Menüsü", 1, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "/Home/Index?menuId=7e29265f-d672-42a7-9d84-47b564ebad69" },
                    { new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6536), "Fethiye Alt Menüsü", "bi bi-compass", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6536), "Fethiye", "Fethiye Alt Menüsü", 3, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "/Home/Index?menuId=97b6d8c7-6a07-4ef1-8764-d71ab72f812a" },
                    { new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6531), "Marmaris Alt Menüsü", "bi bi-pin-map", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6532), "Marmaris", "Marmaris Alt Menüsü", 2, new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"), "/Home/Index?menuId=b33b442b-58b3-400b-a2f5-9231e58a1ff7" },
                    { new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6517), "Doğa Yürüyüşleri Alt Menüsü", "bi bi-tree-fill", true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6518), "Doğa Yürüyüşleri", "Doğa Yürüyüşleri Alt Menüsü", 3, new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"), "/DogaYuruyusleri" }
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
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "MenuId", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"), null, 0, "Muğla'nın cennet köşelerinden biri olan Datça Yarımadası, Ege ve Akdeniz'in buluştuğu noktada eşsiz bir doğal güzelliğe sahip. 'Dünyada iki kere insan yaşar; biri Datça'da, biri rüyada' diye tarif eden Can Yücel'i haklı çıkaracak güzellikteki bu yarımada, el değmemiş koyları ve plajlarıyla ünlü. Doğu tarafında Hisarönü Körfezi, batı tarafında Gökova Körfezi ile çevrili olan yarımadada Palamutbükü, Hayıtbükü ve Kızılbük gibi muhteşem koylar bulunuyor. Özellikle Knidos Antik Kenti'nin yanındaki Delikli Koy ve Karaincir Koyu, berrak suları ve sessiz ortamıyla dikkat çekiyor. Datça merkezdeki Kumluk Plajı ve Taşlık Plajı da hem yerel halkın hem de turistlerin vazgeçilmez durakları. Ayrıca Datça, Apollon Tapınağı, Eski Datça'nın taş evleri ve zeytinyağı atölyeleriyle de kültür turizmi açısından zengin bir bölge. Bademli ve verimliliğiyle dünyaca ünlü Datça bademleri, zeytinyağı ve bal gibi yerel lezzetler de bu güzel yarımadanın tadını tamamlıyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4071), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4070), true, false, new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4072), "Datça'nın doğal güzellikleri", "Muğla Rehberi", "Datça Yarımadası'nın Gizli Koyları", "Datça, Knidos, Palamutbükü, koylar, plajlar, Muğla, Ege", "postImages/defaultThumbnail.jpg", "Datça Yarımadası'nın Gizli Koyları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 666 },
                    { new Guid("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"), null, 0, "Muğla'nın göz bebeği Marmaris, eşsiz doğal güzellikleriyle her yıl milyonlarca turisti ağırlıyor. İçmeler, Turunç ve Selimiye gibi muhteşem koylarıyla ünlü olan Marmaris, yat turizmi için de ideal bir destinasyon. Marmaris Marina ve Netsel Marina'da demirlemiş lüks yatlar, bölgenin prestijiyle bütünleşiyor. Marmaris'in turkuaz renkli koylarında tekne turu yapmak, Kleopatra Plajı'nda denizin tadını çıkarmak ve Cennet Adası'nı keşfetmek, burada yapılabilecek en keyifli aktiviteler arasında. Bunun yanı sıra doğa tutkunları için Marmaris'in çevresindeki ormanlar, trekking, kano ve safari turları için mükemmel fırsatlar sunuyor. Turgut Şelalesi'nin serinletici suları, Günnücek Mesire Yeri'nin yeşil örtüsü ve Nimara Mağarası'nın gizemli atmosferi, Marmaris'in keşfedilmeyi bekleyen doğal hazineleri. Ayrıca, Marmaris Kale ve Müzesi, tarihi İbrahim Ağa Camii ve antik Amos kenti, bölgenin kültürel zenginliğini yansıtan önemli eserler arasında yer alıyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4065), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4064), true, false, new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4065), "Marmaris'in turistik değerleri", "Muğla Rehberi", "Marmaris'te Deniz ve Doğa Turizmi", "Marmaris, İçmeler, Turunç, marina, tekne turu, Kleopatra Plajı, Muğla", "postImages/defaultThumbnail.jpg", "Marmaris'te Deniz ve Doğa Turizmi", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 12 },
                    { new Guid("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"), null, 0, "Muğla il merkezi, Osmanlı ve Cumhuriyet dönemlerinden kalma tarihi yapıları, müzeleri ve geleneksel Türk mimarisini yansıtan evleriyle tam bir açık hava müzesi niteliğindedir. 'Beyaz Kent' olarak da anılan Muğla'nın tarihi dokusunu en iyi yansıtan Saburhane Mahallesi, restore edilmiş geleneksel Muğla evleriyle ünlüdür. Bacaları ve cumbalı evleriyle dikkat çeken bu mahalle, fotoğraf tutkunları için de eşsiz kareler sunuyor. Kent merkezindeki Kurşunlu Cami, Ulu Cami ve Konakaltı Han gibi tarihi yapılar, Osmanlı mimarisinin en güzel örnekleri arasında. Muğla Arkeoloji Müzesi ve Muğla Kent Müzesi, bölgenin zengin tarihini ve kültürel mirasını sergilemektedir. Ayrıca Muğla'nın meşhur perşembe pazarı, yöresel ürünlerin bulunabileceği rengarenk bir alışveriş deneyimi sunuyor. Muğla mutfağı da zeytinyağlı yemekleri, otları, börekleri ve tatlılarıyla Türk mutfağının en zengin örneklerinden. Özellikle çökertme kebabı, sündürme, keşkek ve tarhana çorbası mutlaka tadılması gereken yerel lezzetler arasında yer alıyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4091), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4090), true, false, new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4092), "Muğla merkez kültürü", "Muğla Rehberi", "Muğla Merkez'de Kültür Turizmi", "Muğla, Saburhane, Osmanlı mimarisi, müzeler, kültür, pazar", "postImages/defaultThumbnail.jpg", "Muğla Merkez'de Kültür Turizmi", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 4818 },
                    { new Guid("42eb2c71-47f5-4bec-b31e-e71e11c39c28"), null, 0, "Muğla'nın en büyük ilçelerinden biri olan Seydikemer, el değmemiş doğası, kanyonları ve dağlarıyla doğa tutkunlarının gözdesi. İlçenin en önemli doğal güzelliklerinden biri olan Saklıkent Kanyonu, Türkiye'nin en uzun ikinci kanyonu olup, 18 km uzunluğunda ve yer yer 300 metre derinliğe sahip. Yazın serinlemek isteyenler için ideal bir rotadır. Tlos Antik Kenti'nin de bulunduğu ilçede, Yaka Kanyonu ve Gizlikent Şelalesi de görülmeye değer doğa harikalarından. Pastoral yaşamın hala devam ettiği ilçede, yaylacılık kültürü de oldukça yaygın. Akdağ ve Seki yaylaları, özellikle yaz aylarında serin iklimi ve muhteşem manzarasıyla ziyaretçileri büyülüyor. Seydikemer'in bereketli topraklarında yetiştirilen tarım ürünleri, özellikle narenciye ve çam balı, bölgenin ekonomisinde önemli yer tutuyor. Ayrıca ilçede bulunan Letoon Antik Kenti, UNESCO Dünya Mirası Listesi'nde yer alan önemli bir arkeolojik alandır. Seydikemer'in kırsal köylerinde yaşayan yörük kültürü ve geleneksel el sanatları da görülmeye değer kültürel zenginlikler sunuyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4098), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4097), true, false, new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4099), "Seydikemer doğa", "Muğla Rehberi", "Seydikemer'in Bakir Doğası ve Kanyonları", "Seydikemer, Saklıkent Kanyonu, Tlos, yaylalar, doğa, Muğla", "postImages/defaultThumbnail.jpg", "Seydikemer'in Bakir Doğası ve Kanyonları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 750 },
                    { new Guid("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"), null, 0, "Muğla'nın en özel doğa harikalarından biri olan Köyceğiz Gölü ve Dalyan Kanalları, eşsiz ekosistemiyle büyüleyici bir güzelliğe sahip. Tatlı su gölü olan Köyceğiz'den başlayıp, kanallar boyunca Akdeniz'e uzanan bu su yolu, nesli tükenmekte olan Caretta Caretta deniz kaplumbağalarının en önemli üreme alanlarından biri olan İztuzu Plajı'na kadar devam ediyor. Dalyan Kanalları boyunca tekne turlarıyla yapılan gezilerde, sazlıklar arasında ilerlerken binlerce yıllık Kaunos Antik Kenti'nin kaya mezarlarını görebilirsiniz. Ayrıca bölgede bulunan şifalı çamur banyoları ve termal kaynaklar da sağlık turizmi açısından büyük önem taşıyor. Sultan Sazlığı olarak bilinen bölge, yüzlerce kuş türüne ev sahipliği yapan bir kuş cennetidir. Köyceğiz'in zengin bitki örtüsü, endemik türleri ve yaban hayatı, doğa tutkunları için adeta bir cennet. Bölge aynı zamanda, Köyceğiz'in geleneksel pazarı, yerel el sanatları ve Sultaniye Kaplıcaları ile de ziyaretçilerine unutulmaz deneyimler sunuyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4078), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4077), true, false, new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4079), "Köyceğiz ve Dalyan'ın doğal güzellikleri", "Muğla Rehberi", "Köyceğiz Gölü ve Dalyan Kanalları", "Köyceğiz, Dalyan, İztuzu, Caretta Caretta, Kaunos, Muğla", "postImages/defaultThumbnail.jpg", "Köyceğiz Gölü ve Dalyan Kanalları", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 3225 },
                    { new Guid("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"), null, 0, "Muğla'nın saklı cenneti Ula ve dünyaca ünlü sakin şehir (cittaslow) Akyaka, modern dünyanın hızından uzaklaşmak isteyenler için ideal destinasyonlar. Akyaka, 2011 yılında Türkiye'nin üçüncü sakin şehri olarak ilan edilmiş ve bu unvanı geleneksel mimarisi, doğal güzellikleri ve sürdürülebilir yaşam anlayışı ile hak etmiştir. Bölgenin en karakteristik özelliği olan 'Muğla-Ula evleri' tarzındaki mimari, taş ve ahşabın uyumlu birleşimiyle dikkat çekiyor. Akyaka'nın uzun kumsalı ve berrak denizi, plaj keyfi için idealken, Kadın Azmağı olarak bilinen tatlı su kaynağı etrafındaki restoranlar da lezzetli deniz ürünleri sunuyor. Akyaka aynı zamanda, kiteboard sporcuları için ideal rüzgar koşulları sayesinde bir cennet. Gökova Körfezi'nin eşsiz manzarasına sahip olan bölge, tekne turları ve doğa yürüyüşleri için de mükemmel imkanlar sunuyor. Ula'nın yeşil yaylaları, Gökova'nın muhteşem koyu ve Akçapınar'ın sakin atmosferi, bölgenin diğer güzellikleri arasında. Ayrıca yöresel mutfağın özel tatları, özellikle çam balı, zeytinyağlı yemekler ve taze deniz ürünleri, gastronomi tutkunları için unutulmaz lezzetler vadediyor.", "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4105), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4104), true, false, new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4105), "Ula ve Akyaka", "Muğla Rehberi", "Ula ve Akyaka'da Sakin Şehir Deneyimi", "Akyaka, Ula, cittaslow, sakin şehir, Gökova, Kadın Azmağı, Muğla", "postImages/defaultThumbnail.jpg", "Ula ve Akyaka'da Sakin Şehir Deneyimi", new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"), 14900 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IpAddress", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[,]
                {
                    { new Guid("1a099dbb-af9f-4a8a-b67a-96c8d957a7b2"), new Guid("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7868), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7869), "C++ Makale Yorumu", "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { new Guid("253e472e-21ac-4e18-91d7-49b599a4f9b9"), new Guid("c20558d8-b0fd-4142-a527-0da9910deefc"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7861), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7862), "C# Makale Yorumu", "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { new Guid("7c4c7d74-5187-4a7d-9a96-bd7a321e3340"), new Guid("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7889), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7890), "Python Makale Yorumu", "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { new Guid("9a5cef5c-8276-4c8e-933e-95c5f29cdab1"), new Guid("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7908), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7909), "Ruby Makale Yorumu", "Lorem Ipsum，ong established fact that a reader will be distracted by the readable conten" },
                    { new Guid("3f8b6590-12f5-4d2a-b97d-57e75f0a2a75"), new Guid("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7885), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7885), "Java Makale Yorumu", "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { new Guid("a4edb8d2-6c4f-4186-b4f6-0bf664011d5e"), new Guid("42eb2c71-47f5-4bec-b31e-e71e11c39c28"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7899), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7900), "Kotlin Makale Yorumu", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { new Guid("d86f1fb4-8c1e-45c8-8677-46ee89af8db3"), new Guid("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7879), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7880), "Typescript Makale Yorumu", "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { new Guid("e257f068-5e76-4587-8e99-a9b58bea2b5f"), new Guid("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7894), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7895), "Php Makale Yorumu", "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { new Guid("f0756c5c-6d1d-4683-9d3d-7ddbbc561f42"), new Guid("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7873), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7874), "JavaScript Makale Yorumu", "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { new Guid("fd7e2485-5ca0-4a3c-9b0b-5f62ddb7c3f9"), new Guid("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"), "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7904), null, true, false, "InitialCreate", new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7905), "Swift Makale Yorumu", "ong established fact that a reader will be distracted by the readable conten" }
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

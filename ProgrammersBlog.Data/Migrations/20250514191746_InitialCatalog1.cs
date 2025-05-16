using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalog1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCommentId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5418), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5416), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5419) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5441), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5439), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5407), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5406), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5409) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5450), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5449), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5451) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("42eb2c71-47f5-4bec-b31e-e71e11c39c28"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5460), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5458), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5461) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5431), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5429), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5432) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5397), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5395), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5479), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5477), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c20558d8-b0fd-4142-a527-0da9910deefc"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5384), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5382), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5385) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5469), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5468), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6946), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6947) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6908), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6913), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6930), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6931) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6941), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6942) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6891), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6936), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6936) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6925), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6926) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6898), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6919), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1a099dbb-af9f-4a8a-b67a-96c8d957a7b2"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1076), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1077), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4e18-91d7-49b599a4f9b9"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1068), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1070), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3f8b6590-12f5-4d2a-b97d-57e75f0a2a75"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1100), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1101), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7c4c7d74-5187-4a7d-9a96-bd7a321e3340"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1108), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1109), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9a5cef5c-8276-4c8e-933e-95c5f29cdab1"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1139), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1140), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a4edb8d2-6c4f-4186-b4f6-0bf664011d5e"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1122), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1123), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d86f1fb4-8c1e-45c8-8677-46ee89af8db3"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1092), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1093), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e257f068-5e76-4587-8e99-a9b58bea2b5f"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1115), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1116), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f0756c5c-6d1d-4683-9d3d-7ddbbc561f42"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1084), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1085), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("fd7e2485-5ca0-4a3c-9b0b-5f62ddb7c3f9"),
                columns: new[] { "CreatedDate", "LikeCount", "ModifiedDate", "ParentCommentId" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1129), 0, new DateTime(2025, 5, 14, 22, 17, 45, 129, DateTimeKind.Local).AddTicks(1130), null });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9276), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9277) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9228), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9229) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9236), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9256), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9257) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9270), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9283), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9212), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9213) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9263), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9249), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9220), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9221) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9243), new DateTime(2025, 5, 14, 22, 17, 45, 128, DateTimeKind.Local).AddTicks(9244) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0730f01f-58f5-4f99-a28c-d51c121694f2"),
                column: "ConcurrencyStamp",
                value: "38aa5e34-4def-432b-bcad-7fb6da75b550");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("30e26bb1-c7b7-4c10-98da-b775b861bc7a"),
                column: "ConcurrencyStamp",
                value: "4e557190-827e-4b3a-844d-2b40438d294c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46e3b3b3-bb4f-4755-8257-68fe1b6bca34"),
                column: "ConcurrencyStamp",
                value: "0bf06461-203f-491c-b8be-9a594e205b50");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("65cb04f5-bdd6-4b3b-9611-9a243c2f982b"),
                column: "ConcurrencyStamp",
                value: "224ce999-269d-4390-ba0a-c8c5c60cedf1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d5878d7-8a8f-46a6-8808-b9717421b021"),
                column: "ConcurrencyStamp",
                value: "bc690807-bbf5-4314-8fc0-96b7cd1d822e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8a9418f1-c27f-4303-a256-48736d06bbed"),
                column: "ConcurrencyStamp",
                value: "1474cba5-52ec-4d22-aae2-9b24f7337e61");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8b07b9e4-1b7b-4525-a22a-b3d98d4e647d"),
                column: "ConcurrencyStamp",
                value: "0a11c371-d5d2-4c4f-a6d2-afbdf47fad07");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9a20d3de-e7c0-44b7-b446-d287453064f1"),
                column: "ConcurrencyStamp",
                value: "a5a78c95-2fb9-4ecd-9b7e-b8b32ef34553");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a8b2c7e3-d5f6-4e9a-8c1d-7b3e9f5a2c4d"),
                column: "ConcurrencyStamp",
                value: "a321a216-ff70-497b-8de9-615fbb4ad5df");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab56d30e-7d6c-4b47-80e5-7cbce544e925"),
                column: "ConcurrencyStamp",
                value: "a8782ec5-fcfc-4e86-a7e9-90a70e479b02");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b28789c7-1a4d-4a58-8043-50499e39a0f1"),
                column: "ConcurrencyStamp",
                value: "acefceb1-8696-47dd-8410-d51538e316c8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4cf3987-e4ac-4da7-b931-bbd59c4d20ed"),
                column: "ConcurrencyStamp",
                value: "bd6a4958-6c9a-4f2d-a1d5-2f95e3486108");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d"),
                column: "ConcurrencyStamp",
                value: "1486df2e-5c35-477c-8017-a27a35c764ad");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b7f3894d-d399-479a-a9cf-5d195f02b984"),
                column: "ConcurrencyStamp",
                value: "a09a1ab8-f387-486f-a227-5728fd118236");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9fc3b36-73f4-4e5b-bb16-cf84d1740189"),
                column: "ConcurrencyStamp",
                value: "26d1913a-8d66-4102-b9bd-3b92d2b9b792");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cc5c2c3b-e013-4317-8a6d-387f6e6b4e70"),
                column: "ConcurrencyStamp",
                value: "875d89b7-1a4a-42b0-a06b-aacb3bf68bcd");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf8d7b2a-69de-467f-b496-f56ed8c8d019"),
                column: "ConcurrencyStamp",
                value: "dbc0ec3b-2ae0-4828-ab8d-919872dfc59b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d1c1d472-1a4d-4d43-9f85-05b8975f9e23"),
                column: "ConcurrencyStamp",
                value: "1eede7bd-a54c-46aa-ae40-45591161b4ab");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d9e4a7b2-c5f8-4e1d-9b3a-8c7e6f5a4d2b"),
                column: "ConcurrencyStamp",
                value: "41573fa9-3cb7-4933-8269-45a2a13608a3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e1b835c9-d8a7-4ca4-9cc4-c6e5e3deaa45"),
                column: "ConcurrencyStamp",
                value: "ea308f29-0d5e-41b8-a027-9c035b32bd9c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e1bc238f-4d9c-4261-b2d5-bbe8d6e6b6ca"),
                column: "ConcurrencyStamp",
                value: "12e547d4-1e55-4458-8b33-cdee9fc93cd0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e7c9b1a4-d8f2-4e5c-9b7a-8d6e5f4c3b2a"),
                column: "ConcurrencyStamp",
                value: "180e3a84-a4f3-4960-a9bf-d5d3b2c20597");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ed14e6e9-05b4-4065-b300-213589e16ff3"),
                column: "ConcurrencyStamp",
                value: "c1b863aa-a199-4aa3-9b45-4825dc7d5ca5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f2c6c3a5-d7e6-4bd4-8a2f-3b0e8175a1d7"),
                column: "ConcurrencyStamp",
                value: "d3f987e6-a586-4083-ac1f-344587f39c52");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7b90591-d678-462d-9f3d-5497dbd43c5d"),
                column: "ConcurrencyStamp",
                value: "bd3675c5-9b02-4715-8831-9ba0e360139c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2"),
                column: "ConcurrencyStamp",
                value: "ccec560b-ffdd-4fab-bcbf-f24bd422017e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e59dedd-98dd-4317-afd4-de12ce620d27", "AQAAAAIAAYagAAAAECo6hX1EgEtufNYrH/kdePJFJ+2yZwsWkxd4CoIyM1x0X81I/MDjn7MhY/ZMnvhAqg==", "da4c1468-b6a5-4ffc-9952-bacfb4135ec1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19665e6a-a7cf-4923-95e9-7fc0e807de33", "AQAAAAIAAYagAAAAEMWDHY5YLMCBEuSC9Bxqm7JVgjwk5YLhjRpB1Nmiu+Dr42FdOYe/ICDLtfXkSm2Lsw==", "6aa2f6d4-1d7a-4d86-97d0-6455e2832b25" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0b797ea6-5f12-42a5-b4f6-4f67d5e2a829"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4071), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4070), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1b9e8c64-075f-4a16-8a18-09532fe8d1bd"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4085), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4084), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4085) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2fe2d2d5-79c9-4fed-a236-74426d84d4b5"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4065), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4064), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3e17dec7-f5b9-4cab-8d53-77f89c144e2d"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4091), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4090), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("42eb2c71-47f5-4bec-b31e-e71e11c39c28"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4098), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4097), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("77c21f6c-57e4-48d3-85b8-1e5e357d6e53"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4078), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4077), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("87b5d57f-1e2b-4b58-b9e6-2718d5af5924"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4057), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4056), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4058) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ad45a8fc-3c20-4c37-8db1-e45c1fb01a57"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4114), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4113), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c20558d8-b0fd-4142-a527-0da9910deefc"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4049), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4048), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f8dfba8a-90e6-4e1b-bd0c-2e22a8c77423"),
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4105), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4104), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(4105) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5053), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5053) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5027), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5030), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5031) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5042), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5042) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5049), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5018), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5019) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5045), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5038), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5039) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5023), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5034), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(5035) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1a099dbb-af9f-4a8a-b67a-96c8d957a7b2"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7868), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7869) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("253e472e-21ac-4e18-91d7-49b599a4f9b9"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7861), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3f8b6590-12f5-4d2a-b97d-57e75f0a2a75"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7885), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7885) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7c4c7d74-5187-4a7d-9a96-bd7a321e3340"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7889), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7890) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9a5cef5c-8276-4c8e-933e-95c5f29cdab1"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7908), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a4edb8d2-6c4f-4186-b4f6-0bf664011d5e"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7899), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d86f1fb4-8c1e-45c8-8677-46ee89af8db3"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7879), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e257f068-5e76-4587-8e99-a9b58bea2b5f"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7894), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7895) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f0756c5c-6d1d-4683-9d3d-7ddbbc561f42"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7873), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7874) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("fd7e2485-5ca0-4a3c-9b0b-5f62ddb7c3f9"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7904), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("3b466d57-abb5-4624-b922-1b2fba6a62c3"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6540), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("3b4e5f42-2043-4c0a-9a2f-cbce38591ea2"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6507), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6508) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("7191e8c0-26c6-4703-950e-dc195cc5c3db"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6512), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6513) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("7e29265f-d672-42a7-9d84-47b564ebad69"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6526), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6527) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("97b6d8c7-6a07-4ef1-8764-d71ab72f812a"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6536), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6536) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("a1f0d5a1-5c2d-4c1f-b71d-f2bc9c31f9eb"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6545), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6545) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("b1fbe4a5-dc1d-47f7-8b95-8c2c6c0c38f7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6495), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("b33b442b-58b3-400b-a2f5-9231e58a1ff7"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6531), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6532) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("bb9c127f-e143-4ad4-93b5-56d3f9f244ec"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6521), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("c73c3b3b-5f56-48cc-9b8b-b3f78d4a1a5d"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6501), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: new Guid("dfa25617-9fdb-4f9b-bba9-726404d6d87b"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6517), new DateTime(2025, 5, 14, 19, 52, 57, 419, DateTimeKind.Local).AddTicks(6518) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0730f01f-58f5-4f99-a28c-d51c121694f2"),
                column: "ConcurrencyStamp",
                value: "5ea26ac1-44a5-46c9-90b2-bcc45ef4ad18");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("30e26bb1-c7b7-4c10-98da-b775b861bc7a"),
                column: "ConcurrencyStamp",
                value: "b8a12495-c591-4bbb-8f99-de5eb1899f37");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46e3b3b3-bb4f-4755-8257-68fe1b6bca34"),
                column: "ConcurrencyStamp",
                value: "2f99b4e2-9f7c-4bb8-9e58-11975edf5e21");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("65cb04f5-bdd6-4b3b-9611-9a243c2f982b"),
                column: "ConcurrencyStamp",
                value: "78ba3c39-e357-4a69-85b4-24d9e8753f08");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d5878d7-8a8f-46a6-8808-b9717421b021"),
                column: "ConcurrencyStamp",
                value: "e9b0e1c7-5da6-43b9-ad89-7ca0a67fe6c5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8a9418f1-c27f-4303-a256-48736d06bbed"),
                column: "ConcurrencyStamp",
                value: "7775fc34-9f60-40a7-b3f8-bf227f88d611");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8b07b9e4-1b7b-4525-a22a-b3d98d4e647d"),
                column: "ConcurrencyStamp",
                value: "af0e3f82-ed3e-4eae-bff0-f334d4ec87b8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9a20d3de-e7c0-44b7-b446-d287453064f1"),
                column: "ConcurrencyStamp",
                value: "3fcf34dd-cafb-409d-a11b-bff57e58e0ef");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a8b2c7e3-d5f6-4e9a-8c1d-7b3e9f5a2c4d"),
                column: "ConcurrencyStamp",
                value: "d9e7f1bd-0bd7-4786-a703-54d28d045441");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab56d30e-7d6c-4b47-80e5-7cbce544e925"),
                column: "ConcurrencyStamp",
                value: "8ad425dd-1fbf-4840-afe6-3266c492efcf");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b28789c7-1a4d-4a58-8043-50499e39a0f1"),
                column: "ConcurrencyStamp",
                value: "55105de6-525e-4b56-8ada-241bea0c16ff");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4cf3987-e4ac-4da7-b931-bbd59c4d20ed"),
                column: "ConcurrencyStamp",
                value: "7dd33954-0149-4ba7-bdcd-410c974e39d0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b5718dcb-45f0-429d-b8f3-5c0e6ff2278d"),
                column: "ConcurrencyStamp",
                value: "5892a882-28a8-46eb-bcb4-f546576e21d2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b7f3894d-d399-479a-a9cf-5d195f02b984"),
                column: "ConcurrencyStamp",
                value: "6496a14d-0150-474a-8a94-7a54a129b0a8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9fc3b36-73f4-4e5b-bb16-cf84d1740189"),
                column: "ConcurrencyStamp",
                value: "9d160d6b-5c27-4934-91d4-a9e0a9e735e0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cc5c2c3b-e013-4317-8a6d-387f6e6b4e70"),
                column: "ConcurrencyStamp",
                value: "bae8d77e-cf92-486c-b8f7-aff0a575d9c4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf8d7b2a-69de-467f-b496-f56ed8c8d019"),
                column: "ConcurrencyStamp",
                value: "863401c1-1b84-4f60-b00f-c841fbd215c0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d1c1d472-1a4d-4d43-9f85-05b8975f9e23"),
                column: "ConcurrencyStamp",
                value: "f99d8779-7bdd-4b53-98a8-90486e630adb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d9e4a7b2-c5f8-4e1d-9b3a-8c7e6f5a4d2b"),
                column: "ConcurrencyStamp",
                value: "33649e62-ab44-49c3-aa7c-050febfb687a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e1b835c9-d8a7-4ca4-9cc4-c6e5e3deaa45"),
                column: "ConcurrencyStamp",
                value: "9fe8be5d-7650-4a69-9798-ed5c0ed8cceb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e1bc238f-4d9c-4261-b2d5-bbe8d6e6b6ca"),
                column: "ConcurrencyStamp",
                value: "5c6039b8-a1a0-4e2c-b210-914370b7339c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e7c9b1a4-d8f2-4e5c-9b7a-8d6e5f4c3b2a"),
                column: "ConcurrencyStamp",
                value: "b13a21d1-b73e-448b-a719-066cc0b1ca90");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ed14e6e9-05b4-4065-b300-213589e16ff3"),
                column: "ConcurrencyStamp",
                value: "ac53501c-1ae3-4120-ae6c-3e367c77f99f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f2c6c3a5-d7e6-4bd4-8a2f-3b0e8175a1d7"),
                column: "ConcurrencyStamp",
                value: "b152031a-4ca5-403f-9421-9f28db31ad2b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7b90591-d678-462d-9f3d-5497dbd43c5d"),
                column: "ConcurrencyStamp",
                value: "5e850380-ff30-483d-b4b8-0c2db50d4b70");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fb9c2732-0c9c-4a5b-90a4-80ab2f04f6b2"),
                column: "ConcurrencyStamp",
                value: "52a0609d-321b-47f5-aff0-aa0ba5cc027d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f34e61b-78fc-46d3-a179-6c32e62ac195"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f35368b-63b0-431b-b20d-5d89ff03ed07", "AQAAAAIAAYagAAAAEPx+ZeGxiszfKLGog16j0Nq/5EFeTr8j/u8NOazsoJuye7qAM6qgAsa1paeOrhN6dw==", "cad88bad-df14-44dc-9fe8-e6fd23da1370" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a54605a4-d3ed-4fa9-83bc-0ea2cc6193d4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "081996ee-79c5-4359-a40b-f51e1a1ee576", "AQAAAAIAAYagAAAAEE+0VGPoiGRDJz6KHXqCMmGt3iKflUbzABhCIgfh5NAkKOEk8OWN+YePTzDTAZv9LQ==", "3298139f-6630-4d36-b95f-a33aca897eb6" });
        }
    }
}

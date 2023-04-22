using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catchsmart.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAvatarAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarBlob",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AvatarId",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarBlob",
                table: "AspNetUsers",
                type: "longblob",
                nullable: false);
        }
    }
}

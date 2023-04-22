using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catchsmart.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarBlob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarUri",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarBlob",
                table: "AspNetUsers",
                type: "longblob",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarBlob",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUri",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}

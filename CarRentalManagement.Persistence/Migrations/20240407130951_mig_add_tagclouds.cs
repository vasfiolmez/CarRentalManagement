using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_tagclouds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagClouds_Blogs_BlogID",
                table: "TagClouds");

            migrationBuilder.DropIndex(
                name: "IX_TagClouds_BlogID",
                table: "TagClouds");

            migrationBuilder.CreateTable(
                name: "BlogTagCloud",
                columns: table => new
                {
                    BlogsBlogId = table.Column<int>(type: "int", nullable: false),
                    TagCloudsTagCloudID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTagCloud", x => new { x.BlogsBlogId, x.TagCloudsTagCloudID });
                    table.ForeignKey(
                        name: "FK_BlogTagCloud_Blogs_BlogsBlogId",
                        column: x => x.BlogsBlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTagCloud_TagClouds_TagCloudsTagCloudID",
                        column: x => x.TagCloudsTagCloudID,
                        principalTable: "TagClouds",
                        principalColumn: "TagCloudID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTagCloud_TagCloudsTagCloudID",
                table: "BlogTagCloud",
                column: "TagCloudsTagCloudID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTagCloud");

            migrationBuilder.CreateIndex(
                name: "IX_TagClouds_BlogID",
                table: "TagClouds",
                column: "BlogID");

            migrationBuilder.AddForeignKey(
                name: "FK_TagClouds_Blogs_BlogID",
                table: "TagClouds",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

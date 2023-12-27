using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_add1_messagetable1_relational1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageStatus",
                table: "Message2s",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "MessageDetails",
                table: "Message2s",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "MessageDate",
                table: "Message2s",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Message2s",
                newName: "MessageStatus");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Message2s",
                newName: "MessageDetails");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Message2s",
                newName: "MessageDate");
        }
    }
}

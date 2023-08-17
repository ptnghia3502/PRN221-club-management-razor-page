using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubManagementRepositories.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Participant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Membership",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MemberClubBoard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Major",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Grade",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClubBoard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClubActivity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Club",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MemberClubBoard");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Major");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClubBoard");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClubActivity");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Club");
        }
    }
}

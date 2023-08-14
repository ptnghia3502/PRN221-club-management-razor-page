using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubManagementRepositories.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Student",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Participant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Membership",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "MemberClubBoard",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Major",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Grade",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "ClubBoard",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "ClubActivity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Club",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoName",
                table: "Club",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "MemberClubBoard");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Major");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "ClubBoard");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "ClubActivity");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "LogoName",
                table: "Club");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubManagementRepositories.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LogoImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MajorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.MajorId);
                });

            migrationBuilder.CreateTable(
                name: "ClubActivity",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClubActi__45F4A791834445AF", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK__ClubActiv__ClubI__38996AB5",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                });

            migrationBuilder.CreateTable(
                name: "ClubBoard",
                columns: table => new
                {
                    ClubBoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubBoardName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubBoard", x => x.ClubBoardId);
                    table.ForeignKey(
                        name: "FK__ClubBoard__ClubI__31EC6D26",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StudentCardId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AvatarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK__Student__GradeId__286302EC",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "GradeId");
                    table.ForeignKey(
                        name: "FK__Student__MajorId__29572725",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "MajorId");
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    MembershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CardMemberUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK__Membershi__ClubI__2E1BDC42",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId");
                    table.ForeignKey(
                        name: "FK__Membershi__Stude__2F10007B",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "MemberClubBoard",
                columns: table => new
                {
                    MemberClubBoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubBoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MembershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberClubBoard", x => x.MemberClubBoardId);
                    table.ForeignKey(
                        name: "FK__MemberClu__ClubB__35BCFE0A",
                        column: x => x.ClubBoardId,
                        principalTable: "ClubBoard",
                        principalColumn: "ClubBoardId");
                    table.ForeignKey(
                        name: "FK__MemberClu__Membe__34C8D9D1",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "MembershipId");
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsJoined = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK__Participa__Activ__3C69FB99",
                        column: x => x.ActivityId,
                        principalTable: "ClubActivity",
                        principalColumn: "ActivityId");
                    table.ForeignKey(
                        name: "FK__Participa__Membe__3B75D760",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "MembershipId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubActivity_ClubId",
                table: "ClubActivity",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubBoard_ClubId",
                table: "ClubBoard",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberClubBoard_ClubBoardId",
                table: "MemberClubBoard",
                column: "ClubBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberClubBoard_MembershipId",
                table: "MemberClubBoard",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_ClubId",
                table: "Membership",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_StudentId",
                table: "Membership",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ActivityId",
                table: "Participant",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_MembershipId",
                table: "Participant",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeId",
                table: "Student",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_MajorId",
                table: "Student",
                column: "MajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberClubBoard");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "ClubBoard");

            migrationBuilder.DropTable(
                name: "ClubActivity");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Major");
        }
    }
}

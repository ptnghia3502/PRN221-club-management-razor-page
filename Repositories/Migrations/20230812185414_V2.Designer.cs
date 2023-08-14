﻿// <auto-generated />
using System;
using ClubManagementRepositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClubManagementRepositories.Migrations
{
    [DbContext(typeof(ClubManagementContext))]
    [Migration("20230812185414_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClubManagementRepositories.Models.Club", b =>
                {
                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClubName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LogoImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Purpose")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClubId");

                    b.ToTable("Club", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.ClubActivity", b =>
                {
                    b.Property<Guid>("ActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActivityName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ActivityId")
                        .HasName("PK__ClubActi__45F4A791834445AF");

                    b.HasIndex("ClubId");

                    b.ToTable("ClubActivity", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.ClubBoard", b =>
                {
                    b.Property<Guid>("ClubBoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClubBoardName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClubBoardId");

                    b.HasIndex("ClubId");

                    b.ToTable("ClubBoard", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Grade", b =>
                {
                    b.Property<Guid>("GradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GradeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GradeId");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Major", b =>
                {
                    b.Property<Guid>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MajorName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MajorId");

                    b.ToTable("Major", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.MemberClubBoard", b =>
                {
                    b.Property<Guid>("MemberClubBoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClubBoardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MembershipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberClubBoardId");

                    b.HasIndex("ClubBoardId");

                    b.HasIndex("MembershipId");

                    b.ToTable("MemberClubBoard", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Membership", b =>
                {
                    b.Property<Guid>("MembershipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardMemberUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MembershipId");

                    b.HasIndex("ClubId");

                    b.HasIndex("StudentId");

                    b.ToTable("Membership", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Participant", b =>
                {
                    b.Property<Guid>("ParticipantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsJoined")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MembershipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ParticipantId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("MembershipId");

                    b.ToTable("Participant", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvatarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("GradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MajorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCardId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StudentName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("StudentId");

                    b.HasIndex("GradeId");

                    b.HasIndex("MajorId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.ClubActivity", b =>
                {
                    b.HasOne("ClubManagementRepositories.Models.Club", "Club")
                        .WithMany("ClubActivities")
                        .HasForeignKey("ClubId")
                        .HasConstraintName("FK__ClubActiv__ClubI__38996AB5");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.ClubBoard", b =>
                {
                    b.HasOne("ClubManagementRepositories.Models.Club", "Club")
                        .WithMany("ClubBoards")
                        .HasForeignKey("ClubId")
                        .HasConstraintName("FK__ClubBoard__ClubI__31EC6D26");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.MemberClubBoard", b =>
                {
                    b.HasOne("ClubManagementRepositories.Models.ClubBoard", "ClubBoard")
                        .WithMany("MemberClubBoards")
                        .HasForeignKey("ClubBoardId")
                        .HasConstraintName("FK__MemberClu__ClubB__35BCFE0A");

                    b.HasOne("ClubManagementRepositories.Models.Membership", "Membership")
                        .WithMany("MemberClubBoards")
                        .HasForeignKey("MembershipId")
                        .HasConstraintName("FK__MemberClu__Membe__34C8D9D1");

                    b.Navigation("ClubBoard");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Membership", b =>
                {
                    b.HasOne("ClubManagementRepositories.Models.Club", "Club")
                        .WithMany("Memberships")
                        .HasForeignKey("ClubId")
                        .HasConstraintName("FK__Membershi__ClubI__2E1BDC42");

                    b.HasOne("ClubManagementRepositories.Models.Student", "Student")
                        .WithMany("Memberships")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK__Membershi__Stude__2F10007B");

                    b.Navigation("Club");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Participant", b =>
                {
                    b.HasOne("ClubManagementRepositories.Models.ClubActivity", "Activity")
                        .WithMany("Participants")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK__Participa__Activ__3C69FB99");

                    b.HasOne("ClubManagementRepositories.Models.Membership", "Membership")
                        .WithMany("Participants")
                        .HasForeignKey("MembershipId")
                        .HasConstraintName("FK__Participa__Membe__3B75D760");

                    b.Navigation("Activity");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Student", b =>
                {
                    b.HasOne("ClubManagementRepositories.Models.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId")
                        .HasConstraintName("FK__Student__GradeId__286302EC");

                    b.HasOne("ClubManagementRepositories.Models.Major", "Major")
                        .WithMany("Students")
                        .HasForeignKey("MajorId")
                        .HasConstraintName("FK__Student__MajorId__29572725");

                    b.Navigation("Grade");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Club", b =>
                {
                    b.Navigation("ClubActivities");

                    b.Navigation("ClubBoards");

                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.ClubActivity", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.ClubBoard", b =>
                {
                    b.Navigation("MemberClubBoards");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Grade", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Major", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Membership", b =>
                {
                    b.Navigation("MemberClubBoards");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("ClubManagementRepositories.Models.Student", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}

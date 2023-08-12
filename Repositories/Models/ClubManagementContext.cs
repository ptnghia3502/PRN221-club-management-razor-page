using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ClubManagementRepositories.Models
{
    public partial class ClubManagementContext : DbContext
    {
        public ClubManagementContext()
        {
        }

        public ClubManagementContext(DbContextOptions<ClubManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<ClubActivity> ClubActivities { get; set; } = null!;
        public virtual DbSet<ClubBoard> ClubBoards { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<MemberClubBoard> MemberClubBoards { get; set; } = null!;
        public virtual DbSet<Membership> Memberships { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetConnectionString("MyDB");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.ClubId).ValueGeneratedNever();

                entity.Property(e => e.ClubName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LogoImageUrl).HasMaxLength(255);

                entity.Property(e => e.Purpose).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<ClubActivity>(entity =>
            {
                entity.HasKey(e => e.ActivityId)
                    .HasName("PK__ClubActi__45F4A791834445AF");

                entity.ToTable("ClubActivity");

                entity.Property(e => e.ActivityId).ValueGeneratedNever();

                entity.Property(e => e.ActivityName).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubActivities)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__ClubActiv__ClubI__38996AB5");
            });

            modelBuilder.Entity<ClubBoard>(entity =>
            {
                entity.ToTable("ClubBoard");

                entity.Property(e => e.ClubBoardId).ValueGeneratedNever();

                entity.Property(e => e.ClubBoardName).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubBoards)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__ClubBoard__ClubI__31EC6D26");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.GradeId).ValueGeneratedNever();

                entity.Property(e => e.GradeName).HasMaxLength(255);
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.MajorId).ValueGeneratedNever();

                entity.Property(e => e.MajorName).HasMaxLength(255);
            });

            modelBuilder.Entity<MemberClubBoard>(entity =>
            {
                entity.ToTable("MemberClubBoard");

                entity.Property(e => e.MemberClubBoardId).ValueGeneratedNever();

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.ClubBoard)
                    .WithMany(p => p.MemberClubBoards)
                    .HasForeignKey(d => d.ClubBoardId)
                    .HasConstraintName("FK__MemberClu__ClubB__35BCFE0A");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.MemberClubBoards)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK__MemberClu__Membe__34C8D9D1");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership");

                entity.Property(e => e.MembershipId).ValueGeneratedNever();

                entity.Property(e => e.CardMemberUrl).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__Membershi__ClubI__2E1BDC42");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Membershi__Stude__2F10007B");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.ParticipantId).ValueGeneratedNever();

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK__Participa__Activ__3C69FB99");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK__Participa__Membe__3B75D760");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.AvatarUrl).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.StudentCardId).HasMaxLength(255);

                entity.Property(e => e.StudentName).HasMaxLength(255);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK__Student__GradeId__286302EC");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Student__MajorId__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

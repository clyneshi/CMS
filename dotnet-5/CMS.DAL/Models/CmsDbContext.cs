using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CMS.DAL.Models;

public partial class CmsDbContext : DbContext
{
    public CmsDbContext()
    {
    }

    public CmsDbContext(DbContextOptions<CmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<ConferenceMember> ConferenceMembers { get; set; }

    public virtual DbSet<ConferenceTopic> ConferenceTopics { get; set; }

    public virtual DbSet<Expertise> Expertises { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Keyword> Keywords { get; set; }

    public virtual DbSet<Paper> Papers { get; set; }

    public virtual DbSet<PaperReview> PaperReviews { get; set; }

    public virtual DbSet<PaperTopic> PaperTopics { get; set; }

    public virtual DbSet<RegisterRequest> RegisterRequests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conference>(entity =>
        {
            entity.ToTable("Conference");

            entity.HasIndex(e => e.ChairId, "IX_Conference_ChairId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BeginDate).HasColumnType("date");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaperDeadline).HasColumnType("date");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Chair).WithMany(p => p.Conferences)
                .HasForeignKey(d => d.ChairId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conference_User");
        });

        modelBuilder.Entity<ConferenceMember>(entity =>
        {
            entity.ToTable("ConferenceMember");

            entity.HasIndex(e => e.ConferenceId, "IX_ConferenceMember_ConferenceId");

            entity.HasIndex(e => e.UserId, "IX_ConferenceMember_UserId");

            entity.HasOne(d => d.Conference).WithMany(p => p.ConferenceMembers)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceMember_Conference");

            entity.HasOne(d => d.User).WithMany(p => p.ConferenceMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceMember_User");
        });

        modelBuilder.Entity<ConferenceTopic>(entity =>
        {
            entity.ToTable("ConferenceTopic");

            entity.HasIndex(e => e.ConferenceId, "IX_ConferenceTopic_ConferenceId");

            entity.HasIndex(e => e.KeywordId, "IX_ConferenceTopic_KeywordId");

            entity.HasOne(d => d.Conference).WithMany(p => p.ConferenceTopics)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceTopic_Conference");

            entity.HasOne(d => d.Keyword).WithMany(p => p.ConferenceTopics)
                .HasForeignKey(d => d.KeywordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceTopic_Keyword");
        });

        modelBuilder.Entity<Expertise>(entity =>
        {
            entity.ToTable("Expertise");

            entity.HasIndex(e => e.KeywordId, "IX_Expertise_KeywordId");

            entity.HasIndex(e => e.UserId, "IX_Expertise_UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Keyword).WithMany(p => p.Expertises)
                .HasForeignKey(d => d.KeywordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expertise_Keyword");

            entity.HasOne(d => d.User).WithMany(p => p.Expertises)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expertise_User");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.HasIndex(e => e.PaperId, "IX_Feedback_PaperId");

            entity.HasIndex(e => e.UserId, "IX_Feedback_UserId");

            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.FinalDecision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Paper).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.PaperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Paper");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_User");
        });

        modelBuilder.Entity<Keyword>(entity =>
        {
            entity.ToTable("Keyword");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Genre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paper>(entity =>
        {
            entity.ToTable("Paper");

            entity.HasIndex(e => e.AuthorId, "IX_Paper_AuthorId");

            entity.HasIndex(e => e.ConferenceId, "IX_Paper_ConferenceId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Format)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Length)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SubmissionDate).HasColumnType("date");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.Papers)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paper_User");

            entity.HasOne(d => d.Conference).WithMany(p => p.Papers)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paper_Conference");
        });

        modelBuilder.Entity<PaperReview>(entity =>
        {
            entity.ToTable("PaperReview");

            entity.HasIndex(e => e.PaperId, "IX_PaperReview_PaperId");

            entity.HasIndex(e => e.UserId, "IX_PaperReview_UserId");

            entity.HasOne(d => d.Paper).WithMany(p => p.PaperReviews)
                .HasForeignKey(d => d.PaperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaperReview_Paper");

            entity.HasOne(d => d.User).WithMany(p => p.PaperReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaperReview_User");
        });

        modelBuilder.Entity<PaperTopic>(entity =>
        {
            entity.ToTable("PaperTopic");

            entity.HasIndex(e => e.KeywordId, "IX_PaperTopic_KeywordId");

            entity.HasIndex(e => e.PaperId, "IX_PaperTopic_PaperId");

            entity.HasOne(d => d.Keyword).WithMany(p => p.PaperTopics)
                .HasForeignKey(d => d.KeywordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaperTopic_Keyword");

            entity.HasOne(d => d.Paper).WithMany(p => p.PaperTopics)
                .HasForeignKey(d => d.PaperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaperTopic_Paper");
        });

        modelBuilder.Entity<RegisterRequest>(entity =>
        {
            entity.ToTable("RegisterRequest");

            entity.HasIndex(e => e.ConferenceId, "IX_RegisterRequest_ConferenceId");

            entity.HasIndex(e => e.RoleId, "IX_RegisterRequest_RoleId");

            entity.Property(e => e.Contact)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Conference).WithMany(p => p.RegisterRequests)
                .HasForeignKey(d => d.ConferenceId)
                .HasConstraintName("FK_RegisterRequest_Conference");

            entity.HasOne(d => d.Role).WithMany(p => p.RegisterRequests)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegisterRequest_Role");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.RoleId, "IX_User_RoleId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Contact)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

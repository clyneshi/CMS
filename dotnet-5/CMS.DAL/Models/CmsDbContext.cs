using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CMS.DAL.Models
{
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
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Conference>(entity =>
            {
                entity.ToTable("Conference");

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

                entity.HasOne(d => d.Chair)
                    .WithMany(p => p.Conferences)
                    .HasForeignKey(d => d.ChairId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conference_User");
            });

            modelBuilder.Entity<ConferenceMember>(entity =>
            {
                entity.ToTable("ConferenceMember");

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.ConferenceMembers)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceMember_Conference");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConferenceMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceMember_User");
            });

            modelBuilder.Entity<ConferenceTopic>(entity =>
            {
                entity.ToTable("ConferenceTopic");

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.ConferenceTopics)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceTopic_Conference");

                entity.HasOne(d => d.Keyword)
                    .WithMany(p => p.ConferenceTopics)
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConferenceTopic_Keyword");
            });

            modelBuilder.Entity<Expertise>(entity =>
            {
                entity.ToTable("Expertise");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Keyword)
                    .WithMany(p => p.Expertises)
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expertise_Keyword");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Expertises)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expertise_User");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Feedback1)
                    .IsUnicode(false)
                    .HasColumnName("Feedback");

                entity.Property(e => e.FinalDecision)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Paper)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.PaperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Paper");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
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

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Papers)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paper_User");

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.Papers)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paper_Conference");
            });

            modelBuilder.Entity<PaperReview>(entity =>
            {
                entity.ToTable("PaperReview");

                entity.HasOne(d => d.Paper)
                    .WithMany(p => p.PaperReviews)
                    .HasForeignKey(d => d.PaperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaperReview_Paper");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaperReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaperReview_User");
            });

            modelBuilder.Entity<PaperTopic>(entity =>
            {
                entity.ToTable("PaperTopic");

                entity.HasOne(d => d.Keyword)
                    .WithMany(p => p.PaperTopics)
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaperTopic_Keyword");

                entity.HasOne(d => d.Paper)
                    .WithMany(p => p.PaperTopics)
                    .HasForeignKey(d => d.PaperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaperTopic_Paper");
            });

            modelBuilder.Entity<RegisterRequest>(entity =>
            {
                entity.ToTable("RegisterRequest");

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

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.RegisterRequests)
                    .HasForeignKey(d => d.ConferenceId)
                    .HasConstraintName("FK_RegisterRequest_Conference");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RegisterRequests)
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

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

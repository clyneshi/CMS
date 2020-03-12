namespace CMS.DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CMSContext : DbContext
    {
        public CMSContext()
            : base("name=CMSContext")
        {
            Database.SetInitializer(new CMSDBInitializer());
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conference>()
                .Property(e => e.confTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Conference>()
                .Property(e => e.confLocation)
                .IsUnicode(false);

            modelBuilder.Entity<Conference>()
                .HasMany(e => e.ConferenceMembers)
                .WithRequired(e => e.Conference)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conference>()
                .HasMany(e => e.ConferenceTopics)
                .WithRequired(e => e.Conference)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conference>()
                .HasMany(e => e.Papers)
                .WithRequired(e => e.Conference)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.fnlDecision)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.feedback1)
                .IsUnicode(false);

            modelBuilder.Entity<Keyword>()
                .Property(e => e.keywrdGenre)
                .IsUnicode(false);

            modelBuilder.Entity<Keyword>()
                .Property(e => e.keywrdName)
                .IsUnicode(false);

            modelBuilder.Entity<Keyword>()
                .HasMany(e => e.ConferenceTopics)
                .WithRequired(e => e.Keyword)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Keyword>()
                .HasMany(e => e.Expertises)
                .WithRequired(e => e.Keyword)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Keyword>()
                .HasMany(e => e.PaperTopics)
                .WithRequired(e => e.Keyword)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.paperTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.paperAuthor)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.paperLength)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.paperFormat)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.paperStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .Property(e => e.paperFileName)
                .IsUnicode(false);

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Paper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.PaperReviews)
                .WithRequired(e => e.Paper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paper>()
                .HasMany(e => e.PaperTopics)
                .WithRequired(e => e.Paper)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisterRequest>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<RegisterRequest>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<RegisterRequest>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<RegisterRequest>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<RegisterRequest>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.roleType)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RegisterRequests)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userEmail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userPasswrd)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.userContact)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Conferences)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.chairId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ConferenceMembers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expertises)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Papers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.auId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PaperReviews)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

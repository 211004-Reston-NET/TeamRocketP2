using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL.Entities
{
    public partial class P3ApiContext : DbContext
    {
        public P3ApiContext()
        {
        }

        public P3ApiContext(DbContextOptions<P3ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("End_Time");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Event_Description");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Event_Name");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Start_Time");
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.ToTable("Forum");

                entity.Property(e => e.ForumId).HasColumnName("Forum_Id");

                entity.Property(e => e.AmountOfPosts).HasColumnName("Amount_of_Posts");

                entity.Property(e => e.CreatorId).HasColumnName("Creator_Id");

                entity.Property(e => e.DateCreated)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Date_Created");

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Topic_Name");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Forums)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Forum__Creator_I__04E4BC85");
            });

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.ToTable("invite");

                entity.Property(e => e.InviteId).HasColumnName("Invite_Id");

                entity.Property(e => e.EmailRecipient)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Email_Recipient");

                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__invite__Event_Id__02FC7413");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__invite__User_Id__03F0984C");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("Post_Id");

                entity.Property(e => e.DateCreated)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Date_Created");

                entity.Property(e => e.ForumId).HasColumnName("Forum_Id");

                entity.Property(e => e.PostText)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Post_Text");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ForumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__Forum_Id__07C12930");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__User_Id__05D8E0BE");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.Property(e => e.ReplyId).HasColumnName("Reply_Id");

                entity.Property(e => e.DateCreated)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Date_Created");

                entity.Property(e => e.PostId).HasColumnName("Post_Id");

                entity.Property(e => e.ReplyText)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Reply_Text");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Replies__Post_Id__0C85DE4D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Replies__User_Id__06CD04F7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456826BF494")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NameOfUser)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

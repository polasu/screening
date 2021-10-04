using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace trinityScreening.Models_New
{
    public partial class screeningDBContext : DbContext
    {
        public screeningDBContext()
        {
        }

        public screeningDBContext(DbContextOptions<screeningDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblQuestion> TblQuestions { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserQuestionAn> TblUserQuestionAns { get; set; }
        public virtual DbSet<UserQa> UserQas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DevConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblQuestion>(entity =>
            {
                entity.ToTable("tblQuestions");

                entity.Property(e => e.Question)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.Property(e => e.Confirmpwd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserQuestionAn>(entity =>
            {
                entity.ToTable("tblUserQuestionAns");

                entity.Property(e => e.QuestionId).HasColumnName("Question_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<UserQa>(entity =>
            {
                entity.ToTable("UserQA");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserQaId).HasColumnName("User_QA_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DropDownFilter.DataAccess.DatabaseContext
{
    public partial class DropDownFilterDBContext : DbContext
    {
        public DropDownFilterDBContext()
        {
        }

        public DropDownFilterDBContext(DbContextOptions<DropDownFilterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-8K8MQUP;Database=DropDownFilterDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.HashValue).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MobileNo).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.ProfileImage).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

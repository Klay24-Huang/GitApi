using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GitApi.Models
{
    public partial class GitWebApiContext : DbContext
    {
        public GitWebApiContext()
        {
        }

        public GitWebApiContext(DbContextOptions<GitWebApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlreadyCheckoutLists> AlreadyCheckoutLists { get; set; }
        public virtual DbSet<ChangeFormRecords> ChangeFormRecords { get; set; }
        public virtual DbSet<CheckOutRecords> CheckOutRecords { get; set; }
        public virtual DbSet<RemoteRepository> RemoteRepositories { get; set; }
        public virtual DbSet<ShowBranchs> ShowBranchs { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlreadyCheckoutLists>(entity =>
            {
                entity.HasKey(e => e.AlreadyCheckoutListId);

                entity.Property(e => e.AlreadyCheckoutListId)
                    .HasColumnName("AlreadyCheckoutListID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ChangeFormRecords>(entity =>
            {
                entity.HasKey(e => e.ChangeFormRecordId);

                entity.ToTable("changeFormRecords");

                entity.Property(e => e.ChangeFormRecordId)
                    .HasColumnName("ChangeFormRecordID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<CheckOutRecords>(entity =>
            {
                entity.HasKey(e => e.CheckOutRecordId);

                entity.Property(e => e.CheckOutRecordId)
                    .HasColumnName("CheckOutRecordID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<RemoteRepository>(entity =>
            {
                entity.HasKey(e => e.RemoteRepositoryId);

                entity.ToTable("remoteRepositories");

                entity.Property(e => e.RemoteRepositoryId)
                    .HasColumnName("RemoteRepositoryID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ShowBranchs>(entity =>
            {
                entity.HasKey(e => e.ShowBranchId);

                entity.ToTable("showBranchs");

                entity.Property(e => e.ShowBranchId)
                    .HasColumnName("ShowBranchID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RemoteRepositoryId).HasColumnName("RemoteRepositoryID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Date).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

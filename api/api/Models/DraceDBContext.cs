using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class DraceDBContext : DbContext
    {
        public DraceDBContext()
        {
        }

        public DraceDBContext(DbContextOptions<DraceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=zet46_SampleDB;user id=zet46_SampleDB;password=P@ssword;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.ContractAddress);

                entity.Property(e => e.ContractAddress).HasMaxLength(250);

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RacerName).HasMaxLength(50);

                entity.Property(e => e.RacerTelegram).HasMaxLength(50);
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.Property(e => e.ContractAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.ContractAddressNavigation)
                    .WithMany(p => p.Deposits)
                    .HasForeignKey(d => d.ContractAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Deposits_Contracts");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.ContractAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.ContractAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.ContractAddressNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ContractAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Contracts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

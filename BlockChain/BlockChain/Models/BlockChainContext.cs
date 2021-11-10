using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlockChain.Models
{
    public partial class BlockChainContext : DbContext
    {
        public BlockChainContext()
        {
        }

        public BlockChainContext(DbContextOptions<BlockChainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cus> Cus { get; set; }
        public virtual DbSet<PubBook> PubBook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TRUONGTAM\\SQLEXPRESS;Initial Catalog=BlockChain;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cus>(entity =>
            {
                entity.Property(e => e.Money).HasColumnType("decimal(8, 0)");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PubBook>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HashCode).HasMaxLength(250);

                entity.Property(e => e.HashFinal).HasMaxLength(250);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

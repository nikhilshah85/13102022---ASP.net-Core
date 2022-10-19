using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace shoppingAPI.Models.EF
{
    public partial class shoppingDBContext : DbContext
    {
        public shoppingDBContext()
        {
        }

        public shoppingDBContext(DbContextOptions<shoppingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=WIN8\\NIKHILINSTANCE;database=shoppingDB;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__orders__C2FECB3B6EE673FF");

                entity.ToTable("orders");

                entity.Property(e => e.OId)
                    .ValueGeneratedNever()
                    .HasColumnName("oId");

                entity.Property(e => e.OCustomer)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("oCustomer");

                entity.Property(e => e.OProduct).HasColumnName("oProduct");

                entity.Property(e => e.OQty).HasColumnName("oQty");

                entity.Property(e => e.OValue).HasColumnName("oValue");

                entity.HasOne(d => d.OProductNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OProduct)
                    .HasConstraintName("fk_oProduct");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__products__DD36D562D161C3F3");

                entity.ToTable("products");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("pId");

                entity.Property(e => e.PCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pCategory");

                entity.Property(e => e.PIsAvailable).HasColumnName("pIsAvailable");

                entity.Property(e => e.PName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pName");

                entity.Property(e => e.PPrice).HasColumnName("pPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

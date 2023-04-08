using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Domain
{

    public partial class EmoBaseContext : DbContext
    {
        public EmoBaseContext()
        {
        }

        public EmoBaseContext(DbContextOptions<EmoBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Baskets { get; set; }

        public virtual DbSet<BuyHistory> BuyHistories { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK__Basket__B40CC6CD8AFFEB2C");

                entity.ToTable("Basket");

                entity.Property(e => e.ProductId).ValueGeneratedNever();
                entity.Property(e => e.Discount).HasColumnName("discount");
                entity.Property(e => e.Product).HasMaxLength(50);
            });

            modelBuilder.Entity<BuyHistory>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.ProductId }).HasName("PK__BuyHisto__00E17E3B8614CD83");

                entity.ToTable("BuyHistory");

                entity.Property(e => e.Userid).HasColumnName("userid");
                entity.Property(e => e.Buyid)
                    .HasColumnType("datetime")
                    .HasColumnName("buyid");

                entity.HasOne(d => d.Product).WithMany(p => p.BuyHistories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BuyHistory_Basket");

                entity.HasOne(d => d.User).WithMany(p => p.BuyHistories)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BuyHistory_users");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Categoryid).HasName("PK__category__23CDE5908FEBBC0A");

                entity.ToTable("category");

                entity.Property(e => e.Categoryid)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryid");
                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .HasColumnName("categoryname");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => new { e.Categoryid, e.Productid }).HasName("PK__products__111C97436F226216");

                entity.ToTable("products");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");
                entity.Property(e => e.Productid).HasColumnName("productid");
                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_products_category");

                entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Products)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_products_Basket");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Userid).HasName("PK__reviews__CBA1B2571CAA06B3");

                entity.ToTable("reviews");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");
                entity.Property(e => e.Comment)
                    .HasMaxLength(2500)
                    .HasColumnName("comment");
                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.User).WithOne(p => p.Review)
                    .HasForeignKey<Review>(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviews_users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Userid).HasName("PK__users__CBA1B2572BA314F5");

                entity.ToTable("users");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");
                entity.Property(e => e.Login1)
                    .HasMaxLength(50)
                    .HasColumnName("login1");
                entity.Property(e => e.Password1)
                    .HasMaxLength(50)
                    .HasColumnName("password1");
                entity.Property(e => e.Role1)
                    .HasMaxLength(20)
                    .HasColumnName("role1");

                entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_Basket");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer;

public partial class SkincareProductSystemContext : DbContext
{
    public SkincareProductSystemContext()
    {
    }

    public SkincareProductSystemContext(DbContextOptions<SkincareProductSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SkincareProduct> SkincareProducts { get; set; }

    public virtual DbSet<TypeOfSkin> TypeOfSkins { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brand__DAD4F05E3595EA29");

            entity.ToTable("Brand");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Brands)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKBrand47697");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BD92E4453");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCategory337703");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFFBE971E6");

            entity.ToTable("Order");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKOrder39294");

            entity.HasMany(d => d.SkincareProducts).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderDetail",
                    r => r.HasOne<SkincareProduct>().WithMany()
                        .HasForeignKey("SkincareProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKOrderDetai412706"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKOrderDetai351167"),
                    j =>
                    {
                        j.HasKey("OrderId", "SkincareProductId").HasName("PK__OrderDet__CE7C2571B265CDDC");
                        j.ToTable("OrderDetails");
                    });
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FACC6E7BC12");

            entity.ToTable("Question");

            entity.Property(e => e.Answer).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1ACD7ECF52");

            entity.ToTable("Role");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SkincareProduct>(entity =>
        {
            entity.HasKey(e => e.SkincareProductId).HasName("PK__Skincare__DEC7EBE1DFC61650");

            entity.ToTable("SkincareProduct");

            entity.Property(e => e.Capacity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Brand).WithMany(p => p.SkincareProducts)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSkincarePr37782");

            entity.HasOne(d => d.Category).WithMany(p => p.SkincareProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSkincarePr66470");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.SkincareProducts)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSkincarePr229752");
        });

        modelBuilder.Entity<TypeOfSkin>(entity =>
        {
            entity.HasKey(e => e.TypeOfSkinId).HasName("PK__TypeOfSk__E4DB09EC99291509");

            entity.ToTable("TypeOfSkin");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__User__536C85E5DC433083");

            entity.ToTable("User");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(5);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUser68428");

            entity.HasOne(d => d.TypeOfSkin).WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeOfSkinId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUser447311");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    private string? GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        return config["ConnectionStrings:DefaultConnection"];
    }
}

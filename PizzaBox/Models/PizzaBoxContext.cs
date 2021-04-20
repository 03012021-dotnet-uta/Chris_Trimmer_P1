using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Models.Models;

#nullable disable

namespace Models
{
    /// <summary>
    /// This is the DbContext class for the project
    /// It creates the DbSets for Components, Customers, Orders,
    /// Pizzas, and Stores.
    /// The connection string is protected by User Secret and set
    /// in StartUp file using Dependency Injection.
    /// </summary>
    public partial class PizzaBoxContext : DbContext
    {
        public PizzaBoxContext()
        {
        }

        public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acomponent> Acomponents { get; set; }
        public virtual DbSet<Acustomer> Acustomers { get; set; }
        public virtual DbSet<Aorder> Aorders { get; set; }
        public virtual DbSet<Apizza> Apizzas { get; set; }
        public virtual DbSet<Astore> Astores { get; set; }


        /// <summary>
        /// Use this in case app does not use optionsBuilder.
        /// We are using dependency injection in StartUp, so we don't
        /// need to get connection string here.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (ConfigurationManager.ConnectionStrings["PizzaBox"].ConnectionString);
            }

        }

        /// <summary>
        /// These functions are built by VS.
        /// I used DB First approach.
        /// Each DbSet is created using Model Builder per the
        /// database design.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Acomponent>(entity =>
            {
                entity.ToTable("AComponent");

                entity.Property(e => e.AcomponentId).HasColumnName("AComponentId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Acomponents)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PizzaCompId");
            });

            modelBuilder.Entity<Acustomer>(entity =>
            {
                entity.ToTable("ACustomer");

                entity.Property(e => e.AcustomerId).HasColumnName("ACustomerId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aorder>(entity =>
            {
                entity.ToTable("AOrder");

                entity.Property(e => e.AorderId).HasColumnName("AOrderId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Aorders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_custId");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Aorders)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pizzaId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Aorders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_storeId");
            });

            modelBuilder.Entity<Apizza>(entity =>
            {
                entity.ToTable("APizza");

                entity.Property(e => e.ApizzaId).HasColumnName("APizzaId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Astore>(entity =>
            {
                entity.ToTable("AStore");

                entity.Property(e => e.AstoreId).HasColumnName("AStoreId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

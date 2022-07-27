using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace IMDB.DataAccessLayer.Models
{
    public partial class IMDBDataBaseContext : DbContext
    {
        public IMDBDataBaseContext()
        {
        }

        public IMDBDataBaseContext(DbContextOptions<IMDBDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<MoviesActors> MoviesActors { get; set; }
        public virtual DbSet<Producers> Producers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("IMDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //                optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB;Initial Catalog=IMDBDataBase;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.HasKey(e => e.ActorId);

                entity.Property(e => e.ActorBio).HasMaxLength(300);

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.DateOfRelease).HasColumnType("date");

                entity.Property(e => e.MovieName).HasMaxLength(50);

                entity.Property(e => e.Plot).HasMaxLength(200);

                entity.Property(e => e.PosterImageSource).HasMaxLength(200);

                entity.HasOne(d => d.ProducerNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Producer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producer");
            });

            modelBuilder.Entity<MoviesActors>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MoviesActors)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ActorId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MoviesActors)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MovieId");
            });

            modelBuilder.Entity<Producers>(entity =>
            {
                entity.HasKey(e => e.ProducerId);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ProducerBio).HasMaxLength(300);

                entity.Property(e => e.ProducerName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}

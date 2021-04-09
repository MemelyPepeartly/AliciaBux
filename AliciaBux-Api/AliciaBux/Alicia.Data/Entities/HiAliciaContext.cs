using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Alicia.Data.Entities
{
    public partial class HiAliciaContext : DbContext
    {
        public HiAliciaContext()
        {
        }

        public HiAliciaContext(DbContextOptions<HiAliciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Podcaster> Podcasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Podcaster>(entity =>
            {
                entity.ToTable("Podcaster", "app");

                entity.Property(e => e.PodcasterId)
                    .ValueGeneratedNever()
                    .HasColumnName("podcasterID");

                entity.Property(e => e.PodcasterBalance).HasColumnName("podcasterBalance");

                entity.Property(e => e.PodcasterName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("podcasterName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

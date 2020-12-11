using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCore.Legado
{
    public partial class HeroAppContext : DbContext
    {
        public HeroAppContext()
        {
        }

        public HeroAppContext(DbContextOptions<HeroAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<HeroBattle> HeroBattles { get; set; }
        public virtual DbSet<Identity> Identities { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Data Source=DESKTOP-N4UG5JG;Initial Catalog=HeroApp;Persist Security Info=False; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<HeroBattle>(entity =>
            {
                entity.HasKey(e => new { e.BattleId, e.HeroId });

                entity.HasIndex(e => e.HeroId, "IX_HeroBattles_HeroId");

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.HeroBattles)
                    .HasForeignKey(d => d.BattleId);

                entity.HasOne(d => d.Hero)
                    .WithMany(p => p.HeroBattles)
                    .HasForeignKey(d => d.HeroId);
            });

            modelBuilder.Entity<Identity>(entity =>
            {
                entity.ToTable("Identity");

                entity.HasIndex(e => e.HeroId, "IX_Identity_HeroId")
                    .IsUnique();

                entity.HasOne(d => d.Hero)
                    .WithOne(p => p.Identity)
                    .HasForeignKey<Identity>(d => d.HeroId);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasIndex(e => e.HeroId, "IX_Weapons_HeroId");

                entity.HasOne(d => d.Hero)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.HeroId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

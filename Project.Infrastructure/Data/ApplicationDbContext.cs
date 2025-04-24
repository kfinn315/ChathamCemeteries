using Microsoft.EntityFrameworkCore;
using Project.Core.Entities.General;

namespace Project.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public virtual DbSet<Cemetery> Cemeteries { get; set; }

    public virtual DbSet<Grave> Graves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cemetery>(entity =>
        {
            entity.ToTable("cemeteries");

            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.Property(e => e.Restricted).HasColumnName("restricted")
                .HasDefaultValueSql("true")
                .HasColumnName("restricted");
            entity.HasMany(n => n.Graves).WithOne(n => n.Cemetery).HasForeignKey(f => f.CemeteryId);
        });

        modelBuilder.Entity<Grave>(entity =>
        {
            entity.ToTable("graves");
            // entity.Property(e => e.Id).HasColumnName("_rowid_");
            entity.Property(e => e.BirthYear).HasColumnName("birthyear");
            entity.Property(e => e.DeathYear).HasColumnName("deathyear");
            entity.Property(e => e.LastName).HasColumnName("lastname");
            entity.Property(e => e.CemeteryId).HasColumnName("cemeteryid");
            entity.HasOne(n => n.Cemetery).WithMany(n => n.Graves).HasForeignKey(f => f.CemeteryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

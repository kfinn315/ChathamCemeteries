// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using Project.Core.Entities.General;

// namespace Project.Infrastructure.Data;

// public partial class CemeteriesContext : DbContext
// {
//     public CemeteriesContext()
//     {
//     }

//     public CemeteriesContext(DbContextOptions<CemeteriesContext> options)
//         : base(options)
//     {
//     }

//     public virtual DbSet<Cemetery> Cemeteries { get; set; }

//     public virtual DbSet<Grave> Graves { get; set; }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Cemetery>(entity =>
//         {
//             entity.ToTable("cemeteries");

//             entity.Property(e => e.Id).ValueGeneratedNever();
//             entity.Property(e => e.Restricted)
//                 .HasDefaultValueSql("true")
//                 .HasColumnName("restricted");
//         });

//         modelBuilder.Entity<Grave>(entity =>
//         {
//             entity.ToTable("graves");
//             entity.Property(e => e.Id).HasColumnName("_rowid_");
//             entity.Property(e => e.CemeteryId).HasColumnName("CemeteryID");
//             entity.OwnsOne(grave => grave.Death, ownedNavigationBuilder =>
//             {
//                 ownedNavigationBuilder.ToJson();
//             });
//             entity.OwnsOne(grave => grave.Birth, ownedNavigationBuilder =>
//             {
//                 ownedNavigationBuilder.ToJson();
//             });
//         });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }

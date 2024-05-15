using API_Magazynex_New;
using API_Magazynex_New.Encje;
using Microsoft.EntityFrameworkCore;
using System;
using API_Magazynex_New.Configs;

public class DatabaseContext : DbContext
{
     public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options) { }

    public DbSet<Firma> Firmas => Set<Firma>();
    public DbSet<Pracownik> Pracowniks => Set<Pracownik>();
    public DbSet<Towar> Towars => Set<Towar>();
    public DbSet<Magazyn> magazyns => Set<Magazyn>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Magazyn>(_ => new MagazynConfiguration());

        modelBuilder.Entity<Firma>(_ => new FirmaConfiguration());

        base.OnModelCreating(modelBuilder);
    }
    
  

}

﻿using API_Magazynex_New;
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
    public DbSet<Magazyn> Magazyns => Set<Magazyn>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Magazyn>(_ => new MagazynConfiguration());

        modelBuilder.Entity<Firma>(_ => new FirmaConfiguration());

        modelBuilder.Entity<Pracownik>(_ => new PracownikConfiguration());

        modelBuilder.Entity<Towar>(_ => new TowarConfiguration());

        modelBuilder.Entity<Firma>().HasQueryFilter(x => x.IsActive);

        modelBuilder.Entity<Magazyn>().HasQueryFilter(x => x.IsActive);

        base.OnModelCreating(modelBuilder);
    }
    
  

}

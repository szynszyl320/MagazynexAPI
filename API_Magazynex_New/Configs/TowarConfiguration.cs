﻿using API_Magazynex_New.Encje;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Magazynex_New.Configs
{
    public class TowarConfiguration : IEntityTypeConfiguration<Towar>
    {
        public void Configure(EntityTypeBuilder<Towar> builder) 
        { 
            builder.HasKey(x => x.id);

            builder.Property(x => x.Nazwa_Produktu).IsRequired();
            
            builder.Property(x => x.Opis_Produktu).IsRequired();

            builder.Property(x => x.Klasa_Towarow_Niebezpiecznych)
                .HasMaxLength(1)
                .IsRequired();
        
            builder.Property(x => x.Cena_Netto_Za_Sztuke).IsRequired();

            builder.Property(x => x.Ilosc).IsRequired();
        }
        
        
        void IEntityTypeConfiguration<Towar>.Configure(EntityTypeBuilder<Towar> builder)
        {
            throw new NotImplementedException();
        }
    }
}

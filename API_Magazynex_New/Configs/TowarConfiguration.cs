using API_Magazynex_New.Encje;
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
        
            builder.Property(x => x.Cena_Netto_Za_Sztuke).IsRequired();

            builder.Property(x => x.Ilosc).IsRequired();

            builder.HasOne(x => x.Firma)
                .WithMany(x => x.Towars)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(x => x.Magazyn)
                .WithMany(x => x.Towary)
                .IsRequired(false);
        
        
        }



    }
}

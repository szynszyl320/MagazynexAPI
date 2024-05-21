using API_Magazynex_New.Encje;
using API_Magazynex_New.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Namotion.Reflection;

namespace API_Magazynex_New.Configs
{
    public class MagazynConfiguration : IEntityTypeConfiguration<Magazyn>
    {
        public void Configure(EntityTypeBuilder<Magazyn> builder)
        {
            var converter = new ValueConverter<List<Mozliwosc_Pechowywania_Materialow>, string>(
            v => string.Join(",", v.Select(e => e.ToString())),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(e => System.Enum.Parse<Mozliwosc_Pechowywania_Materialow>(e)).ToList());

            builder.HasMany(x => x.Towary)
               .WithOne(x => x.Magazyn)
               .HasForeignKey(x => x.MagazynId)
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Pracownicy)
                .WithOne(x => x.Magazyn)
                .HasForeignKey(x => x.MagazynId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nazwa).IsRequired();
            
            builder.Property(x => x.lokalizacja).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.Przechowywane_Materialy)
                .HasConversion(converter);
        }
    }


}


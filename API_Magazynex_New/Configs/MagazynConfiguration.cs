using API_Magazynex_New.Encje;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Magazynex_New.Configs
{
    public class MagazynConfiguration : IEntityTypeConfiguration<Magazyn>
    {
        public void Configure(EntityTypeBuilder<Magazyn> builder)
        {
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

            builder.HasQueryFilter(x => !x.IsActive);

        }
    }


}


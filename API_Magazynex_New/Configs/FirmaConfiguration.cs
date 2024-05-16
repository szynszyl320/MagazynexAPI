using API_Magazynex_New.Encje;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Namotion.Reflection;

namespace API_Magazynex_New.Configs
{
    public class FirmaConfiguration : IEntityTypeConfiguration<Firma>
    {
        public void Configure(EntityTypeBuilder<Firma> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nazwa)
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.Numer_Telefonu).IsRequired();

            builder.HasMany(x => x.Towars)
                .WithOne(x => x.Firma)
                .HasForeignKey(x => x.FirmaId);

            builder.Property(x => x.IsActive).IsRequired();

            //builder.HasQueryFilter(x => x.IsActive);
        }
    }
}

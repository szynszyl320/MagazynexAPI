using Magazynex_console;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Magazynex_New
{
    public class MagazynConfiguration : IEntityTypeConfiguration<Magazyn>
    {
        public void Configure(EntityTypeBuilder<Magazyn> builder)
        {
            builder.HasMany(x => x.Towary)
               .WithOne(x => x.Magazyn)
               .HasForeignKey(x => x.MagazynId);
        }
    }
}

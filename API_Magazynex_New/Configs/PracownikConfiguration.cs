using API_Magazynex_New.Encje;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Magazynex_New.Configs
{
    public class PracownikConfiguration : IEntityTypeConfiguration<Pracownik>
    {
        public void Configure(EntityTypeBuilder<Pracownik> builder) 
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Imie)
                .HasMaxLength(40)
                .IsRequired();
        
            builder.Property(x => x.Nazwisko)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Stanowisko).IsRequired();

            builder.Property(x => x.Numer_Telefonu).IsRequired();
        }
        
        
        void IEntityTypeConfiguration<Pracownik>.Configure(EntityTypeBuilder<Pracownik> builder)
        {
            throw new NotImplementedException();
        }
    }
}

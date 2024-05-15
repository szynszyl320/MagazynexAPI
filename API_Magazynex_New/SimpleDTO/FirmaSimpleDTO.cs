using API_Magazynex_New.Encje;

namespace API_Magazynex_New.SimpleDTO
{
    public class FirmaSimpleDTO
    {
        public FirmaSimpleDTO(Firma firma)
        {
            Id = firma.Id;
            Name = firma.Nazwa;
            foreach (var towar in firma.towars)
            {
                Towaries.Add(new TowarySimpleDTO(towar));
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<TowarySimpleDTO> Towaries { get; set; } = new List<TowarySimpleDTO>();
    }
}

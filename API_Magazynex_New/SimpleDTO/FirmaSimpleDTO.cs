using API_Magazynex_New.Encje;

namespace API_Magazynex_New.SimpleDTO
{
    public class FirmaSimpleDTO
    {
        public FirmaSimpleDTO(Firma firma) 
        { 
            Id = firma.Id;
            Name = firma.Nazwa;
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

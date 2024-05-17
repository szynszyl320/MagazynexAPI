using API_Magazynex_New.Enums;

namespace API_Magazynex_New.CreateDTO
{
    public class MagazynCreateDTO
    {
        public string? lokalizacja { get; set; }
        public List<Mozliwosc_Pechowywania_Materialow> Przechowywane_Materialy { get; set; }

        public string? Nazwa { get; set; }
    }
}

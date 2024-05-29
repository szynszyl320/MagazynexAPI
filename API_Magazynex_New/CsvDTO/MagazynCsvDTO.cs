using API_Magazynex_New.Encje;
using API_Magazynex_New.Enums;

namespace API_Magazynex_New.CsvDTO
{
    public class MagazynCsvDTO
    {
        public MagazynCsvDTO(Magazyn magazyn) { 
            Id = magazyn.Id;
            Nazwa = magazyn.Nazwa;
            lokalizacja = magazyn.lokalizacja;
            Przechowywane_Materialy = magazyn.Przechowywane_Materialy;
            IsActive = magazyn.IsActive;
        }
        
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string lokalizacja { get; set; }
        public List<Mozliwosc_Pechowywania_Materialow> Przechowywane_Materialy { get; set; }
        public bool IsActive { get; set; }
    }
}

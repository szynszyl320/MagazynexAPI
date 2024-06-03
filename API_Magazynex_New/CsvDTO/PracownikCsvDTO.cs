using API_Magazynex_New.Encje;

namespace API_Magazynex_New.CsvDTO
{
    public class PracownikCsvDTO
    {
        public PracownikCsvDTO(Pracownik pracownik) { 
            Id = pracownik.Id;
            Imie = pracownik.Imie;
            Nazwisko = pracownik.Nazwisko;
            Stanowisko = pracownik.Stanowisko;
            Numer_Telefonu = pracownik.Numer_Telefonu;
            MagazynId = pracownik.MagazynId;
            AproxAge = pracownik.AproxAge;
            AproxNat = pracownik.AproxNat;
        }
        
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string Numer_Telefonu { get; set; }
        public int? MagazynId { get; set; }
        public int? AproxAge { get; set; }
        public string? AproxNat { get; set; }
    }
}

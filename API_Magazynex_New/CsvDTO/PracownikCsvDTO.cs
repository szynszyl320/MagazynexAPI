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
            NumerTelefonu = pracownik.Numer_Telefonu;
            MagazynId = pracownik.MagazynId;
        }
        
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string NumerTelefonu { get; set; }
        public int? MagazynId { get; set; }
    }
}

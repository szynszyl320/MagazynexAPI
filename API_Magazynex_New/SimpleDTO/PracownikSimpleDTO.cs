using API_Magazynex_New.Encje;

namespace API_Magazynex_New.SimpleDTO
{
    public class PracownikSimpleDTO
    {
        public PracownikSimpleDTO(Pracownik pracownik)
        {
            Id = pracownik.Id;
            Imie = pracownik.Imie;
            Nazwisko = pracownik.Nazwisko;
            MagazynId = pracownik.MagazynId;
        }

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko {get; set; }
        public int? MagazynId { get; set; }
    }
}

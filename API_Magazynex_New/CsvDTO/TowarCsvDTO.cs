using API_Magazynex_New.Encje;
using API_Magazynex_New.Enums;

namespace API_Magazynex_New.CsvDTO
{
    public class TowarCsvDTO
    {
        public TowarCsvDTO(Towar towar) {
            Id = towar.id;
            Nazwa_Produktu = towar.Nazwa_Produktu;
            Opis_Produktu = towar.Opis_Produktu;
            Ilosc = towar.Ilosc;
            Cena_Netto_Za_Sztuke = towar.Cena_Netto_Za_Sztuke;
            Klasa_Towaru = towar.Klasa_Towaru;
            FirmaId = towar.FirmaId;
            MagazynId = towar.MagazynId;
        }
        public int Id { get; set; }
        public string Nazwa_Produktu { get; set; }
        public string Opis_Produktu { get; set; }
        public int? Ilosc { get; set; }
        public float? Cena_Netto_Za_Sztuke { get; set; }
        public Mozliwosc_Pechowywania_Materialow Klasa_Towaru { get; set; }
        public int? FirmaId { get; set; }
        public int? MagazynId { get; set; }
    }
}

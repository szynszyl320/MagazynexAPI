using API_Magazynex_New.Encje;
using API_Magazynex_New.Enums;

namespace API_Magazynex_New.CsvDTO
{
    public class TowarCsvDTO
    {
        public TowarCsvDTO(Towar towar) {
            Id = towar.id;
            NazwaProduktu = towar.Nazwa_Produktu;
            OpisProduktu = towar.Opis_Produktu;
            IloscProduktu = towar.Ilosc;
            CenaNettoZaSztuke = towar.Cena_Netto_Za_Sztuke;
            KlasaTowaru = towar.Klasa_Towaru;
            FirmaId = towar.FirmaId;
            MagazynId = towar.MagazynId;
        }
        public int Id { get; set; }
        public string NazwaProduktu { get; set; }
        public string OpisProduktu { get; set; }
        public int? IloscProduktu { get; set; }
        public float? CenaNettoZaSztuke { get; set; }
        public Mozliwosc_Pechowywania_Materialow KlasaTowaru { get; set; }
        public int? FirmaId { get; set; }
        public int? MagazynId { get; set; }
    }
}

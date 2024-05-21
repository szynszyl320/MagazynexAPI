using API_Magazynex_New.Enums;

namespace API_Magazynex_New.CreateDTO
{
    public class TowarCreateDTO
    {
        public string Nazwa_Produktu { get; set; }
        public int Id_Firmy { get; set; }
        public int Id_Magazynu { get; set; }
        public string? Opis_Produktu { get; set; }
        public Mozliwosc_Pechowywania_Materialow Klasa_Towaru { get; set; }
        public float? Cena_Netto_Za_Sztuke { get; set; }
        public int? Ilosc { get; set; }
    }
}

namespace API_Magazynex_New
{
    public class TowarCreateDTO
    {
        public string Nazwa_Produktu { get; set; }
        public int FirmaId { get; set; }
        public string? Opis_Produktu { get; set; }
        public string? Klasa_Towarow_Niebezpiecznych { get; set; }
        public float? Cena_Netto_Za_Sztuke { get; set; }
        public int? Ilosc { get; set; }
    }
}

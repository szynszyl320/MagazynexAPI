namespace API_Magazynex_New.CreateDTO
{
    public class PracownikCreateDTO
    {
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Stanowisko { get; set; }
        public string Numer_Telefonu { get; set; }
        public int Id_Magazynu { get; set; }
    }
}

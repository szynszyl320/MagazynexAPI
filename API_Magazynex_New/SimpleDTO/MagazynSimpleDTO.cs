using API_Magazynex_New.Encje;

namespace API_Magazynex_New.SimpleDTO
{
    public class MagazynSimpleDTO
    {
        public MagazynSimpleDTO(Magazyn magazyn)
        {
            Id = magazyn.Id;
            Nazwa = magazyn.Nazwa;
        }

        public int Id { get; set; }
        public string? Nazwa { get; set; }
    }
}

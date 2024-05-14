using Magazynex_console;

namespace API_Magazynex_New
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

using API_Magazynex_New.Encje;

namespace API_Magazynex_New.SimpleDTO
{
    public class MagazynSimpleDTO
    {
        public MagazynSimpleDTO(Magazyn magazyn)
        {
            Id = magazyn.Id;
            Nazwa = magazyn.Nazwa;
            foreach (var towar in magazyn.Towary)
            {
                Towaries.Add(new TowarySimpleDTO(towar));
            }
            foreach (var pracownik in magazyn.Pracownicy)
            {
                Pracowniks.Add(new PracownikSimpleDTO(pracownik));
            }
        }

        public int Id { get; set; }
        public string? Nazwa { get; set; }
        public List<TowarySimpleDTO> Towaries { get; set; } = new List<TowarySimpleDTO>();
        public List<PracownikSimpleDTO> Pracowniks { get; set; } = new List<PracownikSimpleDTO>();
    }
}

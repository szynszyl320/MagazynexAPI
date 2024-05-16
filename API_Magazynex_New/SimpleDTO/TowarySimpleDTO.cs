using API_Magazynex_New.Encje;

namespace API_Magazynex_New.SimpleDTO
{
    public class TowarySimpleDTO
    {
        public TowarySimpleDTO(Towar towar)
        {
            id = towar.id;
            name = towar.Nazwa_Produktu;
            IdFirmy = towar.FirmaId;
            IdMagazynu = towar.MagazynId;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int? IdMagazynu { get; set; }
        public int? IdFirmy { get; set; }
    }
}

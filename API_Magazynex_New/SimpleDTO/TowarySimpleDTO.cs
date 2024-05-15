using API_Magazynex_New.Encje;

namespace API_Magazynex_New.SimpleDTO
{
    public class TowarySimpleDTO
    {
        public TowarySimpleDTO(Towar towar)
        {
            id = towar.id;
            name = towar.Nazwa_Produktu;
        }

        public int id { get; set; }
        public string name { get; set; }
    }
}

using Magazynex_console;

namespace API_Magazynex_New
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

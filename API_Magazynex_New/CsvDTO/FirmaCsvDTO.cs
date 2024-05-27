using API_Magazynex_New.Encje;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace API_Magazynex_New.CsvDTO
{
    public class FirmaCsvDTO
    {
        public FirmaCsvDTO(Firma firma) { 
            Id = firma.Id;
            Nazwa = firma.Nazwa;
            NumerTelefonu = firma.Numer_Telefonu;
        }

        [Name("id")] 
        public int Id { get; set; }
        [Name("nazwa")]
        public string Nazwa { get; set; }
        [Name("numer")]
        public string NumerTelefonu { get; set; }
    }
}

using API_Magazynex_New.CsvDTO;
using API_Magazynex_New.Encje;
using CsvHelper;
using CsvHelper.Configuration;
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

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string NumerTelefonu { get; set; }
    }
}



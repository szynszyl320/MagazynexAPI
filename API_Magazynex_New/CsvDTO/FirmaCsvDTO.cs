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
            Numer_Telefonu = firma.Numer_Telefonu;
            IsActive = firma.IsActive;
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Numer_Telefonu { get; set; }
        public bool IsActive { get; set; }
    }
}



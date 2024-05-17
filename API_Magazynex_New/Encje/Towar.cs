using API_Magazynex_New.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace API_Magazynex_New.Encje
{
    public class Towar
    {
        public int? FirmaId { get; set; }
        public Firma? Firma { get; set; }
        public int? MagazynId { get; set; }
        public Magazyn? Magazyn { get; set; }
        public int id { get; set; }
        public string? Opis_Produktu { get; set; }
        public List<Mozliwosc_Pechowywania_Materialow> Klasa_Towaru { get; set; }
        public float? Cena_Netto_Za_Sztuke { get; set; }
        public int? Ilosc { get; set; }
        public string? Nazwa_Produktu { get; set; }
    }
}

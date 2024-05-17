using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Magazynex_New.Enums;

namespace API_Magazynex_New.Encje
{
    public class Magazyn
    {
        public Magazyn()
        {
            Pracownicy = new List<Pracownik>();
            Towary = new List<Towar>();
            Przechowywane_Materialy = new List<Mozliwosc_Pechowywania_Materialow>();
            IsActive = true;
        }

        public int Id { get; set; }
        public List<Pracownik> Pracownicy { get; set; }
        public List<Towar> Towary { get; set; }
        public string? lokalizacja { get; set; }
        public List<Mozliwosc_Pechowywania_Materialow> Przechowywane_Materialy { get; set;}
        public string? Nazwa { get; set; }
        public bool IsActive { get; set; }
    }

}


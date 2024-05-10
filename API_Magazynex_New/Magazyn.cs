using Magazynex_console;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazynex_console
{
    public class Magazyn
    {
        public Magazyn()
        {
            Pracownicy = new List<Pracownik>();

        }

        public int Id { get; set; }
        public  List<Pracownik> Pracownicy { get; set; }
        public string? lokalizacja { get; set; }
        public int? Mozliwosc_Pechowywania_Materialow { get; set; }

        public string? Nazwa { get; set; }

        public void Assing_Lokalizacja(string Localization)
        {
            lokalizacja = Localization;
        }

        public bool Assing_Name(string Name)
        {
            if (Name.Length < 1)
            {
                return false;
            }
            else
            {
                Nazwa = Name;
                return true;
            }
        }
    }

}


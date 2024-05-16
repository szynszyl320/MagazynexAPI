using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Magazynex_New.Encje
{
    public class Magazyn
    {
        public Magazyn()
        {
            Pracownicy = new List<Pracownik>();
            Towary = new List<Towar>();
            IsActive = true;
        }

        public int Id { get; set; }
        public List<Pracownik> Pracownicy { get; set; }
        public List<Towar> Towary { get; set; }
        public string? lokalizacja { get; set; }
        public enum Mozliwosc_Pechowywania_Materialow
        {
            Safe_Materials,
            Explosive_Materials,
            Gaseous_Materials,
            Liquid_Flammable_Materials,
            Prone_Self_Combusting_Materials,
            Oxidizing_Materials,
            Toxic_Materials,
            Radioactive_Materials,
            Corrosive_Materials,
            Doesnt_Fit_In_Another_Category
        }
        public string? Nazwa { get; set; }
        public bool IsActive { get; set; }

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


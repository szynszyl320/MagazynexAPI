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
        public string? Klasa_Towarow_Niebezpiecznych { get; set; }
        public float? Cena_Netto_Za_Sztuke { get; set; }
        public int? Ilosc { get; set; }
        public string? Nazwa_Produktu { get; set; }

        public void Assing_Desc(string Description)
        {
            Opis_Produktu = Description;
        }

        public void Assing_Class(string Klasa)
        {
            Klasa_Towarow_Niebezpiecznych = Klasa;
        }

        public void Assing_Price(string Price)
        {
            Cena_Netto_Za_Sztuke = float.Parse(Price);
        }

        public bool Assing_Amount(string Amound)
        {
            int Amount = int.Parse(Amound);
            if (Amount < 1)
            {
                return false;
            }
            else
            {
                Ilosc = Amount;
                return true;
            }
        }

        public bool Assing_Name(string Name)
        {
            if (Name.Length < 1)
            {
                return false;
            }
            else
            {
                Nazwa_Produktu = Name;
                return true;
            }
        }
        public bool Danger_Class(int Class)
        {
            if (Class < int.Parse(Klasa_Towarow_Niebezpiecznych))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

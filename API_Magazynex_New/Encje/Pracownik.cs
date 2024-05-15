using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Magazynex_New.Encje
{
    public class Pracownik
    {
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Stanowisko { get; set; }
        public int Id { get; set; }
        public int Numer_Telefonu { get; set; }
        public Magazyn? Magazyn { get; set; }

        public bool Assign_Name(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }
            else
            {
                Imie = name;
                return true;
            }

        }

        public bool Assign_Surname(string Surname)
        {

            if (Surname.Length < 2)
            {
                return false;
            }
            else
            {
                Nazwisko = Surname;
                return true;
            }
        }

        public void Assign_Position(string stanowisko)
        {
            Stanowisko = stanowisko;
        }

        public void Assign_Numer_telefonu(string numer_telefonu)
        {
            numer_telefonu.Replace(" ", "");
            Numer_Telefonu = Convert.ToInt32(numer_telefonu);
        }




    }
}

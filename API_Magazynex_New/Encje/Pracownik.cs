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
        public string Numer_Telefonu { get; set; }
        public Magazyn? Magazyn { get; set; }
        public int? MagazynId { get; set; }  
       
        /*public void Assign_Numer_telefonu(string numer_telefonu)
        {
            numer_telefonu.Replace(" ", "");
            Numer_Telefonu = Convert.ToInt32(numer_telefonu);
        }*/




    }
}

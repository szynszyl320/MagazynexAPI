using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Magazynex_New.Encje
{
    public class Firma
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Numer_Telefonu { get; set; }

        public void Assing_Phone_Number(string numer_telefonu)
        {
            numer_telefonu.Replace(" ", "");
            Numer_Telefonu = numer_telefonu;
        }


    }
}


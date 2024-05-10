using Magazynex_console;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazynex_console
{
    public class Firma
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }
        public string? Numer_Telefonu { get; set; }

        public bool Assign_Name(string name)
        {
            if (name.Length < 2)
            { 
                return false;
            }
            else
            {
                Nazwa = name;
                return true;
            }
        }

        public void Assing_Phone_Number(string numer_telefonu)
        {
            numer_telefonu.Replace(" ", "");
            Numer_Telefonu = numer_telefonu;
        }


    }
}


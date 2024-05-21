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
        public Firma()
        { 
            IsActive = true;
        }
        
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Numer_Telefonu { get; set; }
        public List<Towar> Towars { get; set; } = new List<Towar>();
        public bool IsActive { get; set; } 
    }
}


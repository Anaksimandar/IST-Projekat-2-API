using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST_Projekat_2_API.Models
{
    public class StavkeFakture
    {
        public int idStavke { get; set; }
        public string naziv { get; set; }
        public int cena { get; set; }
        public int kolicina { get; set; }
        public string jedinicaMere { get; set; }
    }
}

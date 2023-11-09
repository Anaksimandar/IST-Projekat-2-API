using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST_Projekat_2_API.Models
{
    public class Preduzece
    {
        public int pib { get; set; }
        public string nazivPreduzeca { get; set; }
        public OdgovornoLice odgovornoLice { get; set; }
        public Adresa adresa { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
    }
}

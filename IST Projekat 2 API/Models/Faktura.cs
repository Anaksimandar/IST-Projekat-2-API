using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace IST_Projekat_2_API.Models
{
    public class Faktura
    {
        public int idFakture { get; set; }
        public int pibPreduzeceKupuje { get; set; }
        public int pibPreduzeceProdaje { get; set; }
        public DateTime datumGenerisanja { get; set; }
        public DateTime datumValute { get; set; }
        public List<StavkeFakture> stavkeFakture { get; set; }
        public int ukupno { get; set; }
        public string tipFakture { get; set; }

        public double ukupnoZaPlacanje()
        {
            double suma = 0;

            foreach(StavkeFakture s in stavkeFakture)
            {
                suma += s.cena * s.kolicina;
            }
            return suma;
        }

        public static int generisiIdFakture(List<Faktura> listaFaktura)
        {
            int id = 1;
            if(listaFaktura.Count == 0)
            {
                return id;
            }
            id = listaFaktura.ElementAt(listaFaktura.Count - 1).idFakture;

            return id;
            
        }

        public static bool istiPibUlazIzlaz(int pibUlaz, int pibIzlaz)
        {
            bool istiPib = pibIzlaz == pibUlaz ? true : false;
            return istiPib;
        }

        public static bool pripadaOpseguDatuma(DateTime datumOd, DateTime datumDo, DateTime provera)
        {
            if (provera > datumOd && provera < datumDo)
            {
                return true;
            }
            return false;
        }

    }
}

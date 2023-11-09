using IST_Projekat_2_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IST_Projekat_2_API.Controllers
{
    [ApiController]
    [Route("preduzece")]
    public class PreduzeceKontroler : Controller
    {
        public static List<Preduzece> listaPreduzeca = new List<Preduzece>(){
            new Preduzece {
                pib = 123456789,
                nazivPreduzeca = "Nelt", adresa = new Adresa { broj = 22, ulica = "Milutina Milankovica" },
                odgovornoLice = new OdgovornoLice { ime = "Ivan", prezime = "Milosevic" },
                email = "office@nelt.rs",
                telefon = "0632234433" }
            ,
            new Preduzece {
                pib = 123456788,
                nazivPreduzeca = "FIS", adresa = new Adresa { broj = 150, ulica = "Milutina Milankovica" },
                odgovornoLice = new OdgovornoLice { ime = "Milos", prezime = "Ivanovic" },
                email = "office@fis.rs",
                telefon = "0632234433" }
            ,
            new Preduzece {
                pib = 123456787,
                nazivPreduzeca = "Grid Dynamics", adresa = new Adresa { broj = 54, ulica = "Bulevar kralja Aleksandra" },
                odgovornoLice = new OdgovornoLice { ime = "Jovan", prezime = "Aleksic" },
                email = "office@griddynamics.rs",
                telefon = "0632234433" }
        };

        public static bool proveraPib(int pib)
        {
            bool postoji = false;
            listaPreduzeca.ForEach(p =>
            {
                if (p.pib == pib)
                {
                    postoji = true;
                }

            });

            if(!postoji)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public IActionResult vratiSvaPreduzeca()
        {
            var sortiranaPreduzeca = listaPreduzeca
                .OrderBy(p => p.pib)
                .ThenBy(p => p.nazivPreduzeca)
                .Select(p => p)
                .ToList();

            return Ok(sortiranaPreduzeca);
        }
        //http://localhost:5050/preduzece/pib
        [HttpDelete("{pib}")]
        public IActionResult obrisiPreduzece(int pib)
        {
            bool provera = false;
            for (int i = 0; i <= listaPreduzeca.Count; i++)
            {
                if (listaPreduzeca[i].pib == pib)
                {
                    listaPreduzeca.RemoveAt(i);
                    provera = true;
                    break;
                }
            }

            // potrebno je obrisati i fakture povezane sa preduzecem koje zelimo da obrisemo jer preduzece moze da postoji bez fakture ali faktura bez preduzeca ne moze
            if (provera)
            {
                FakturaKontroler.obrisiFakturePreduzeca(pib);
                return Ok("Preduzece je uspesno obrisano");
            }
            return BadRequest("Neuspesno brisanje, preduzece ne postoji");
        }

        //http://localhost:5050/preduzece/dodaj
        [HttpPost("dodaj")]
        public IActionResult dodajPreduzece([FromBody]Preduzece p)
        {
            if (p.pib.ToString().Length != 9)
            {
                return BadRequest("PIB mora da sadrzi 9 cifara");
            }
            if (!PreduzeceKontroler.proveraPib(p.pib))
            {
                return BadRequest("Preduzece sa unetim PIB vec postoji, izaberite drugi.");
            }
            
            listaPreduzeca.Add(p);
            return Ok(listaPreduzeca);

        }

        [HttpGet("filtriraj/{unos}")]
        public IActionResult filtrirajPreduzeca(string unos)
        {
            List<Preduzece> filtriranaPreduzeca = new List<Preduzece>();
            listaPreduzeca.ForEach(preduzece =>
            {
                if (preduzece.nazivPreduzeca.ToLower().Contains(unos.ToLower()) || preduzece.pib.ToString().Contains(unos))
                {
                    filtriranaPreduzeca.Add(preduzece);
                }

            });

            return Ok(filtriranaPreduzeca);
        }

        [HttpGet("{pib}")]
        public IActionResult vratiPreduzecePoId(string pib)
        {
            Preduzece pronadjenoPreduzece = null;

            for (var i = 0; i < listaPreduzeca.Count; i++)
            {
                if (listaPreduzeca.ElementAt(i).pib.ToString() == pib)
                {
                    pronadjenoPreduzece = listaPreduzeca.ElementAt(i);
                    break;
                }
            }

            if (pronadjenoPreduzece != null)
            {
                return Ok(pronadjenoPreduzece);
            }
            return NotFound("Preduzece nije pronadjeno");
        }

        [HttpPut("izmeni/{pib}")]
        public IActionResult izmeniPreduzece(string pib, [FromBody] Preduzece p)
        {
            Preduzece pronadjenoPreduzece = null;

            for(var i = 0; i < listaPreduzeca.Count; i++)
            {
                if(listaPreduzeca.ElementAt(i).pib.ToString() == pib)
                {
                    listaPreduzeca.ElementAt(i).nazivPreduzeca = p.nazivPreduzeca;
                    listaPreduzeca.ElementAt(i).odgovornoLice.ime = p.odgovornoLice.ime;
                    listaPreduzeca.ElementAt(i).odgovornoLice.prezime = p.odgovornoLice.prezime;
                    listaPreduzeca.ElementAt(i).telefon = p.telefon;
                    listaPreduzeca.ElementAt(i).email = p.email;
                    listaPreduzeca.ElementAt(i).adresa.broj = p.adresa.broj;
                    listaPreduzeca.ElementAt(i).adresa.ulica = p.adresa.ulica;
                    pronadjenoPreduzece = listaPreduzeca.ElementAt(i);
                    break;
                }
            }

            if (pronadjenoPreduzece != null)
            {
                return Ok("Preduzece je uspesno izmenjeno");
            }
            return NotFound("Preduzece nije pronadjeno");
            
        }

    }
    
}

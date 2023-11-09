using IST_Projekat_2_API.Models;
using IST_Projekat_2_API.Models.HelpClass;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST_Projekat_2_API.Controllers
{
    [ApiController]
    [Route("faktura")]

    public class FakturaKontroler : Controller
    {
        static List<Faktura> listaFaktura = new List<Faktura>()
        {
            new Faktura{
                idFakture=111111111
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=20,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-10-12"),
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje =  123456789,
                pibPreduzeceProdaje = 123456788, // kreira fakturu
                tipFakture = "ulazna",
                ukupno = 283000
            },
            new Faktura{
                idFakture=111111112
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=20,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "izlazna",
                ukupno = 283000
            },
            new Faktura{
                idFakture=111111113
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111114
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111115
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111116
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111117
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111118
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111119
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=20,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-10-12"),
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje =  123456789,
                pibPreduzeceProdaje = 123456788, // kreira fakturu
                tipFakture = "ulazna",
                ukupno = 283000
            },
            new Faktura{
                idFakture=111111110
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=20,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "izlazna",
                ukupno = 283000
            },
            new Faktura{
                idFakture=111111190
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111191
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111192
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111193
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111194
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            },
            new Faktura{
                idFakture=111111195
                ,stavkeFakture = new List<StavkeFakture>{
                    new StavkeFakture {idStavke=1, naziv="stavka1",kolicina=10,cena=500,jedinicaMere="kg"},
                    new StavkeFakture {idStavke=2, naziv="stavka2",kolicina=50,cena=1000,jedinicaMere="komad"},
                    new StavkeFakture {idStavke=3, naziv="stavka3",kolicina=223,cena=100,jedinicaMere="komad"}
                },
                datumGenerisanja =  DateTime.Parse("2023-08-15"), // yy mm dd
                datumValute = DateTime.Parse("2024-01-20"),
                pibPreduzeceKupuje = 123456789,
                pibPreduzeceProdaje = 123456788,
                tipFakture = "ulazna",
                ukupno = 278000
            }
        };

        public static void obrisiFakturePreduzeca(int pib)
        {
            for(int i = 0; i < listaFaktura.Count; i++)
            {
                if(listaFaktura[i].pibPreduzeceKupuje == pib)
                {
                    listaFaktura.RemoveAt(i);
                }
            }
            
        }

        [HttpGet]
        public IActionResult vratiFakture()
        {
            return Ok(listaFaktura);
        }
        //http://localhost:5050/faktura/stavke/"+idFakture
        [HttpGet("stavke/{id}")]
        public IActionResult vratiStavkeFakture(int id)
        {
            Faktura fakturaPostoji = null;
            listaFaktura.ForEach(f =>
            {
                if(f.idFakture == id)
                {
                    fakturaPostoji = f;
                }
            });
            if (fakturaPostoji != null)
            {
                return Ok(fakturaPostoji.stavkeFakture);
            }
            return BadRequest("Ne postoji faktura sa unetim id-em");
        }
        //http://localhost:5050/faktura/+idFakture
        [HttpDelete("{id}")]
        public IActionResult obrisiFakturu(int id)
        {
            bool provera = false;
            for (int i = 0; i < listaFaktura.Count; i++)
            {
                if (listaFaktura[i].idFakture == id)
                {
                    listaFaktura.RemoveAt(i);
                    provera = true;
                    break;
                }
            }
            if (provera)
            {
                return Ok(listaFaktura);
            }
            return BadRequest("Neuspesno brisanje, faktura ne postoji");
        }
        // http:localhost5005/faktura/id
        [HttpGet("preduzece/{id}")]
        public IActionResult vratiFakturu(int id)
        {
            List<Faktura> faktura = new List<Faktura>();
            for (int i = 0; i < listaFaktura.Count; i++)
            {
                if (listaFaktura[i].pibPreduzeceProdaje == id)
                {
                    faktura.Add(listaFaktura[i]);
                }
            }
            if (faktura.Count > 0)
            {
                return Ok(faktura);
            }
            return BadRequest("Faktura ne postoji");
        }

        [HttpPost("dodaj")]
        public IActionResult dodajFakturu([FromBody] Faktura f)
        {
            int id = Faktura.generisiIdFakture(listaFaktura);
            bool isti = !Faktura.istiPibUlazIzlaz(f.pibPreduzeceKupuje, f.pibPreduzeceProdaje);
            bool ispravanPIBFakture = isti ? true : false; // ispravan pib (ulazne / izlazne) fakture mora da postoji i ne sme da bude isti

            if (ispravanPIBFakture)
            {
                listaFaktura.Add(f);
                return Ok("Faktura je uspesno dodata");
            }
            return NotFound("Uneti PIB fakture mora da postoji i preduzece ne moze da imas istu ulaznu/izlaznu fakturu");
        }

        [HttpGet("filtriraj/{unos}")]
        public IActionResult filtrirajPreduzeca(string unos)
        {
            bool dodataFaktura = false;
            List<Faktura> filtriranjeFaktura = new List<Faktura>();
            listaFaktura.ForEach(faktura =>
            {
                faktura.stavkeFakture.ForEach(stavka =>
                {
                    if (stavka.naziv.ToLower().Contains(unos.ToLower()) && !dodataFaktura)
                    {
                        filtriranjeFaktura.Add(faktura);
                        dodataFaktura = true;
                        
                    }
                });
                dodataFaktura = false;

            });

            return Ok(filtriranjeFaktura);
        }

        [HttpGet("{idFakture}")]
        public IActionResult vratiFakturuPoId(string idFakture)
        {
            Faktura pronadjenaFaktura = null;

            for (var i = 0; i < listaFaktura.Count; i++)
            {
                if (listaFaktura.ElementAt(i).idFakture.ToString() == idFakture)
                {
                    pronadjenaFaktura = listaFaktura.ElementAt(i);
                    break;
                }
            }

            if (pronadjenaFaktura != null)
            {
                return Ok(pronadjenaFaktura);
            }
            return NotFound("Faktura nije pronadjena");
        }

        [HttpPut("izmeni/{idFakture}")]
        public IActionResult izmeniPreduzece(string idFakture, [FromBody] Faktura f)
        {
            Faktura pronadjenaFaktura = null;

            for (var i = 0; i < listaFaktura.Count; i++)
            {
                if (listaFaktura.ElementAt(i).idFakture.ToString() == idFakture)
                {
                    listaFaktura.ElementAt(i).pibPreduzeceKupuje = f.pibPreduzeceKupuje;
                    listaFaktura.ElementAt(i).pibPreduzeceProdaje = f.pibPreduzeceProdaje;
                    listaFaktura.ElementAt(i).datumGenerisanja = f.datumGenerisanja;
                    listaFaktura.ElementAt(i).datumValute = f.datumValute;
                    listaFaktura.ElementAt(i).tipFakture = f.tipFakture;
                    listaFaktura.ElementAt(i).ukupno = f.ukupno;
                    listaFaktura.ElementAt(i).stavkeFakture.Clear();

                    for (var j = 0; j < f.stavkeFakture.Count; j++)
                    {
                        listaFaktura.ElementAt(i).stavkeFakture.Add(f.stavkeFakture.ElementAt(j));
                    }

                    pronadjenaFaktura = listaFaktura.ElementAt(i);
                    break;
                }
            }

            if (pronadjenaFaktura != null)
            {
                return Ok(listaFaktura);
            }
            return NotFound("Faktura nije pronadjena");

        }
        //http://localhost:5050/faktura/bilans/pib/datum_od/datum_do

        [HttpGet("bilans/{pib}/{datumOd}/{datumDo}")]
        public IActionResult vratiBilans(int pib, DateTime datumOd, DateTime datumDo)
        {
            bool postojeFaktureZaPreduzece = false;
            bool postojeFaktureUOpsegu = false;
            int ukupno = 0;

            listaFaktura.ForEach(f =>
            {
                if (f.pibPreduzeceProdaje == pib || f.pibPreduzeceKupuje == pib) // bilans je zbir svih ulaznih i izlaznih faktura preduzeca (kupovina i prodaje)
                {
                    postojeFaktureZaPreduzece = true;
                    if (Faktura.pripadaOpseguDatuma(datumOd, datumDo, f.datumGenerisanja))
                    {
                        postojeFaktureUOpsegu = true;

                        if (f.tipFakture == "ulazna")
                        {
                            ukupno -= f.ukupno;
                        }
                        else
                        {
                            ukupno += f.ukupno;
                        }
                    }
                }
            });

            if (!postojeFaktureZaPreduzece)
            {
                return NotFound("Preduzece sa unetim PIB-om nema fakture");
            }

            if (!postojeFaktureUOpsegu)
            {
                return NotFound("Ne postoje fakture koje pripadaju unetom opsegu");
            }

            return Ok(ukupno);
        }

        // paganizacija
        //http://localhost:5050/faktura/preduzece/?strane=${this.brojStrane}&limit=5

        [HttpGet("preduzece/{id}/stranica")]
        public IActionResult vratiStranice(int id, [FromQuery] int strane, [FromQuery] int limit)
        {

            // zelimo da vratimo objekat koji ce sadrzati podatke o : trazenim elementima (u zavisnosti od strane koju klijent trazi - stranicenje) i svim elementima tj. rezultatima pretrage (bez stranicenja)

            // resultMicrosoft.AspNetCore.Mvc.OkObjectResult

            ResponseObject responseObject = new ResponseObject { totalSizeOfList = 0, requestedElements = null };
            
            List<Faktura> fakture = new List<Faktura>(); // sve fakture zeljenog preduzeca
            int pocinjeOd = (strane - 1) * limit;
            
            //filtriranje zeljenih faktura
            for (int i = 0; i < listaFaktura.Count; i++)
            {
                if (listaFaktura[i].pibPreduzeceProdaje == id)
                {
                    fakture.Add(listaFaktura[i]);
                }
            }

            int prikaz = fakture.Count - (strane - 1) * limit;

            if (prikaz >= 5)
            {
                prikaz = 5;
            }
            else
            {
                prikaz = prikaz % 5;
            }

            if (fakture.Count > 0)
            {
                responseObject.requestedElements = fakture.GetRange(pocinjeOd,prikaz);
                responseObject.totalSizeOfList = fakture.Count;
                return Ok(responseObject);
            }
            return BadRequest("Faktura ne postoji");
        }



    }
}

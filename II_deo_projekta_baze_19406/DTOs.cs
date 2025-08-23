using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406
{
    public class DTOs
    {
        #region Stanica
        public class StanicaBasic
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public double? PovrsinaObjekta { get; set; }
            public string Adresa { get; set; }
            public string DostupnaInfrastruktura { get; set; }
            public int BrojZaposlenih { get; set; }
            public int BrojVozila { get; set; }
            public string UpravnikPrikaz { get; set; }

            public IList<AngazovanoLicePregled> AngazovanaLica { get; set; }
            public IList<VoziloPregled> Vozila { get; set; }

            public StanicaBasic()
            {
                AngazovanaLica = new List<AngazovanoLicePregled>();
                Vozila = new List<VoziloPregled>();
            }

            public StanicaBasic(int id, string naziv, double? povrsina, string adresa, string infrastruktura, int brZaposlenih, int brojVozila)
            {
                this.ID = id;
                this.Naziv = naziv;
                this.PovrsinaObjekta = povrsina;
                this.Adresa = adresa;
                this.DostupnaInfrastruktura = infrastruktura;
                this.BrojZaposlenih = brZaposlenih;
                this.BrojVozila = brojVozila;
                this.AngazovanaLica = new List<AngazovanoLicePregled>();
                this.Vozila = new List<VoziloPregled>();

            }
        }

        public class StanicaPregled
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public string Adresa { get; set; }
            public double? PovrsinaObjekta { get; set; }
            public string DostupnaInfrastruktura { get; set; }
            public int BrojZaposlenih { get; set; }
            public int BrojVozila { get; set; }
            public string UpravnikPrikaz { get; set; }

            public StanicaPregled() { }

            public StanicaPregled(int id, string naziv, string adresa, double? povrsina, string infrastruktura, int brojZaposlenih, int brojVozila)
            {
                this.ID = id;
                this.Naziv = naziv;
                this.Adresa = adresa;
                this.PovrsinaObjekta = povrsina;
                this.DostupnaInfrastruktura = infrastruktura;
                this.BrojZaposlenih = brojZaposlenih;
                this.BrojVozila = brojVozila;
            }
        }
        #endregion

        #region Smena
        public class SmenaBasic
        {
            public int Id { get; set; }
            public DateTime Datum { get; set; }
            public DateTime VremePocetka { get; set; }
            public DateTime VremeKraja { get; set; }
            public int IdStanice { get; set; } 

            public SmenaBasic() { }

            public SmenaBasic(int id, DateTime datum, DateTime vremePocetka, DateTime vremeKraja, int stanica)
            {
                this.Id = id;
                this.Datum = datum;
                this.VremePocetka = vremePocetka;
                this.VremeKraja = vremeKraja;
                this.IdStanice = stanica;
            }
        }
        public class SmenaPregled
        {
            public int Id { get; set; }
            public DateTime Datum { get; set; }
            public string NazivStanice { get; set; }
            public string VremeRada { get; set; }
            public string PrikazZaListu => $"{NazivStanice} ({Datum.ToShortDateString()} | {VremeRada})";

            public SmenaPregled() { }
            public SmenaPregled(int id, DateTime datum, DateTime vremePocetka, DateTime vremeKraja, string nazivStanice)
            {
                this.Id = id;
                this.Datum = datum;
                this.NazivStanice = nazivStanice;
                this.VremeRada = $"{vremePocetka:HH:mm} - {vremeKraja:HH:mm}";
            }
        }
        #endregion

        #region Upravnik
        public class UpravnikPregled
        {
            public int Id { get; set; }
            public string PunoIme { get; set; }
        }
        #endregion

        #region TehnicarPregled 
        public class TehnicarPregled
        {
            public int Id { get; set; }
            public string ImeIPrezime { get; set; }

            public TehnicarPregled(int id, string ime, string prezime)
            {
                Id = id;
                ImeIPrezime = $"{ime} {prezime}";
            }
        }
        #endregion

        #region ServisVozila
        public class ServisVozilaBasic
        {
            public int Id { get; set; }
            public string StatusServisa { get; set; }
            public DateTime DatumPocetka { get; set; }
            public DateTime? DatumKraja { get; set; }
            public int VoziloId { get; set; }

            public ServisVozilaBasic() { }

            public ServisVozilaBasic(int id, string status, DateTime pocetak, DateTime? kraj, int voziloId)
            {
                this.Id = id;
                this.StatusServisa = status;
                this.DatumPocetka = pocetak;
                this.DatumKraja = kraj;
                this.VoziloId = voziloId;
            }
        }

        public class ServisVozilaPregled
        {
            public int Id { get; set; }
            public string StatusServisa { get; set; }
            public DateTime DatumPocetka { get; set; }
            public string VoziloInfo { get; set; }

            public ServisVozilaPregled() { }

            public ServisVozilaPregled(int id, string status, DateTime pocetak, string voziloInfo)
            {
                this.Id = id;
                this.StatusServisa = status;
                this.DatumPocetka = pocetak;
                this.VoziloInfo = voziloInfo;
            }
        }
        #endregion

        #region Ponavljanje
        public class PonavljanjeBasic
        {
            public int Id { get; set; }
            public int BrojSmena { get; set; }
            public string Mesec { get; set; }
            public int IdDispecera { get; set; }

            public PonavljanjeBasic() { }

            public PonavljanjeBasic(int id, int brojSmena, string mesec, int idDispecera)
            {
                this.Id = id;
                this.BrojSmena = brojSmena;
                this.Mesec = mesec;
                this.IdDispecera = idDispecera;
            }
        }

        public class PonavljanjePregled
        {
            public int Id { get; set; }
            public string Mesec { get; set; }
            public int BrojSmena { get; set; }
            public string DispecerInfo { get; set; }

            public PonavljanjePregled() { }

            public PonavljanjePregled(int id, string mesec, int brojSmena, string dispecerInfo)
            {
                this.Id = id;
                this.Mesec = mesec;
                this.BrojSmena = brojSmena;
                this.DispecerInfo = dispecerInfo;
            }
        }
        #endregion

        #region AngazovanoLice
        public class AngazovanoLiceBasic
        {
            public int ID { get; set; }
            public string Maticni_broj { get; set; }
            public string Licno_ime { get; set; }
            public string Prezime { get; set; }
            public DateTime Datum_rodjenja { get; set; }
            public string Adresa_stanovanja { get; set; }
            public char Pol { get; set; }
            public string Email_adresa { get; set; }
            public DateTime? Datum_pocetka_angazovanja { get; set; }
            public char FVatrogasac { get; set; }
            public int? Broj_sertifikata { get; set; }
            public int? Broj_operativnih_intervencija { get; set; }
            public string Stepen_fizicke_spremnosti { get; set; }
            public string Nivo_obucenosti { get; set; }
            public char FDispecer { get; set; }
            public string Evidencija_poziva { get; set; }
            public string Tip_opreme { get; set; }
            public char FTehnicar { get; set; }
            public string Podaci_o_alatima { get; set; }
            public string Specijalizacija { get; set; }
            public int? StanicaID { get; set; }
            public StanicaBasic Stanica { get; set; }

            public AngazovanoLiceBasic() { }

            public AngazovanoLiceBasic(int id, string maticni, string ime, string prezime, DateTime datumRodj, string adresa, char pol, string email,
                DateTime datumAng, char fVatrogasac, int brSertifikata, int brIntervencija, string stepen, string nivoObucenosti, char fDispecer, string evidencijaPoziva,
                string tipOpreme, char fTehnicar, string podaciAlati, string specijalizacija, int? stanicaId = null)
            {
                this.ID = id;
                this.Maticni_broj = maticni;
                this.Licno_ime = ime;
                this.Prezime = prezime;
                this.Datum_rodjenja = datumRodj;
                this.Adresa_stanovanja = adresa;
                this.Pol = pol;
                this.Email_adresa = email;
                this.Datum_pocetka_angazovanja = datumAng;
                this.FVatrogasac = fVatrogasac;
                this.Broj_sertifikata = brSertifikata;
                this.Broj_operativnih_intervencija = brIntervencija;
                this.Stepen_fizicke_spremnosti = stepen;
                this.Nivo_obucenosti = nivoObucenosti;
                this.FDispecer = fDispecer;
                this.Evidencija_poziva = evidencijaPoziva;
                this.Tip_opreme = tipOpreme;
                this.FTehnicar = fTehnicar;
                this.Podaci_o_alatima = podaciAlati;
                this.Specijalizacija = specijalizacija;
                this.StanicaID = stanicaId;
            }
        }

        public class AngazovanoLicePregled
        {
            public int ID { get; set; }
            public string Licno_ime { get; set; }
            public string Prezime { get; set; }
            public string Email_adresa { get; set; }
            public char FVatrogasac { get; set; }
            public char FDispecer { get; set; }
            public char FTehnicar { get; set; }
            public string ImeIPrezime => $"{Licno_ime} {Prezime}";

            public AngazovanoLicePregled() { }

            public AngazovanoLicePregled(int id,string ime, string prezime, string email, char fVatrogasac, char fDispecer, char fTehnicar)
            {
                this.ID = id;
                this.Licno_ime = ime;
                this.Prezime = prezime;
                this.Email_adresa = email;
                this.FVatrogasac = fVatrogasac;
                this.FDispecer = fDispecer;
                this.FTehnicar = fTehnicar;
            }
        }

        public class AngazovanoLiceDetaljiPregled
        {
            public int ID { get; set; }
            public string MaticniBroj { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public char Pol { get; set; }
            public string Adresa { get; set; }
            public string Email { get; set; }
            public DateTime? DatumAngazovanja { get; set; }
            public string NazivStanice { get; set; }
            public char FVatrogasac { get; set; }
            public char FDispecer { get; set; }
            public string BrojSmenaMesecno { get; set; }
            public char FTehnicar { get; set; }
            public int? BrojSertifikata { get; set; }
            public int? BrojOperativnihIntervencija { get; set; }
            public string StepenFizickeSpremnosti { get; set; }
            public string NivoObucenosti { get; set; }
            public string EvidencijaPoziva { get; set; }
            public string TipOpreme { get; set; }
            public string Specijalizacija { get; set; }
            public string PodaciOAlatima { get; set; }
        }
        #endregion

        #region Volonter
        public class VolonterBasic
        {
            public int Id { get; set; }
            public string MaticniBroj { get; set; }
            public string LicnoIme { get; set; }
            public string Prezime { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string AdresaStanovanja { get; set; }
            public char Pol { get; set; }
            public string EmailAdresa { get; set; }
            public int? IdVozila { get; set; }
         
            public VolonterBasic() { }

            public VolonterBasic(int id, string maticni, string ime, string prezime, DateTime datumRodj, string adresa, char pol, string email, int? idVozila)
            {
                this.Id = id;
                this.MaticniBroj = maticni;
                this.LicnoIme = ime;
                this.Prezime = prezime;
                this.DatumRodjenja = datumRodj;
                this.AdresaStanovanja = adresa;
                this.Pol = pol;
                this.EmailAdresa = email;
                this.IdVozila = idVozila;
            }
        }
        public class VolonterDetaljiPregled
        {
            public int Id { get; set; }
            public string MaticniBroj { get; set; }
            public string LicnoIme { get; set; }
            public string Prezime { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public char Pol { get; set; }
            public string AdresaStanovanja { get; set; }
            public string EmailAdresa { get; set; }
            public string RegistarskaOznaka { get; set; } 
            public string ProizvodjacVozila { get; set; } 
            public string TipVozila { get; set; }        
        }
        public class VolonterPregled
        {
            public int Id { get; set; }
            public string LicnoIme { get; set; }
            public string Prezime { get; set; }
            public string EmailAdresa { get; set; }

            public VolonterPregled() { }

            public VolonterPregled(int id, string ime, string prezime, string email)
            {
                this.Id = id;
                this.LicnoIme = ime;
                this.Prezime = prezime;
                this.EmailAdresa = email;
            }
        }
        #endregion

        #region Vozilo
        public class VoziloBasic
        {
            public int Id { get; set; }
            public string RegistarskaOznaka { get; set; }
            public int? Kapacitet { get; set; }
            public string Proizvodjac { get; set; }
            public int? GodinaProizvodnje { get; set; }
            public DateTime? DatumPoslednjegPregleda { get; set; }
            public DateTime? DatumIstekaRegistracije { get; set; }
            public string StatusVozila { get; set; }
            public char? FVatrogasno { get; set; }
            public string TipVatrogasno { get; set; }
            public char? FSpasilacko { get; set; }
            public string TipSpasilacko { get; set; }
            public char? FTehnickaPodrska { get; set; }
            public string TipTehnickaPodrska { get; set; }
            public int? IdStanice { get; set; }

            public VoziloBasic() { }

            public VoziloBasic(int id, string registarskaOznaka, int kapacitet, string proizvodjac, int godinaProizvodnje, DateTime datumPoslednjegPregleda, DateTime datumIstekaRegistracije, string statusVozila, char fVatrogasno, string tipVatrogasno, char fSpasilacko, string tipSpasilacko, char fTehnickaPodrska, string tipTehnickaPodrska, int? idStanice)
            {
                Id = id;
                RegistarskaOznaka = registarskaOznaka;
                Kapacitet = kapacitet;
                Proizvodjac = proizvodjac;
                GodinaProizvodnje = godinaProizvodnje;
                DatumPoslednjegPregleda = datumPoslednjegPregleda;
                DatumIstekaRegistracije = datumIstekaRegistracije;
                StatusVozila = statusVozila;
                FVatrogasno = fVatrogasno;
                TipVatrogasno = tipVatrogasno;
                FSpasilacko = fSpasilacko;
                TipSpasilacko = tipSpasilacko;
                FTehnickaPodrska = fTehnickaPodrska;
                TipTehnickaPodrska = tipTehnickaPodrska;
                IdStanice = idStanice;
            }
        }

        public class VoziloPregled
        {
            public int Id { get; set; }
            public string RegistarskaOznaka { get; set; }
            public string Proizvodjac { get; set; }
            public string StatusVozila { get; set; }
            public string TipVozila { get; set; }

            public VoziloPregled() { }

            public VoziloPregled(int id, string reg, string proizvodjac, string status)
            {
                this.Id = id;
                this.RegistarskaOznaka = reg;
                this.Proizvodjac = proizvodjac;
                this.StatusVozila = status;
        }
        }
        #endregion

        #region Oprema
        public class OpremaBasic
        {
            public int Id { get; set; }
            public string InventarskiBroj { get; set; }
            public DateTime DatumNabavke { get; set; }
            public string StatusOpreme { get; set; }
            public char? FZastitna { get; set; }
            public string TipZastitna { get; set; }
            public char? FZaPozare { get; set; }
            public string TipZaPozare { get; set; }
            public char? FSpecijalna { get; set; }
            public string TipSpecijalna { get; set; }
            public char? FTehnicka { get; set; }
            public string TipTehnicka { get; set; }
            public int? IdVozila { get; set; }
            public int? IdStanice { get; set; }
            public int? IdLica { get; set; }
            public string ZaduzenoLicePrikaz { get; set; }


            public OpremaBasic() { }

            public OpremaBasic(int id, string inventarskiBroj, DateTime datumNabavke, string statusOpreme, char fZastitna, string tipZastitna, char fZaPozare, string tipZaPozare, char fSpecijalna, string tipSpecijalna, char fTehnicka, string tipTehnicka, int? idVozila, int? idStanice, int? idLica)
            {
                Id = id;
                InventarskiBroj = inventarskiBroj;
                DatumNabavke = datumNabavke;
                StatusOpreme = statusOpreme;
                FZastitna = fZastitna;
                TipZastitna = tipZastitna;
                FZaPozare = fZaPozare;
                TipZaPozare = tipZaPozare;
                FSpecijalna = fSpecijalna;
                TipSpecijalna = tipSpecijalna;
                FTehnicka = fTehnicka;
                TipTehnicka = tipTehnicka;
                IdVozila = idVozila;
                IdStanice = idStanice;
                IdLica = idLica;
            }
        }

        public class OpremaPregled
        {
            public int Id { get; set; }
            public string InventarskiBroj { get; set; }
            public string StatusOpreme { get; set; }
            public string Lokacija { get; set; }

            public OpremaPregled() { }

            public OpremaPregled(int id, string invBroj, string status, string lokacija)
            {
                this.Id = id;
                this.InventarskiBroj = invBroj;
                this.StatusOpreme = status;
                this.Lokacija = lokacija;
            }
        }
        #endregion

        #region Intervencija
        public class VatrogasacPregled
        {
            public int Id { get; set; }
            public string ImeIPrezime { get; set; }

            public VatrogasacPregled(int id, string ime, string prezime)
            {
                Id = id;
                ImeIPrezime = $"{ime} {prezime}";
            }
        }
        public class DispecerPregled
        {
            public int Id { get; set; }
            public string ImeIPrezime { get; set; }

            public DispecerPregled(int id, string ime, string prezime)
            {
                Id = id;
                ImeIPrezime = $"{ime} {prezime}";
            }
        }
        
        public class IntervencijaBasic
        {
            public int Id { get; set; }
            public int BrojIntervencije { get; set; }
            public string OpisSituacije { get; set; }
            public DateTime Datum { get; set; }
            public DateTime VremeOd { get; set; }
            public DateTime VremeDo { get; set; }
            public DateTime VremeDolaska { get; set; }
            public string TipIntervencije { get; set; }
            public string AdresaLokacije { get; set; }
            public int? IdDispecera { get; set; }
            public int IdStatusa { get; set; }
            public List<int> AngazovaniVatrogasciIds { get; set; }
            public List<int> KoriscenaVozilaIds { get; set; }

            public IntervencijaBasic()
            {
                AngazovaniVatrogasciIds = new List<int>();
                KoriscenaVozilaIds = new List<int>();
            }
        }

        public class IntervencijaPregled
        {
            public int Id { get; set; }
            public int BrojIntervencije { get; set; }
            public DateTime Datum { get; set; }
            public string TipIntervencije { get; set; }
            public string AdresaLokacije { get; set; }

            public IntervencijaPregled() { }

            public IntervencijaPregled(int id, int broj, DateTime datum, string tip, string adresa)
            {
                this.Id = id;
                this.BrojIntervencije = broj;
                this.Datum = datum;
                this.TipIntervencije = tip;
                this.AdresaLokacije = adresa;
            }
        }
        public class UpotrebaIntervencijePregled
        {
            public int IdIntervencije { get; set; }
            public string TipIntervencije { get; set; }
            public DateTime DatumIntervencije { get; set; }

            public UpotrebaIntervencijePregled() { }

            public UpotrebaIntervencijePregled(int id, string tip, DateTime datum)
            {
                this.IdIntervencije = id;
                this.TipIntervencije = tip;
                this.DatumIntervencije = datum;
            }
        }
        #endregion

        #region StatusIntervencije
        public class StatusIntervencijeBasic
        {
            public int Id { get; set; }
            public DateTime Vreme { get; set; }
            public DateTime Datum { get; set; }
            public string StanjeIntervencije { get; set; }

            public StatusIntervencijeBasic() { }

            public StatusIntervencijeBasic(int id, DateTime vreme, DateTime datum, string stanje)
            {
                this.Id = id;
                this.Vreme = vreme;
                this.Datum = datum;
                this.StanjeIntervencije = stanje;
            }
        }

        public class StatusIntervencijePregled
        {
            public int Id { get; set; }
            public string StanjeIntervencije { get; set; }
            public DateTime Datum { get; set; }

            public StatusIntervencijePregled() { }

            public StatusIntervencijePregled(int id, string stanje, DateTime datum)
            {
                this.Id = id;
                this.StanjeIntervencije = stanje;
                this.Datum = datum;
            }
        }
        #endregion

        #region AngazovanVatrogasac
        public class AngazovanVatrogasacBasic
        {
            public int ID { get; set; }
            public int BrojVatrogasaca { get; set; }
            public int IdIntervencije { get; set; }
            public int IdVatrogasca { get; set; }
            public int IdSmene { get; set; }

            public AngazovanVatrogasacBasic() { }
        }

        public class AngazovanVatrogasacPregled
        {
            public int ID { get; set; }
            public string IntervencijaInfo { get; set; }
            public string VatrogasacInfo { get; set; }

            public AngazovanVatrogasacPregled(int id, string intervencija, string vatrogasac)
            {
                this.ID = id;
                this.IntervencijaInfo = intervencija;
                this.VatrogasacInfo = vatrogasac;
            }
        }
        #endregion

        #region UpotrebljenoUIntervenciji
        public class UpotrebljenoUIntervencijiBasic
        {
            public int ID { get; set; }
            public int IdIntervencije { get; set; }
            public int? IdVozila { get; set; }
            public int? IdOpreme { get; set; }

            public UpotrebljenoUIntervencijiBasic() { }
        }

        public class UpotrebljenoUIntervencijiPregled
        {
            public int ID { get; set; }
            public string VoziloInfo { get; set; }
            public string OpremaInfo { get; set; }

            public UpotrebljenoUIntervencijiPregled(int id, string vozilo, string oprema)
            {
                this.ID = id;
                this.VoziloInfo = vozilo;
                this.OpremaInfo = oprema;
            }
        }
        #endregion

        #region Ucestvuje
        public class UcestvujeBasic
        {
            public int Id { get; set; }
            public int IdVatrogasca { get; set; }
            public int IdSmene { get; set; }
            public int IdIntervencije { get; set; }

            public UcestvujeBasic() { }
        }

        public class UcestvujePregled
        {
            public int Id { get; set; }
            public string VatrogasacInfo { get; set; }
            public string IntervencijaInfo { get; set; }

            public UcestvujePregled(int id, string vatrogasac, string intervencija)
            {
                this.Id = id;
                this.VatrogasacInfo = vatrogasac;
                this.IntervencijaInfo = intervencija;
            }
        }
        #endregion

        #region Telefon
        public class TelefonBasic
        {
            public int Id { get; set; }
            public string BrojTelefona { get; set; }
            public int? IdLica { get; set; }
            public int? IdVolontera { get; set; }

            public TelefonBasic() { }
        }

        public class TelefonPregled
        {
            public int Id { get; set; }
            public string BrojTelefona { get; set; }

            public TelefonPregled() { }

            public TelefonPregled(int id, string broj)
            {
                this.Id = id;
                this.BrojTelefona = broj;
            }
        }
        #endregion

        #region Sertifikat
        public class SertifikatBasic
        {
            public int Id { get; set; }
            public string NazivSertifikata { get; set; }

            public int IdVozila { get; set; }

            public SertifikatBasic() { }
        }

        public class SertifikatPregled
        {
            public int Id { get; set; }
            public string NazivSertifikata { get; set; }

            public SertifikatPregled() { }

            public SertifikatPregled(int id, string naziv)
            {
                this.Id = id;
                this.NazivSertifikata = naziv;
            }
        }
        #endregion
    }

}


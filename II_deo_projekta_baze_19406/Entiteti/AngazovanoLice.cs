using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Entiteti
{
    public class AngazovanoLice
    {
        public virtual int Id { get; set; }
        public virtual string MaticniBroj { get; set; }
        public virtual string LicnoIme { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string AdresaStanovanja { get; set; }
        public virtual char Pol { get; set; }
        public virtual string EmailAdresa { get; set; }
        public virtual DateTime? DatumPocetkaAngazovanja { get; set; }
        public virtual char FVatrogasac { get; set; }
        public virtual int? BrojSertifikata { get; set; }
        public virtual int? BrojOperativnihIntervencija { get; set; }
        public virtual string StepenFizickeSpremnosti { get; set; }
        public virtual string NivoObucenosti { get; set; }
        public virtual char FDispecer { get; set; }
        public virtual string EvidencijaPoziva { get; set; }
        public virtual string TipOpreme { get; set; }
        public virtual char FTehnicar { get; set; }
        public virtual string PodaciOAlatima { get; set; }
        public virtual string Specijalizacija { get; set; }
        public virtual Stanica Stanica { get; set; }
        public virtual IList<Stanica> StaniceKojeUpravlja { get; set; }
        public virtual IList<AngazovanVatrogasac> AngazmaniNaIntervencijama { get; set; }
        public virtual IList<RadiUSmeni> RadUSmenama { get; set; }
        public virtual IList<Ucestvuje> UcescaNaIntervencijama { get; set; }
        public virtual IList<Telefon> Telefoni { get; set; }
        public virtual IList<Odrzavanje> OdrzavanjaKojaObavlja { get; set; }

        public AngazovanoLice()
        {
            AngazmaniNaIntervencijama = new List<AngazovanVatrogasac>();
            StaniceKojeUpravlja = new List<Stanica>();
            OdrzavanjaKojaObavlja = new List<Odrzavanje>();
            UcescaNaIntervencijama = new List<Ucestvuje>();
            Telefoni = new List<Telefon>();
            RadUSmenama = new List<RadiUSmeni>();
        }
    }
}

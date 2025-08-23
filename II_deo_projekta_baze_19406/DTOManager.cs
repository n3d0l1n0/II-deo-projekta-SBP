using II_deo_projekta_baze_19406.Entiteti;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using static II_deo_projekta_baze_19406.DTOs;
using System.Linq.Expressions;
using System.Windows.Forms;
using StanicaEntitet = II_deo_projekta_baze_19406.Entiteti.Stanica;
using II_deo_projekta_baze_19406.Entiteti;

namespace II_deo_projekta_baze_19406
{
    public class DTOManager
    {

        #region Stanica
        public static void ObrisiStanicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                StanicaEntitet stanicaZaBrisanje = s.Load<StanicaEntitet>(id);
                if (stanicaZaBrisanje!=null)
                {
                    s.Delete(stanicaZaBrisanje);
                }
                s.Flush();

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static StanicaBasic VratiStanicu(int id)
        {
            StanicaBasic stanicaBasic = null;
            try
            {
                    ISession s = DataLayer.GetSession();
                    Entiteti.Stanica stanica = s.Load<Entiteti.Stanica>(id);
                    if (stanica != null)
                    {
                        stanicaBasic = new StanicaBasic
                        {
                            ID = stanica.Id,
                            Naziv = stanica.Naziv,
                            PovrsinaObjekta = stanica.PovrsinaObjekta,
                            Adresa = stanica.Adresa,
                            DostupnaInfrastruktura = stanica.DostupnaInfrastruktura,
                            BrojZaposlenih = stanica.BrojZaposlenih,
                            BrojVozila = stanica.BrojVozila,
                            UpravnikPrikaz = stanica.Upravnik != null ? $"{stanica.Upravnik.LicnoIme} {stanica.Upravnik.Prezime}" : "Nema komandira"
                        };
                    }
                    s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return stanicaBasic;
        }
        public static List<StanicaPregled> VratiSveStanice()
        {
            List<StanicaPregled> staniceInfo = new List<StanicaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                
                    IEnumerable<Entiteti.Stanica> stanice = from o in s.Query<Entiteti.Stanica>() select o;

                    foreach (Entiteti.Stanica st in stanice)
                    {
                        staniceInfo.Add(new StanicaPregled(st.Id, st.Naziv, st.Adresa, st.PovrsinaObjekta, st.DostupnaInfrastruktura, st.BrojZaposlenih, st.BrojVozila));
                    }
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return staniceInfo;
        }
        public static void IzmeniStanicu(StanicaBasic stanicaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Stanica stanica = s.Load<Entiteti.Stanica>(stanicaBasic.ID);

                stanica.Naziv = stanicaBasic.Naziv;
                stanica.Adresa = stanicaBasic.Adresa;
                stanica.PovrsinaObjekta = stanicaBasic.PovrsinaObjekta;
                stanica.DostupnaInfrastruktura = stanicaBasic.DostupnaInfrastruktura;

                s.Update(stanica);
                s.Flush();

                s.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
                throw; 
            }
        }
        public static void SacuvajStanicu(StanicaBasic stanicaBasic)
        {
            if (string.IsNullOrWhiteSpace(stanicaBasic.Naziv))
            {
                throw new ArgumentException("Naziv stanice ne moze biti prazan.");
            }
            try
            {
                ISession s = DataLayer.GetSession();
                string nazivZaProveru = stanicaBasic.Naziv.Trim();

                bool daLiPostoji = s.Query<StanicaEntitet>()
                                     .Any(st => st.Naziv.Trim().ToLower() == nazivZaProveru.ToLower());

                if (daLiPostoji)
                {
                    throw new InvalidOperationException($"Stanica sa nazivom '{stanicaBasic.Naziv}' vec postoji u bazi.");
                }
                else
                {
                    StanicaEntitet stanica = new StanicaEntitet
                    {
                        Naziv = stanicaBasic.Naziv,
                        Adresa = stanicaBasic.Adresa,
                        PovrsinaObjekta = stanicaBasic.PovrsinaObjekta,
                        DostupnaInfrastruktura = stanicaBasic.DostupnaInfrastruktura,
                    };

                    s.Save(stanica);
                    s.Flush();
                }

                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region Smena
        public static void DodajRadnikaUSmenu(int smenaId, int radnikId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                bool postoji = s.Query<RadiUSmeni>().Any(rus => rus.Smena.Id == smenaId && rus.Radnik.Id == radnikId);
                if (!postoji)
                {
                    RadiUSmeni novaVeza = new RadiUSmeni
                    {
                         Smena = s.Load<Smena>(smenaId),
                         Radnik = s.Load<AngazovanoLice>(radnikId)
                    };
                    s.Save(novaVeza);
                    s.Flush();
                }
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static bool UkloniRadnikaIzSmene(int smenaId, int radnikId)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                RadiUSmeni vezaZaBrisanje = s.Query<RadiUSmeni>()
                                                 .FirstOrDefault(rus => rus.Smena.Id == smenaId && rus.Radnik.Id == radnikId);

                if (vezaZaBrisanje != null)
                {
                    s.Delete(vezaZaBrisanje);
                    s.Flush();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<AngazovanoLicePregled> VratiRadnikeZaSmenu(int smenaId)
        {
            List<AngazovanoLicePregled> radnici = new List<AngazovanoLicePregled>();
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var angazovanja = s.Query<RadiUSmeni>()
                                       .Where(rus => rus.Smena.Id == smenaId)
                                       .Select(rus => rus.Radnik)
                                       .ToList();

                    foreach (var radnik in angazovanja)
                    {
                        radnici.Add(new AngazovanoLicePregled(radnik.Id, radnik.LicnoIme, radnik.Prezime, radnik.EmailAdresa, radnik.FVatrogasac, radnik.FDispecer, radnik.FTehnicar));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return radnici;
        }
        public static void ObrisiSmenu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smena smena = s.Load<Smena>(id);
                s.Delete(smena);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static List<SmenaPregled> VratiSveSmeneZaStanicu(int stanicaId)
        {
            List<SmenaPregled> smeneInfo = new List<SmenaPregled>();
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    List<Smena> smene = s.Query<Smena>()
                                         .Where(sm => sm.Stanica.Id == stanicaId)
                                         .ToList();

                    foreach (Smena sm in smene)
                    {
                        string nazivStanice = sm.Stanica?.Naziv ?? "------";
                        smeneInfo.Add(new SmenaPregled(sm.Id, sm.Datum, sm.VremePocetka, sm.VremeKraja, nazivStanice));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return smeneInfo;
        }
        public static List<SmenaPregled> VratiSveSmene()
        {
            List<SmenaPregled> smeneInfo = new List<SmenaPregled>();
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    List<Smena> smene = s.Query<Smena>().Fetch(x => x.Stanica).ToList(); 
                    foreach (Smena sm in smene)
                    {
                        smeneInfo.Add(new SmenaPregled(sm.Id, sm.Datum, sm.VremePocetka, sm.VremeKraja, sm.Stanica?.Naziv ?? "-------"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return smeneInfo;
        }
        public static SmenaBasic VratiSmenu(int id)
        {
            SmenaBasic smenaBasic = null;
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    Smena smena = s.Get<Smena>(id);
                    if (smena != null)
                    {
                        smenaBasic = new SmenaBasic
                        {
                            Id = smena.Id,
                            Datum = smena.Datum,
                            VremePocetka = smena.VremePocetka,
                            VremeKraja = smena.VremeKraja,
                            IdStanice = smena.Stanica.Id
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return smenaBasic;
        }
        public static void IzmeniSmenu(SmenaBasic smenaBasic)
        {
            ISession s = null; 
            try
            {
                s = DataLayer.GetSession();
                Smena smena = s.Get<Smena>(smenaBasic.Id);

                if (smena != null)
                {
                    smena.Datum = smenaBasic.Datum;
                    smena.VremePocetka = smenaBasic.VremePocetka;
                    smena.VremeKraja = smenaBasic.VremeKraja;
                    smena.Stanica = s.Load<Entiteti.Stanica>(smenaBasic.IdStanice);
                    s.Update(smena);
                    s.Flush();
                }
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void SacuvajSmenu(SmenaBasic smenaBasic)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Smena smena = new Smena
                {
                    Datum = smenaBasic.Datum,
                    VremePocetka = smenaBasic.VremePocetka,
                    VremeKraja = smenaBasic.VremeKraja,
                    Stanica = s.Load<Entiteti.Stanica>(smenaBasic.IdStanice)
                };
                s.Save(smena);

                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region ServisVozila
        public static List<ServisVozilaPregled> VratiSveServiseZaVozilo(int voziloId)
        {
            List<ServisVozilaPregled> servisi = new List<ServisVozilaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                    IEnumerable<ServisVozila> sviServisi = from sv in s.Query<ServisVozila>()
                                                           where sv.Vozilo.Id == voziloId
                                                           select sv;

                    foreach (var servis in sviServisi)
                    {
                        servisi.Add(new ServisVozilaPregled(servis.Id, servis.StatusServisa, servis.DatumPocetka, servis.Vozilo.RegistarskaOznaka));
                    }
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return servisi;
        }
        public static ServisVozilaBasic VratiServisVozila(int id)
        {
            ServisVozilaBasic servisBasic = null;
            try
            {
                ISession s = DataLayer.GetSession();
                
                    ServisVozila servis = s.Load<ServisVozila>(id);
                    if (servis != null)
                    {
                        servisBasic = new ServisVozilaBasic(servis.Id, servis.StatusServisa, servis.DatumPocetka, servis.DatumKraja, servis.Vozilo.Id);
                    }
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return servisBasic;
        }
        public static void SacuvajServisVozila(ServisVozilaBasic servisBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                ServisVozila servis = new ServisVozila
                {
                    StatusServisa = servisBasic.StatusServisa,
                    DatumPocetka = servisBasic.DatumPocetka,
                    DatumKraja = servisBasic.DatumKraja,
                    Vozilo = s.Load<Vozilo>(servisBasic.VoziloId)
                };
                s.Save(servis);

                s.Flush();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                s.Close();
            }
        }
        public static void ObrisiServisVozila(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                ServisVozila servis = s.Load<ServisVozila>(id);
                s.Delete(servis);
                s.Flush();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                s.Close();
            }
        }
        public static void IzmeniServisVozila(ServisVozilaBasic servisBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                ServisVozila servis = s.Get<ServisVozila>(servisBasic.Id);
                if (servis != null)
                {
                    servis.StatusServisa = servisBasic.StatusServisa;
                    servis.DatumPocetka = servisBasic.DatumPocetka;
                    servis.DatumKraja = servisBasic.DatumKraja;

                    s.Update(servis);
                    s.Flush();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                s.Close();
            }
        }

        #endregion

        #region Ponavljanje
        public static List<PonavljanjePregled> VratiPonavljanjaZaDispecera(int idDispecera)
        {
            List<PonavljanjePregled> ponavljanja = new List<PonavljanjePregled>();
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var radoviUSmeni = s.Query<RadiUSmeni>()
                                .Where(rus => rus.Radnik.Id == idDispecera)
                                .Select(rus => rus.Smena) 
                                .ToList(); 

                    var grupisanoPoMesecu = radoviUSmeni
                        .GroupBy(smena => smena.Datum.ToString("MMMM yyyy")) 
                        .Select(grupa => new
                        {
                            Mesec = grupa.Key,
                            BrojSmena = grupa.Count()
                        })
                        .OrderBy(rez => DateTime.Parse(rez.Mesec)); 

                    foreach (var grupa in grupisanoPoMesecu)
                    {
                        ponavljanja.Add(new PonavljanjePregled(0, grupa.Mesec, grupa.BrojSmena, ""));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return ponavljanja;
        }

        #endregion

        #region AngazovanoLice
        public static int IzracunajBrojIntervencijaZaVatrogasca(int idVatrogasca, ISession s)
        {
            return s.Query<Ucestvuje>()
                    .Where(u => u.Vatrogasac != null && u.Vatrogasac.Id == idVatrogasca)
                    .Select(u => u.Intervencija.Id) 
                    .Distinct() 
                    .Count();
        }
        public static void ObrisiAngazovanoLice(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                AngazovanoLice lice = s.Load<AngazovanoLice>(id);

                if (lice != null)
                {
                    if (lice.Stanica != null)
                    {
                        Entiteti.Stanica stanica = lice.Stanica;
                        stanica.BrojZaposlenih--;
                        s.Update(stanica);
                    }

                    s.Delete(lice);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static AngazovanoLiceBasic VratiAngazovanoLice(int id)
        {
            AngazovanoLiceBasic liceBasic = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                AngazovanoLice lice = s.Load<AngazovanoLice>(id);

                if (lice != null)
                {
                    liceBasic = new AngazovanoLiceBasic
                    {
                        ID = lice.Id,
                        Maticni_broj = lice.MaticniBroj,
                        Licno_ime = lice.LicnoIme,
                        Prezime = lice.Prezime,
                        Datum_rodjenja = lice.DatumRodjenja,
                        Adresa_stanovanja = lice.AdresaStanovanja,
                        Pol = lice.Pol,
                        Email_adresa = lice.EmailAdresa,
                        Datum_pocetka_angazovanja = lice.DatumPocetkaAngazovanja,
                        FVatrogasac = lice.FVatrogasac,
                        Broj_sertifikata = lice.BrojSertifikata,
                        Broj_operativnih_intervencija = lice.BrojOperativnihIntervencija,
                        Stepen_fizicke_spremnosti = lice.StepenFizickeSpremnosti,
                        Nivo_obucenosti = lice.NivoObucenosti,
                        FDispecer = lice.FDispecer,
                        Evidencija_poziva = lice.EvidencijaPoziva,
                        Tip_opreme = lice.TipOpreme,
                        FTehnicar = lice.FTehnicar,
                        Podaci_o_alatima = lice.PodaciOAlatima,
                        Specijalizacija = lice.Specijalizacija,
                        StanicaID = lice.Stanica?.Id
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return liceBasic;
        }
        public static List<AngazovanoLicePregled> VratiSvaAngazovanaLicaIzStanice(int stanicaId)
        {
            List<AngazovanoLicePregled> licaInfo = new List<AngazovanoLicePregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<AngazovanoLice> lica = from o in s.Query<AngazovanoLice>()
                                                   where o.Stanica != null && o.Stanica.Id == stanicaId
                                                   select o;

                foreach (AngazovanoLice lice in lica)
                {
                    licaInfo.Add(new AngazovanoLicePregled(lice.Id, lice.LicnoIme, lice.Prezime, lice.EmailAdresa, lice.FVatrogasac, lice.FDispecer, lice.FTehnicar));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return licaInfo;
        }
        public static void IzmeniAngazovanoLice(AngazovanoLiceBasic liceBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                AngazovanoLice lice = s.Load<AngazovanoLice>(liceBasic.ID);
                int? staraStanicaId = lice.Stanica?.Id;
                int? novaStanicaId = liceBasic.StanicaID;

                if (staraStanicaId != novaStanicaId)
                {
                    if (staraStanicaId.HasValue)
                    {
                        Entiteti.Stanica staraStanica = s.Get<Entiteti.Stanica>(staraStanicaId.Value);
                        if (staraStanica != null)
                        {
                            staraStanica.BrojZaposlenih--;
                            s.Update(staraStanica);
                        }
                    }
                    if (novaStanicaId.HasValue)
                    {
                        Entiteti.Stanica novaStanica = s.Get<Entiteti.Stanica>(novaStanicaId.Value);
                        if (novaStanica != null)
                        {
                            novaStanica.BrojZaposlenih++;
                            s.Update(novaStanica);
                            lice.Stanica = novaStanica;
                        }
                    }
                    else
                    {
                        lice.Stanica = null;
                    }
                }

                lice.MaticniBroj = liceBasic.Maticni_broj;
                lice.LicnoIme = liceBasic.Licno_ime;
                lice.Prezime = liceBasic.Prezime;
                lice.DatumRodjenja = liceBasic.Datum_rodjenja;
                lice.AdresaStanovanja = liceBasic.Adresa_stanovanja;
                lice.Pol = liceBasic.Pol;
                lice.EmailAdresa = liceBasic.Email_adresa;
                lice.DatumPocetkaAngazovanja = liceBasic.Datum_pocetka_angazovanja;
                lice.FVatrogasac = liceBasic.FVatrogasac;
                lice.BrojSertifikata = liceBasic.Broj_sertifikata;
                lice.StepenFizickeSpremnosti = liceBasic.Stepen_fizicke_spremnosti;
                lice.NivoObucenosti = liceBasic.Nivo_obucenosti;
                lice.FDispecer = liceBasic.FDispecer;
                lice.EvidencijaPoziva = liceBasic.Evidencija_poziva;
                lice.TipOpreme = liceBasic.Tip_opreme;
                lice.FTehnicar = liceBasic.FTehnicar;
                lice.PodaciOAlatima = liceBasic.Podaci_o_alatima;
                lice.Specijalizacija = liceBasic.Specijalizacija;

                if (lice.FVatrogasac == 'T')
                {
                    lice.BrojOperativnihIntervencija = IzracunajBrojIntervencijaZaVatrogasca(lice.Id, s);
                }
                else
                {
                    lice.BrojOperativnihIntervencija = null;
                }
                s.Update(lice);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<AngazovanoLicePregled> VratiSvaAngazovanaLica()
        {
            List<AngazovanoLicePregled> lica = new List<AngazovanoLicePregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<AngazovanoLice> svaLica = from l in s.Query<AngazovanoLice>() select l;

                foreach (var al in svaLica)
                {
                    lica.Add(new AngazovanoLicePregled(al.Id, al.LicnoIme, al.Prezime, al.EmailAdresa, al.FVatrogasac, al.FDispecer, al.FTehnicar));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return lica;
        }
        public static List<DispecerPregled> VratiSveDispecere()
        {
            List<DispecerPregled> dispeceri = new List<DispecerPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<AngazovanoLice> sviDispeceri = from lice in s.Query<AngazovanoLice>()
                                                           where lice.FDispecer == 'T'
                                                           select lice;

                foreach (var d in sviDispeceri)
                {
                    dispeceri.Add(new DispecerPregled(d.Id, d.LicnoIme, d.Prezime));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return dispeceri;
        }
        public static List<AngazovanoLiceDetaljiPregled> VratiSvaLicaDetaljno()
        {
            List<AngazovanoLiceDetaljiPregled> lica = new List<AngazovanoLiceDetaljiPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var ponavljanjaPoDispeceru = s.Query<Ponavljanje>()
                    .ToList()
                    .GroupBy(p => p.Dispecer.Id)
                    .ToDictionary(
                        g => g.Key,
                        g => string.Join(", ", g.Select(p => $"{p.BrojSmena}"))
                    );
             
                IEnumerable<AngazovanoLice> svaLica = s.Query<AngazovanoLice>().Fetch(l => l.Stanica).ToList();

                foreach (var lice in svaLica)
                {
                    string brojSmenaInfo = "--------";
                    if (ponavljanjaPoDispeceru.ContainsKey(lice.Id))
                    {
                        brojSmenaInfo = ponavljanjaPoDispeceru[lice.Id];
                    }

                    lica.Add(new AngazovanoLiceDetaljiPregled
                    {
                        ID = lice.Id,
                        MaticniBroj = lice.MaticniBroj,
                        Ime = lice.LicnoIme,
                        Prezime = lice.Prezime,
                        DatumRodjenja = lice.DatumRodjenja,
                        Pol = lice.Pol,
                        Adresa = lice.AdresaStanovanja,
                        Email = lice.EmailAdresa,
                        DatumAngazovanja = lice.DatumPocetkaAngazovanja,
                        NazivStanice = lice.Stanica?.Naziv ?? "-----------",
                        FVatrogasac = lice.FVatrogasac,
                        FDispecer = lice.FDispecer,
                        FTehnicar = lice.FTehnicar,
                        BrojSmenaMesecno = brojSmenaInfo,
                        BrojSertifikata = lice.BrojSertifikata,
                        BrojOperativnihIntervencija = lice.BrojOperativnihIntervencija,
                        StepenFizickeSpremnosti = lice.StepenFizickeSpremnosti,
                        NivoObucenosti = lice.NivoObucenosti,
                        EvidencijaPoziva = lice.EvidencijaPoziva,
                        TipOpreme = lice.TipOpreme,
                        Specijalizacija = lice.Specijalizacija,
                        PodaciOAlatima = lice.PodaciOAlatima
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return lica;
        }
        public static void SacuvajAngazovanoLice(AngazovanoLiceBasic liceBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                AngazovanoLice lice = new AngazovanoLice
                {
                    MaticniBroj = liceBasic.Maticni_broj,
                    LicnoIme = liceBasic.Licno_ime,
                    Prezime = liceBasic.Prezime,
                    DatumRodjenja = liceBasic.Datum_rodjenja,
                    AdresaStanovanja = liceBasic.Adresa_stanovanja,
                    Pol = liceBasic.Pol,
                    EmailAdresa = liceBasic.Email_adresa,
                    DatumPocetkaAngazovanja = liceBasic.Datum_pocetka_angazovanja,
                    FVatrogasac = liceBasic.FVatrogasac,
                    BrojSertifikata = liceBasic.Broj_sertifikata,
                    StepenFizickeSpremnosti = liceBasic.Stepen_fizicke_spremnosti,
                    NivoObucenosti = liceBasic.Nivo_obucenosti,
                    FDispecer = liceBasic.FDispecer,
                    EvidencijaPoziva = liceBasic.Evidencija_poziva,
                    TipOpreme = liceBasic.Tip_opreme,
                    FTehnicar = liceBasic.FTehnicar,
                    PodaciOAlatima = liceBasic.Podaci_o_alatima,
                    Specijalizacija = liceBasic.Specijalizacija
                };
                if (lice.FVatrogasac == 'T')
                {
                    lice.BrojSertifikata = liceBasic.Broj_sertifikata;
                    lice.StepenFizickeSpremnosti = liceBasic.Stepen_fizicke_spremnosti;
                    lice.NivoObucenosti = liceBasic.Nivo_obucenosti;
                    lice.BrojOperativnihIntervencija = 0;
                }

                if (lice.FDispecer == 'T')
                {
                    lice.EvidencijaPoziva = liceBasic.Evidencija_poziva;
                    lice.TipOpreme = liceBasic.Tip_opreme;
                }

                if (lice.FTehnicar == 'T')
                {
                    lice.PodaciOAlatima = liceBasic.Podaci_o_alatima;
                    lice.Specijalizacija = liceBasic.Specijalizacija;
                }
                if (!liceBasic.StanicaID.HasValue)
                {
                    throw new ArgumentNullException("StanicaID", "ID stanice ne moze biti null prilikom cuvanja novog lica.");
                }

                Entiteti.Stanica stanica = s.Load<Entiteti.Stanica>(liceBasic.StanicaID.Value);

                if (stanica == null)
                {
                    throw new Exception("Stanica sa datim ID-jem ne postoji.");
                }

                lice.Stanica = stanica;
                stanica.BrojZaposlenih++;
                s.Update(stanica);
                s.Save(lice);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<TehnicarPregled> VratiSveTehnicare()
        {
            List<TehnicarPregled> tehnicari = new List<TehnicarPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<AngazovanoLice> sviTehnicari = from lice in s.Query<AngazovanoLice>()
                                                           where lice.FTehnicar == 'T'
                                                           select lice;

                foreach (var t in sviTehnicari)
                {
                    tehnicari.Add(new TehnicarPregled(t.Id, t.LicnoIme, t.Prezime));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return tehnicari;
        }
        public static void ZaduziOpremuTehnicaru(int idOpreme, int idTehnicara)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Oprema oprema = s.Get<Oprema>(idOpreme);
                AngazovanoLice tehnicar = s.Get<AngazovanoLice>(idTehnicara);

                if (oprema != null && tehnicar != null)
                {
                    oprema.PripadaLicu = tehnicar;
                    s.Update(oprema);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void RazduziOpremu(int idOpreme)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Oprema oprema = s.Get<Oprema>(idOpreme);

                if (oprema != null)
                {
                    oprema.PripadaLicu = null; 
                    s.Update(oprema);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }

        #endregion

        #region Volonter
        public static void ObrisiVolontera(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Volonter v = s.Load<Volonter>(id);
                s.Delete(v);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static VolonterBasic VratiVolontera(int id)
        {
            VolonterBasic vBasic = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Volonter v = s.Load<Volonter>(id);
                if (v != null)
                {
                    vBasic = new VolonterBasic(v.Id, v.MaticniBroj, v.LicnoIme, v.Prezime, v.DatumRodjenja, v.AdresaStanovanja, v.Pol, v.EmailAdresa, v.PripadaVozilu?.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return vBasic;
        }
        public static List<VolonterDetaljiPregled> VratiSveVolontereDetaljno()
        {
            List<VolonterDetaljiPregled> volonteri = new List<VolonterDetaljiPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Volonter> sviVolonteri = s.Query<Volonter>()
                                                      .Fetch(v => v.PripadaVozilu)
                                                      .ToList();
                foreach (Volonter v in sviVolonteri)
                {
                    string tipVozila = "Nedefinisan";
                    if (v.PripadaVozilu != null)
                    {
                        if (v.PripadaVozilu.FVatrogasno == 'T') tipVozila = "Vatrogasno";
                        else if (v.PripadaVozilu.FSpasilacko == 'T') tipVozila = "Spasilacko";
                        else if (v.PripadaVozilu.FTehnickaPodrska == 'T') tipVozila = "Tehnicka podrska";
                    }

                    volonteri.Add(new VolonterDetaljiPregled
                    {
                        Id = v.Id,
                        MaticniBroj = v.MaticniBroj,
                        LicnoIme = v.LicnoIme,
                        Prezime = v.Prezime,
                        DatumRodjenja = v.DatumRodjenja,
                        Pol = v.Pol,
                        AdresaStanovanja = v.AdresaStanovanja,
                        EmailAdresa = v.EmailAdresa,
                        RegistarskaOznaka = v.PripadaVozilu?.RegistarskaOznaka ?? "Nema vozilo",
                        ProizvodjacVozila = v.PripadaVozilu?.Proizvodjac ?? "------",
                        TipVozila = v.PripadaVozilu != null ? tipVozila : "-------"
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return volonteri;
        }
        public static void IzmeniVolontera(VolonterBasic vBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Volonter v = s.Get<Volonter>(vBasic.Id);
                if (v != null)
                {
                    v.MaticniBroj = vBasic.MaticniBroj;
                    v.LicnoIme = vBasic.LicnoIme;
                    v.Prezime = vBasic.Prezime;
                    v.DatumRodjenja = vBasic.DatumRodjenja;
                    v.AdresaStanovanja = vBasic.AdresaStanovanja;
                    v.Pol = vBasic.Pol;
                    v.EmailAdresa = vBasic.EmailAdresa;
                    v.PripadaVozilu = vBasic.IdVozila.HasValue ? s.Load<Vozilo>(vBasic.IdVozila.Value) : null;
                    s.Update(v);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void SacuvajVolontera(VolonterBasic vBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Volonter v = new Volonter
                {
                    MaticniBroj = vBasic.MaticniBroj,
                    LicnoIme = vBasic.LicnoIme,
                    Prezime = vBasic.Prezime,
                    DatumRodjenja = vBasic.DatumRodjenja,
                    AdresaStanovanja = vBasic.AdresaStanovanja,
                    Pol = vBasic.Pol,
                    EmailAdresa = vBasic.EmailAdresa,
                    PripadaVozilu = vBasic.IdVozila.HasValue ? s.Load<Vozilo>(vBasic.IdVozila.Value) : null
                };
                s.Save(v);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }

        #endregion

        #region Vozilo
        public static void ObrisiVozilo(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Vozilo v = s.Load<Vozilo>(id);
                if (v != null)
                {
                    if (v.PripadaStanici!= null)
                    {
                        Entiteti.Stanica stanica = v.PripadaStanici;
                        stanica.BrojVozila--;
                        s.Update(stanica);
                    }
                    s.Delete(v);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static VoziloBasic VratiVozilo(int id)
        {
            VoziloBasic vBasic = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Vozilo v = s.Get<Vozilo>(id);
                if (v != null)
                {
                    if (v.PripadaStanici != null)
                    {
                        NHibernateUtil.Initialize(v.PripadaStanici);
                    }

                    vBasic = new VoziloBasic
                    {
                        Id = v.Id,
                        RegistarskaOznaka = v.RegistarskaOznaka,
                        Kapacitet = v.Kapacitet,
                        Proizvodjac = v.Proizvodjac,
                        GodinaProizvodnje = v.GodinaProizvodnje,
                        DatumPoslednjegPregleda = v.DatumPoslednjegPregleda,
                        DatumIstekaRegistracije = v.DatumIstekaRegistracije,
                        StatusVozila = v.StatusVozila,
                        FVatrogasno = v.FVatrogasno,
                        TipVatrogasno = v.TipVatrogasno,
                        FSpasilacko = v.FSpasilacko,
                        TipSpasilacko = v.TipSpasilacko,
                        FTehnickaPodrska = v.FTehnickaPodrska,
                        TipTehnickaPodrska = v.TipTehnickaPodrska,
                        IdStanice = v.PripadaStanici?.Id
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return vBasic;
        }
        public static List<VoziloPregled> VratiSvaVozila()
        {
            List<VoziloPregled> vozila = new List<VoziloPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Vozilo> svaVozila = from v in s.Query<Vozilo>() select v;
                foreach (Vozilo v in svaVozila)
                {
                    string tip = "Nedefinisan";
                    if (v.FVatrogasno == 'T') tip = $"Vatrogasno ({v.TipVatrogasno})";
                    else if (v.FSpasilacko == 'T') tip = $"Spasilacko ({v.TipSpasilacko})";
                    else if (v.FTehnickaPodrska == 'T') tip = $"Tehnicka podrska ({v.TipTehnickaPodrska})";

                    vozila.Add(new VoziloPregled
                    {
                        Id = v.Id,
                        RegistarskaOznaka = v.RegistarskaOznaka,
                        Proizvodjac = v.Proizvodjac,
                        StatusVozila = v.StatusVozila,
                        TipVozila = tip
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return vozila;
        }
        public static List<VoziloPregled> VratiSvaVozilaIzStanice(int stanicaId)
        {
            List<VoziloPregled> vozilaInfo = new List<VoziloPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Vozilo> vozila = from o in s.Query<Vozilo>()
                                             where o.PripadaStanici != null && o.PripadaStanici.Id == stanicaId
                                             select o;

                foreach (Vozilo vozilo in vozila)
                {
                    vozilaInfo.Add(new VoziloPregled(vozilo.Id, vozilo.RegistarskaOznaka, vozilo.Proizvodjac, vozilo.StatusVozila));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return vozilaInfo;
        }
        public static void AzurirajTehnicareZaVozilo(int voziloId, List<int> noviIdjeviTehnicara)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Vozilo v = s.Get<Vozilo>(voziloId);
                if (v == null) return;

                List<int> trenutniIdjeviTehnicara = v.Odrzavanja.Select(o => o.Tehnicar.Id).ToList();
                List<int> idjeviZaBrisanje = trenutniIdjeviTehnicara.Except(noviIdjeviTehnicara).ToList();

                foreach (int tehnicarId in idjeviZaBrisanje)
                {
                    Odrzavanje odrzavanjeZaBrisanje = v.Odrzavanja.FirstOrDefault(o => o.Tehnicar.Id == tehnicarId);
                    if (odrzavanjeZaBrisanje != null)
                    {
                        v.Odrzavanja.Remove(odrzavanjeZaBrisanje);
                    }
                }

                List<int> idjeviZaDodavanje = noviIdjeviTehnicara.Except(trenutniIdjeviTehnicara).ToList();

                foreach (int tehnicarId in idjeviZaDodavanje)
                {
                    Odrzavanje novoOdrzavanje = new Odrzavanje
                    {
                        Vozilo = v,
                        Tehnicar = s.Load<AngazovanoLice>(tehnicarId)
                    };
                    v.Odrzavanja.Add(novoOdrzavanje);
                }

                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void IzmeniVozilo(VoziloBasic vBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Vozilo v = s.Get<Vozilo>(vBasic.Id);

                int? staraStanicaId = v.PripadaStanici?.Id;
                int? novaStanicaId = vBasic.IdStanice;

                v.RegistarskaOznaka = vBasic.RegistarskaOznaka;
                v.Kapacitet = vBasic.Kapacitet.Value;
                v.Proizvodjac = vBasic.Proizvodjac;
                v.GodinaProizvodnje = vBasic.GodinaProizvodnje.Value;
                v.DatumPoslednjegPregleda = vBasic.DatumPoslednjegPregleda.Value;
                v.DatumIstekaRegistracije = vBasic.DatumIstekaRegistracije.Value;
                v.StatusVozila = vBasic.StatusVozila;

                if (vBasic.FVatrogasno == 'T')
                {
                    v.FVatrogasno = 'T';
                    v.TipVatrogasno = vBasic.TipVatrogasno;
                    v.FSpasilacko = null;
                    v.TipSpasilacko = null;
                    v.FTehnickaPodrska = null;
                    v.TipTehnickaPodrska = null;
                }
                else if (vBasic.FSpasilacko == 'T')
                {
                    v.FVatrogasno = null;
                    v.TipVatrogasno = null;
                    v.FSpasilacko = 'T';
                    v.TipSpasilacko = vBasic.TipSpasilacko;
                    v.FTehnickaPodrska = null;
                    v.TipTehnickaPodrska = null;
                }
                else if (vBasic.FTehnickaPodrska == 'T')
                {
                    v.FVatrogasno = null;
                    v.TipVatrogasno = null;
                    v.FSpasilacko = null;
                    v.TipSpasilacko = null;
                    v.FTehnickaPodrska = 'T';
                    v.TipTehnickaPodrska = vBasic.TipTehnickaPodrska;
                }
                else
                {
                    v.FVatrogasno = null;
                    v.TipVatrogasno = null;
                    v.FSpasilacko = null;
                    v.TipSpasilacko = null;
                    v.FTehnickaPodrska = null;
                    v.TipTehnickaPodrska = null;
                }

                if (staraStanicaId != novaStanicaId)
                {
                    if (staraStanicaId.HasValue)
                    {
                        Entiteti.Stanica staraStanica = s.Get<Entiteti.Stanica>(staraStanicaId.Value);
                        if (staraStanica != null)
                        {
                            staraStanica.BrojVozila--;
                            s.Update(staraStanica);
                        }
                    }
                    if (novaStanicaId.HasValue)
                    {
                        Entiteti.Stanica novaStanica = s.Get<Entiteti.Stanica>(novaStanicaId.Value);
                        if (novaStanica != null)
                        {
                            novaStanica.BrojVozila++;
                            s.Update(novaStanica);
                            v.PripadaStanici = novaStanica;
                        }
                    }
                    else
                    {
                        v.PripadaStanici = null;
                    }
                }

                s.Update(v);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void SacuvajVozilo(VoziloBasic vBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Vozilo v = new Vozilo
                {
                    RegistarskaOznaka = vBasic.RegistarskaOznaka,
                    Kapacitet = vBasic.Kapacitet.Value,
                    Proizvodjac = vBasic.Proizvodjac,
                    GodinaProizvodnje = vBasic.GodinaProizvodnje.Value,
                    DatumPoslednjegPregleda = vBasic.DatumPoslednjegPregleda.Value,
                    DatumIstekaRegistracije = vBasic.DatumIstekaRegistracije.Value,
                    StatusVozila = vBasic.StatusVozila,
                };
                if (vBasic.FVatrogasno == 'T')
                {
                    v.FVatrogasno = 'T';
                    v.TipVatrogasno = vBasic.TipVatrogasno;
                }
                else if (vBasic.FSpasilacko == 'T')
                {
                    v.FSpasilacko = 'T';
                    v.TipSpasilacko = vBasic.TipSpasilacko;
                }
                else if (vBasic.FTehnickaPodrska == 'T')
                {
                    v.FTehnickaPodrska = 'T';
                    v.TipTehnickaPodrska = vBasic.TipTehnickaPodrska;
                }
                
                Entiteti.Stanica stanica = s.Load<Entiteti.Stanica>(vBasic.IdStanice.Value);

                if (stanica == null)
                {
                    throw new Exception("Stanica sa datim ID-jem ne postoji.");
                }

                v.PripadaStanici = stanica;
                stanica.BrojVozila++;
                s.Update(stanica);
                s.Save(v);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }

        #endregion

        #region Oprema
        public static List<StanicaPregled> VratiSveStaniceZaListu()
        {
            List<StanicaPregled> stanice = new List<StanicaPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Entiteti.Stanica> sveStanice = from st in s.Query<Entiteti.Stanica>() select st;
                foreach (var st in sveStanice)
                {
                    stanice.Add(new StanicaPregled(st.Id, st.Naziv, st.Adresa, st.PovrsinaObjekta, st.DostupnaInfrastruktura, st.BrojZaposlenih, st.BrojVozila));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return stanice;
        }
        public static List<VoziloPregled> VratiSvaVozilaZaListu()
        {
            List<VoziloPregled> vozila = new List<VoziloPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Vozilo> svaVozila = from v in s.Query<Vozilo>() select v;
                foreach (var v in svaVozila)
                {
                    vozila.Add(new VoziloPregled(v.Id, v.RegistarskaOznaka, v.Proizvodjac, v.StatusVozila));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return vozila;
        }
        public static void ObrisiOpremu(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Oprema o = s.Load<Oprema>(id);
                s.Delete(o);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static OpremaBasic VratiOpremu(int id)
        {
            OpremaBasic oBasic = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Oprema o = s.Load<Oprema>(id);
                if (o != null)
                {
                    oBasic = new OpremaBasic
                    {
                        Id = o.Id,
                        InventarskiBroj = o.InventarskiBroj,
                        DatumNabavke = o.DatumNabavke,
                        StatusOpreme = o.StatusOpreme,
                        FZastitna = o.FZastitna,
                        TipZastitna = o.TipZastitna,
                        FZaPozare = o.FZaPozare,
                        TipZaPozare = o.TipZaPozare,
                        FSpecijalna = o.FSpecijalna,
                        TipSpecijalna = o.TipSpecijalna,
                        FTehnicka = o.FTehnicka,
                        TipTehnicka = o.TipTehnicka,
                        IdVozila = o.PripadaVozilu?.Id,
                        IdStanice = o.PripadaStanici?.Id,
                        IdLica = o.PripadaLicu?.Id,
                        ZaduzenoLicePrikaz = o.PripadaLicu != null
                                           ? $"{o.PripadaLicu.LicnoIme} {o.PripadaLicu.Prezime}"
                                           : "Nije zaduzeno"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return oBasic;
        }
        public static List<OpremaPregled> VratiSvuOpremu()
        {
            List<OpremaPregled> oprema = new List<OpremaPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Oprema> svaOprema = from o in s.Query<Oprema>() select o;

                foreach (Oprema o in svaOprema)
                {
                    string lokacija = "Nije dodeljena";
                    if (o.PripadaVozilu != null)
                        lokacija = $"Vozilo: {o.PripadaVozilu.RegistarskaOznaka}";
                    else if (o.PripadaStanici != null)
                        lokacija = $"Stanica: {o.PripadaStanici.Naziv}";
                    else if (o.PripadaLicu != null)
                        lokacija = $"Lice: {o.PripadaLicu.LicnoIme} {o.PripadaLicu.Prezime}";

                    oprema.Add(new OpremaPregled(o.Id, o.InventarskiBroj, o.StatusOpreme, lokacija));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return oprema;
        }
        public static void IzmeniOpremu(OpremaBasic oBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Oprema o = s.Load<Oprema>(oBasic.Id);

                o.InventarskiBroj = oBasic.InventarskiBroj;
                o.DatumNabavke = oBasic.DatumNabavke;
                o.StatusOpreme = oBasic.StatusOpreme;
                o.FZastitna = oBasic.FZastitna;
                o.TipZastitna = oBasic.TipZastitna;
                o.FZaPozare = oBasic.FZaPozare;
                o.TipZaPozare = oBasic.TipZaPozare;
                o.FSpecijalna = oBasic.FSpecijalna;
                o.TipSpecijalna = oBasic.TipSpecijalna;
                o.FTehnicka = oBasic.FTehnicka;
                o.TipTehnicka = oBasic.TipTehnicka;

                o.PripadaVozilu = null;
                o.PripadaStanici = null;
                o.PripadaLicu = null;

                if (oBasic.IdVozila.HasValue)
                    o.PripadaVozilu = s.Load<Vozilo>(oBasic.IdVozila.Value);
                else if (oBasic.IdStanice.HasValue)
                    o.PripadaStanici = s.Load<Entiteti.Stanica>(oBasic.IdStanice.Value);
                else if (oBasic.IdLica.HasValue)
                    o.PripadaLicu = s.Load<AngazovanoLice>(oBasic.IdLica.Value);

                s.Update(o);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<UpotrebaIntervencijePregled> VratiUpotrebuZaOpremu(int idOpreme)
        {
            List<UpotrebaIntervencijePregled> upotrebe = new List<UpotrebaIntervencijePregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Oprema oprema = s.Query<Oprema>()
                                 .Where(o => o.Id == idOpreme)
                                 .FetchMany(o => o.UpotrebaUIntervencijama)
                                 .ThenFetch(u => u.NaIntervenciji)
                                 .SingleOrDefault();

                if (oprema != null)
                {
                    foreach (var upotreba in oprema.UpotrebaUIntervencijama)
                    {
                        if (upotreba.NaIntervenciji != null)
                        {
                            upotrebe.Add(new UpotrebaIntervencijePregled(
                                upotreba.NaIntervenciji.Id,
                                upotreba.NaIntervenciji.TipIntervencije,
                                upotreba.NaIntervenciji.Datum
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return upotrebe;
        }
        public static void SacuvajOpremu(OpremaBasic oBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Oprema o = new Oprema
                {
                    InventarskiBroj = oBasic.InventarskiBroj,
                    DatumNabavke = oBasic.DatumNabavke,
                    StatusOpreme = oBasic.StatusOpreme,
                    FZastitna = oBasic.FZastitna,
                    TipZastitna = oBasic.TipZastitna,
                    FZaPozare = oBasic.FZaPozare,
                    TipZaPozare = oBasic.TipZaPozare,
                    FSpecijalna = oBasic.FSpecijalna,
                    TipSpecijalna = oBasic.TipSpecijalna,
                    FTehnicka = oBasic.FTehnicka,
                    TipTehnicka = oBasic.TipTehnicka
                };

                if (oBasic.IdVozila.HasValue)
                    o.PripadaVozilu = s.Load<Vozilo>(oBasic.IdVozila.Value);
                else if (oBasic.IdStanice.HasValue)
                    o.PripadaStanici = s.Load<Entiteti.Stanica>(oBasic.IdStanice.Value);
                else if (oBasic.IdLica.HasValue)
                    o.PripadaLicu = s.Load<AngazovanoLice>(oBasic.IdLica.Value);

                s.Save(o);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static bool DaLiPostojiOprema(string inventarskiBroj)
        {
            ISession s = null; 
            try
            {
                s = DataLayer.GetSession(); 
                return s.Query<Oprema>().Any(o => o.InventarskiBroj == inventarskiBroj);
            }
            catch (Exception)
            {
                return true;
            }
            finally
            { 
                if (s != null)
                {
                    s.Close(); 
                }
            }
        }

        #endregion

        #region Intervencija
        public static void ObrisiIntervenciju(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Intervencija i = s.Load<Intervencija>(id);
                s.Delete(i);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static IntervencijaBasic VratiIntervenciju(int id)
        {
            IntervencijaBasic iBasic = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Intervencija i = s.Load<Entiteti.Intervencija>(id);
                if (i != null)
                {
                    iBasic = new IntervencijaBasic
                    {
                        Id = i.Id,
                        BrojIntervencije = i.BrojIntervencije,
                        OpisSituacije = i.OpisSituacije,
                        Datum = i.Datum,
                        VremeOd = i.VremeOd,
                        VremeDo = i.VremeDo,
                        VremeDolaska = i.VremeDolaska,
                        TipIntervencije = i.TipIntervencije,
                        AdresaLokacije = i.AdresaLokacije,
                        IdDispecera = i.Dispecer?.Id,
                        IdStatusa = i.Status.Id,
                        AngazovaniVatrogasciIds = i.AngazovaniVatrogasciNaIntervenciji.Select(av => av.AngazovaniVatrogasacLice.Id).ToList(),
                        KoriscenaVozilaIds = new List<int>() 
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return iBasic;
        }
        public static List<IntervencijaPregled> VratiSveIntervencije()
        {
            List<IntervencijaPregled> intervencije = new List<IntervencijaPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<Intervencija> sveIntervencije = from i in s.Query<Intervencija>() select i;

                foreach (Intervencija i in sveIntervencije)
                {
                    intervencije.Add(new IntervencijaPregled(i.Id, i.BrojIntervencije, i.Datum, i.TipIntervencije, i.AdresaLokacije));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return intervencije;
        }
        public static void IzmeniIntervenciju(IntervencijaBasic iBasic, StatusIntervencijeBasic statusBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Intervencija i = s.Get<Intervencija>(iBasic.Id);

                if (i != null)
                {
                    i.BrojIntervencije = iBasic.BrojIntervencije;
                    i.OpisSituacije = iBasic.OpisSituacije;
                    i.Datum = iBasic.Datum;
                    i.VremeOd = iBasic.VremeOd;
                    i.VremeDo = iBasic.VremeDo;
                    i.VremeDolaska = iBasic.VremeDolaska;
                    i.TipIntervencije = iBasic.TipIntervencije;
                    i.AdresaLokacije = iBasic.AdresaLokacije;
                    i.Dispecer = iBasic.IdDispecera.HasValue ? s.Load<AngazovanoLice>(iBasic.IdDispecera.Value) : null;

                    if (i.Status != null)
                    {
                        i.Status.Datum = statusBasic.Datum;
                        i.Status.Vreme = statusBasic.Vreme;
                        i.Status.StanjeIntervencije = statusBasic.StanjeIntervencije;
                    }

                    s.Update(i);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void SacuvajIntervenciju(IntervencijaBasic iBasic, StatusIntervencijeBasic statusBasic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                StatusIntervencije noviStatus = new StatusIntervencije
                {
                    Datum = statusBasic.Datum,
                    Vreme = statusBasic.Vreme,
                    StanjeIntervencije = statusBasic.StanjeIntervencije
                };

                Intervencija i = new Intervencija
                {
                    BrojIntervencije = iBasic.BrojIntervencije,
                    OpisSituacije = iBasic.OpisSituacije,
                    Datum = iBasic.Datum,
                    VremeOd = iBasic.VremeOd,
                    VremeDo = iBasic.VremeDo,
                    VremeDolaska = iBasic.VremeDolaska,
                    TipIntervencije = iBasic.TipIntervencije,
                    AdresaLokacije = iBasic.AdresaLokacije,
                    Dispecer = iBasic.IdDispecera.HasValue ? s.Load<AngazovanoLice>(iBasic.IdDispecera.Value) : null,
                    Status = noviStatus
                };

                s.Save(i);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }

        #endregion

        #region StatusIntervencije
        public static StatusIntervencijeBasic VratiStatusIntervencije(int id)
        {
            StatusIntervencijeBasic siBasic = null;
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                StatusIntervencije si = s.Load<StatusIntervencije>(id);
                if (si != null)
                {
                    siBasic = new StatusIntervencijeBasic(si.Id, si.Vreme, si.Datum, si.StanjeIntervencije);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return siBasic;
        }

        #endregion

        #region AngazovanVatrogasac
        public static void DodajVatrogascaNaIntervenciju(AngazovanVatrogasacBasic basic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Intervencija intervencija = s.Load<Intervencija>(basic.IdIntervencije);
                AngazovanoLice vatrogasac = s.Load<AngazovanoLice>(basic.IdVatrogasca);

                Smena smena = s.Load<Smena>(basic.IdSmene);

                if (vatrogasac.FVatrogasac != 'T')
                {
                    throw new InvalidOperationException("Izabrano lice nije vatrogasac i ne moze biti dodato na intervenciju.");
                }

                AngazovanVatrogasac av = new AngazovanVatrogasac
                {
                    PripadaIntervenciji = intervencija,
                    AngazovaniVatrogasacLice = vatrogasac
                };
                s.Save(av);

                Ucestvuje ucesce = new Ucestvuje
                {
                    Intervencija = intervencija,
                    Vatrogasac = vatrogasac,
                    Smena = smena
                };
                s.Save(ucesce);

                bool radiUSmeni = s.Query<RadiUSmeni>().Any(rus => rus.Smena.Id == basic.IdSmene && rus.Radnik.Id == basic.IdVatrogasca);
                if (!radiUSmeni)
                {
                    RadiUSmeni novaVeza = new RadiUSmeni
                    {
                        Smena = smena,
                        Radnik = vatrogasac
                    };
                    s.Save(novaVeza);
                }

                int noviBrojIntervencija = IzracunajBrojIntervencijaZaVatrogasca(vatrogasac.Id, s);
                vatrogasac.BrojOperativnihIntervencija = noviBrojIntervencija;
                s.Update(vatrogasac);

                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<AngazovanVatrogasacPregled> VratiAngazovanjaZaIntervenciju(int intervencijaId)
        {
            List<AngazovanVatrogasacPregled> pregledi = new List<AngazovanVatrogasacPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var angazovanja = from av in s.Query<AngazovanVatrogasac>()
                                  where av.PripadaIntervenciji.Id == intervencijaId
                                  select av;

                foreach (var av in angazovanja)
                {
                    string vatrogasacInfo = "Nepoznat/Obrisan vatrogasac";
                    if (av.AngazovaniVatrogasacLice != null)
                    {
                        vatrogasacInfo = $"{av.AngazovaniVatrogasacLice.LicnoIme} {av.AngazovaniVatrogasacLice.Prezime}";
                    }

                    string intervencijaInfo = $"Br. {av.PripadaIntervenciji?.BrojIntervencije}";

                    pregledi.Add(new AngazovanVatrogasacPregled(av.Id, intervencijaInfo, vatrogasacInfo));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return pregledi;
        }
        public static void UkloniVatrogascaSaIntervencije(int idAngazmana)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                AngazovanVatrogasac av = s.Get<AngazovanVatrogasac>(idAngazmana);
                if (av != null)
                {
                    int idIntervencije = av.PripadaIntervenciji.Id;
                    int idVatrogasca = av.AngazovaniVatrogasacLice.Id;

                    AngazovanoLice vatrogasac = av.AngazovaniVatrogasacLice;

                    s.Delete(av);

                    var ucescaZaBrisanje = s.Query<Ucestvuje>()
                                            .Where(u => u.Intervencija.Id == idIntervencije && u.Vatrogasac.Id == idVatrogasca)
                                            .ToList();
                    foreach (var ucesce in ucescaZaBrisanje)
                    {
                        s.Delete(ucesce);
                    }

                    if (vatrogasac != null)
                    {
                        int noviBrojIntervencija = IzracunajBrojIntervencijaZaVatrogasca(idVatrogasca, s);
                        vatrogasac.BrojOperativnihIntervencija = noviBrojIntervencija;
                        s.Update(vatrogasac);
                    }

                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<VatrogasacPregled> VratiSveVatrogasce()
        {
            List<VatrogasacPregled> vatrogasci = new List<VatrogasacPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<AngazovanoLice> sviVatrogasci = from lice in s.Query<AngazovanoLice>()
                                                            where lice.FVatrogasac == 'T'
                                                            select lice;

                foreach (var v in sviVatrogasci)
                {
                    vatrogasci.Add(new VatrogasacPregled(v.Id, v.LicnoIme, v.Prezime));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return vatrogasci;
        }

        #endregion

        #region UpotrebljenoUIntervenciji
        public static void DodajResursNaIntervenciju(UpotrebljenoUIntervencijiBasic basic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                bool duplikatPostoji = false;

                if (basic.IdVozila.HasValue)
                {
                    duplikatPostoji = s.Query<UpotrebljenoUIntervenciji>()
                                       .Any(dup => dup.NaIntervenciji.Id == basic.IdIntervencije &&
                                                 dup.UpotrebljenoVozilo.Id == basic.IdVozila.Value);
                }
                else if (basic.IdOpreme.HasValue)
                {
                    duplikatPostoji = s.Query<UpotrebljenoUIntervenciji>()
                                       .Any(dup => dup.NaIntervenciji.Id == basic.IdIntervencije &&
                                                 dup.UpotrebljenaOprema.Id == basic.IdOpreme.Value);
                }

                if (duplikatPostoji)
                {
                    MessageBox.Show("Ovaj resurs je vec dodat na intervenciju.");
                    return;
                }
                UpotrebljenoUIntervenciji u = new UpotrebljenoUIntervenciji
                {
                    NaIntervenciji = s.Load<Intervencija>(basic.IdIntervencije),
                    UpotrebljenoVozilo = basic.IdVozila.HasValue ? s.Load<Vozilo>(basic.IdVozila.Value) : null,
                    UpotrebljenaOprema = basic.IdOpreme.HasValue ? s.Load<Oprema>(basic.IdOpreme.Value) : null
                };
                s.Save(u);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<UpotrebljenoUIntervencijiPregled> VratiUpotrebljeneResurse(int intervencijaId)
        {
            List<UpotrebljenoUIntervencijiPregled> pregledi = new List<UpotrebljenoUIntervencijiPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var upotrebljeni = from u in s.Query<UpotrebljenoUIntervenciji>()
                                   where u.NaIntervenciji.Id == intervencijaId
                                   select u;

                foreach (var u in upotrebljeni)
                {
                    string vozilo = u.UpotrebljenoVozilo?.RegistarskaOznaka ?? "---";
                    string oprema = u.UpotrebljenaOprema?.InventarskiBroj ?? "---";

                    pregledi.Add(new UpotrebljenoUIntervencijiPregled(u.Id, vozilo, oprema));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return pregledi;
        }
        public static void UkloniResursSaIntervencije(int idUpotrebe)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                UpotrebljenoUIntervenciji u = s.Load<UpotrebljenoUIntervenciji>(idUpotrebe);
                s.Delete(u);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }

        #endregion

        #region OdrzavaVozila 
        public static List<AngazovanoLicePregled> VratiSveTehnicareZaVozilo(int idVozila)
        {
            List<AngazovanoLicePregled> tehnicari = new List<AngazovanoLicePregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                IEnumerable<AngazovanoLice> zaduzeniTehnicari = s.Query<Odrzavanje>()
                                                                 .Where(o => o.Vozilo.Id == idVozila)
                                                                 .Select(o => o.Tehnicar);

                foreach (var al in zaduzeniTehnicari)
                {
                    tehnicari.Add(new AngazovanoLicePregled(al.Id, al.LicnoIme, al.Prezime, al.EmailAdresa, al.FVatrogasac, al.FDispecer, al.FTehnicar));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return tehnicari;
        }

        #endregion

        #region Komandir
        public static void PostaviUpravnika(int stanicaId, int upravnikId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stanica stanica = s.Get<Stanica>(stanicaId);
                AngazovanoLice noviUpravnik = s.Get<AngazovanoLice>(upravnikId);
                stanica.Upravnik = noviUpravnik;
                s.Update(stanica);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static void UkloniUpravnika(int stanicaId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Stanica stanica = s.Get<Stanica>(stanicaId);
                stanica.Upravnik = null;
                s.Update(stanica);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static AngazovanoLicePregled VratiUpravnikaStanice(int stanicaId)
        {
            AngazovanoLicePregled upravnik = null;
            try
            {
                ISession s = DataLayer.GetSession();
                Stanica stanica = s.Get<Stanica>(stanicaId);

                if (stanica != null && stanica.Upravnik != null)
                {
                    var u = stanica.Upravnik;
                    upravnik = new AngazovanoLicePregled(u.Id, u.LicnoIme, u.Prezime, u.EmailAdresa, u.FVatrogasac, u.FDispecer, u.FTehnicar);
                }
                s.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return upravnik;
        }
        #endregion

        #region Ucestvuje
        public static List<IntervencijaPregled> VratiIntervencijeZaSmenu(int smenaId)
        {
            List<IntervencijaPregled> intervencije = new List<IntervencijaPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                List<int> radniciUSmeniIds = s.Query<RadiUSmeni>()
                                              .Where(rus => rus.Smena.Id == smenaId)
                                              .Select(rus => rus.Radnik.Id)
                                              .ToList();

                if (radniciUSmeniIds.Count == 0)
                {
                    return intervencije;
                }

                List<Intervencija> intervencijeZaSmenu = s.Query<Ucestvuje>()
                    .Where(u => u.Vatrogasac != null && radniciUSmeniIds.Contains(u.Vatrogasac.Id))
                    .Select(u => u.Intervencija)
                    .Distinct()
                    .ToList();

                foreach (var i in intervencijeZaSmenu)
                {
                    intervencije.Add(new IntervencijaPregled(i.Id, i.BrojIntervencije, i.Datum, i.TipIntervencije, i.AdresaLokacije));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return intervencije;
        }
        #endregion

        #region Telefon
        public static void DodajTelefon(TelefonBasic basic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Telefon tel = new Telefon
                {
                    BrojTelefona = basic.BrojTelefona
                };

                if (basic.IdLica.HasValue)
                {
                    tel.PripadaLicu = s.Load<AngazovanoLice>(basic.IdLica.Value);
                }
                else if (basic.IdVolontera.HasValue)
                {
                    tel.PripadaVolonteru = s.Load<Volonter>(basic.IdVolontera.Value);
                }
                else
                {
                    throw new InvalidOperationException("Telefon mora biti dodeljen ili licu ili volonteru.");
                }

                s.Save(tel);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void ObrisiTelefon(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Telefon tel = s.Load<Telefon>(id);
                s.Delete(tel);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<TelefonPregled> VratiTelefoneZaLice(int idLica)
        {
            List<TelefonPregled> pregledi = new List<TelefonPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var telefoni = from tel in s.Query<Telefon>()
                               where tel.PripadaLicu.Id == idLica
                               select tel;

                foreach (var t in telefoni)
                {
                    pregledi.Add(new TelefonPregled(t.Id, t.BrojTelefona));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return pregledi;
        }
        public static List<TelefonPregled> VratiTelefoneZaVolontera(int idVolontera)
        {
            List<TelefonPregled> pregledi = new List<TelefonPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var telefoni = from tel in s.Query<Telefon>()
                               where tel.PripadaVolonteru.Id == idVolontera
                               select tel;

                foreach (var t in telefoni)
                {
                    pregledi.Add(new TelefonPregled(t.Id, t.BrojTelefona));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return pregledi;
        }

        #endregion

        #region Sertifikat
        public static void DodajSertifikatVozilu(SertifikatBasic basic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Sertifikat cert = new Sertifikat
                {
                    NazivSertifikata = basic.NazivSertifikata,
                    PripadaVozilu = s.Load<Vozilo>(basic.IdVozila)
                };

                s.Save(cert);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static void ObrisiSertifikat(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Sertifikat cert = s.Load<Sertifikat>(id);
                s.Delete(cert);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        public static List<SertifikatPregled> VratiSertifikateZaVozilo(int idVozila)
        {
            List<SertifikatPregled> pregledi = new List<SertifikatPregled>();
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                var sertifikati = from cert in s.Query<Sertifikat>()
                                  where cert.PripadaVozilu.Id == idVozila
                                  select cert;

                foreach (var cert in sertifikati)
                {
                    pregledi.Add(new SertifikatPregled(cert.Id, cert.NazivSertifikata));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
            return pregledi;
        }
        public static void IzmeniSertifikat(SertifikatBasic basic)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();
                Sertifikat cert = s.Load<Sertifikat>(basic.Id);
                cert.NazivSertifikata = basic.NazivSertifikata;
                s.Update(cert);
                s.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (s != null && s.IsOpen)
                {
                    s.Close();
                }
            }
        }
        #endregion
    }
}

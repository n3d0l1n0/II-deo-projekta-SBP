using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class PonavljanjeMapiranje : ClassMap<Ponavljanje>
    {
        public PonavljanjeMapiranje()
        {
            Table("PONAVLJANJE");
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.BrojSmena, "BROJ_SMENA");
            Map(x => x.Mesec, "MESEC");
            References(x => x.Dispecer, "ID_DISPECERA");
        }
    }
}

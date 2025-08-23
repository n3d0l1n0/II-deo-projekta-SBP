using FluentNHibernate.Mapping;
using II_deo_projekta_baze_19406.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II_deo_projekta_baze_19406.Mapiranja
{
    public class OpremaMapiranje : ClassMap<Oprema>
    {
        public OpremaMapiranje()
        {
            Table("OPREMA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.InventarskiBroj, "INVENTARSKI_BROJ").Unique();
            Map(x => x.DatumNabavke, "DATUM_NABAVKE");
            Map(x => x.StatusOpreme, "STATUS_OPREME");
            Map(x => x.FZastitna, "FZASTITNA");
            Map(x => x.TipZastitna, "TIP_ZASTITNA");
            Map(x => x.FZaPozare, "FZA_POZARE");
            Map(x => x.TipZaPozare, "TIP_ZA_POZARE");
            Map(x => x.FSpecijalna, "FSPECIJALNA");
            Map(x => x.TipSpecijalna, "TIP_SPECIJALNA");
            Map(x => x.FTehnicka, "FTEHNICKA");
            Map(x => x.TipTehnicka, "TIP_TEHNICKA");
            References(x => x.PripadaVozilu, "ID_VOZILA").Nullable();
            References(x => x.PripadaStanici, "ID_STANICE").Nullable();
            References(x => x.PripadaLicu, "ID_LICA").Nullable();
            HasMany(x => x.UpotrebaUIntervencijama).KeyColumn("ID_OPREME").LazyLoad().Cascade.All().Inverse();
        }
    }
}

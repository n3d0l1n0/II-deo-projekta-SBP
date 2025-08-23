using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using II_deo_projekta_baze_19406.Mapiranja;
using System.Windows.Forms;

namespace II_deo_projekta_baze_19406
{
    class DataLayer
    {
        private static ISessionFactory _sessionFactory;
        private static object objLock = new object();

        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                lock (objLock)
                {
                    if (_sessionFactory == null)
                        _sessionFactory = CreateSessionFactory();
                }
            }
            return _sessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10.ConnectionString(c => c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19406;Password=n3d0l1n0;")); // Proverite connection string!

                return Fluently.Configure().Database(cfg).ExposeConfiguration(config => {config.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");

                        config.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
                    })
                    .Mappings(m => {m.FluentMappings.AddFromAssemblyOf<StanicaMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<AngazovanoLiceMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<AngazovanVatrogasacMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<IntervencijaMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<OdrzavanjeMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<OpremaMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<PonavljanjeMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<RadiUSmeniMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<SertifikatMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<ServisVozilaMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<SmenaMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<StatusIntervencijeMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<TelefonMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<UcestvujeMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<UpotrebljenoUIntervencijiMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<VolonterMapiranje>();
                        m.FluentMappings.AddFromAssemblyOf<VoziloMapiranje>();
                    })
                        .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}

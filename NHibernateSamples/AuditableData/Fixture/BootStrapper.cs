using AuditableData.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Envers.Configuration;
using NHibernate.Envers.Strategy;
using NHibernate.Tool.hbm2ddl;
using System;

namespace AuditableData.Fixture
{
    public static class BootStrapper
    {
        private static ISessionFactory sessionFactory;//It should be single across threads. It's thread safe. :)

        static BootStrapper()
        {
            sessionFactory = GetSessionFactory();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                return BootStrapper.SessionFactory;
            }
        }

        private static ISessionFactory GetSessionFactory()
        {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MotorDb.mdf;Integrated Security=True";
            var configuration = BootStrapper.BootStrap(
                MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql(),
                BuildSchema);

            return configuration.BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(true, false);
        }

        private static FluentConfiguration BootStrap(IPersistenceConfigurer configurer, Action<Configuration> cfgAction)
        {
            return Fluently.Configure()
                .Database(configurer)
                .Mappings(m => 
                {
                        m.FluentMappings.AddFromAssemblyOf<Manufacturer>();
                })
                .ExposeConfiguration(cfg =>
                {
                    cfg.SetEnversProperty(ConfigurationKey.AuditStrategy, typeof(ValidityAuditStrategy));
                    //cfg.SetEnversProperty(ConfigurationKey.StoreDataAtDelete, true);
                    cfg.IntegrateWithEnvers();
                    cfgAction(cfg);
                });
        }
    }
}
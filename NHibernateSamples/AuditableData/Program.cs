using AuditableData.Fixture;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditableData
{
    class Program
    {
        static void Main(string[] args)
        {
            ISessionFactory sessionFactory = BootStrapper.GetSessionFactory();
        }
    }
}

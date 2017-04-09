using AuditableData.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditableData.Mappers
{
    public class ManufacturerMap  : ClassMap<Manufacturer>
    {
        public ManufacturerMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}

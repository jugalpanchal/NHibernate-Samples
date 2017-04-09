using AuditableData.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditableData.Mappers
{
    public class VariantMap  : ClassMap<Variant>
    {
        public VariantMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}

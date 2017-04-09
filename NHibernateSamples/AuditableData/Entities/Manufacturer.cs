using NHibernate.Envers.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditableData.Entities
{
    [Audited]
    public class Manufacturer
    {
        public virtual int Id { get; protected set; }
        public virtual String Name { get; protected set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._1_DecoratorCompositeAdapter
{
    public sealed class DomainUser
    {
        public int Id { get; set; }

        public DateTimeOffset LastActivity { get; set; }
    }
}

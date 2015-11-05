using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace Homework
{
    public partial class Employee
    {
        public EntitySet<Territory> TerritoryProperty
        {
            get
            {
                EntitySet<Territory> territory = new EntitySet<Territory>();
                territory.AddRange(this.Territories);
                return territory;
            }
        }
    }
}

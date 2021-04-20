using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{


    /// <summary>
    /// This the base class for Customers.
    /// For this program, it will not be inherited,
    /// but future we might have different type of
    /// customers (business, special, etc.) in which case
    /// it will be inherited.
    /// It is a DbSet, and will be referenced by the
    /// Orders DbSets.
    /// </summary>
    public partial class Acustomer
    {
        public Acustomer()
        {
            Aorders = new HashSet<Aorder>();
        }

        public int AcustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Aorder> Aorders { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{

    /// <summary>
    /// This the base class for Stores.
    /// It will be the base class for our stores such as
    /// Pittsburgh, Tampa Bay, and other future stores.
    /// It is a DbSet, and will be referenced by the
    /// Orders DbSet.
    /// </summary>
    public partial class Astore
    {
        public Astore()
        {
            Aorders = new HashSet<Aorder>();
        }

        public int AstoreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Aorder> Aorders { get; set; }
    }
}

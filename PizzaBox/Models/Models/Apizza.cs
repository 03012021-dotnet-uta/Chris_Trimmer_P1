using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{

    /// <summary>
    /// This the base class for Pizzas.
    /// It will be the base class for pre-configured
    /// pizzas, such as cheese, meat-lover's, etc.
    /// It is a DbSet, and will be referenced by the
    /// Components and Orders DbSets.
    /// </summary>
    public partial class Apizza
    {
        public Apizza()
        {
            Acomponents = new HashSet<Acomponent>();
            Aorders = new HashSet<Aorder>();
        }

        public int ApizzaId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Acomponent> Acomponents { get; set; }
        public virtual ICollection<Aorder> Aorders { get; set; }
    }
}

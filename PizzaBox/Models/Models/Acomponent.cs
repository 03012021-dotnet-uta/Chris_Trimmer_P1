using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{


    /// <summary>
    /// This the base class for Components.
    /// It will be the base class for the toppings,
    /// crust, and sizes.
    /// It is a DbSet, and it will reference the pizza
    /// that is part of an order.
    /// </summary>
    public partial class Acomponent
    {
        public int AcomponentId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int PizzaId { get; set; }

        public virtual Apizza Pizza { get; set; }
    }
}

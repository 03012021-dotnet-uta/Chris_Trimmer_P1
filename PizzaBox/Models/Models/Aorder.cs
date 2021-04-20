using System;
using System.Collections.Generic;
using Models.Models;

#nullable disable

namespace Models.Models
{

    /// <summary>
    /// This the base class for orders.
    /// For this program, no other classes inherit from this.
    /// It is a DbSet, and it is a junction table
    /// that references the Customer, Pizza, and Store
    /// from an Order.
    /// </summary>
    public partial class Aorder
    {
        public int AorderId { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public int StoreId { get; set; }

        public virtual Acustomer Customer { get; set; }
        public virtual Apizza Pizza { get; set; }
        public virtual Astore Store { get; set; }
    }
}

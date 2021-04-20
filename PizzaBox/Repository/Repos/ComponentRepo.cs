using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Models;
using Models.Models;

namespace Repository.Repos
{

    /// <summary>
    /// This is the repository implementation for Components.
    /// It is implemented from the Pizza Interface, and
    /// performs the CRUD operations on context.
    /// It is used by Business Logic to interface with 
    /// logic of program.
    /// </summary>
    public class ComponentRepository : IComponentRepository
    {
        public readonly PizzaBoxContext context;
        public ComponentRepository()
        {
            context = new PizzaBoxContext();
        }

        public ComponentRepository(PizzaBoxContext pizzaBoxContext)
        {
            context = pizzaBoxContext;
        }

        public List<Acomponent> GetAll()
        {
            return context.Acomponents.ToList();
        }

        public Acomponent GetComponent(int componentId)
        {
            return context.Acomponents.Find(componentId);
        }

        public void Insert(Acomponent component)
        {
            context.Acomponents.Add(component);
        }

        public void Update(Acomponent component)
        {
            context.Entry(component).State = EntityState.Modified;
        }

        public void Delete(int orderId)
        {
            var order = context.Aorders.Find(orderId);
            context.Entry(order).State = EntityState.Deleted;
            context.Aorders.Remove(order);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

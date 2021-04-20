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
    /// This is the repository implementation for Pizzas.
    /// It is implemented from the Pizza Interface, and
    /// performs the CRUD operations on context.
    /// It is used by Business Logic to interface with 
    /// logic of program.
    /// </summary>
    public class PizzaRepository : IPizzaRepository
    {
        public readonly PizzaBoxContext context;
        public PizzaRepository()
        {
            context = new PizzaBoxContext();
        }

        public PizzaRepository(PizzaBoxContext pizzaBoxContent)
        {
            context = pizzaBoxContent;
        }

        public List<Apizza> GetAll()
        {
            return context.Apizzas.ToList();
        }

        public Apizza GetPizza(int pizzaId)
        {
            return context.Apizzas.Find(pizzaId);
        }

        public void Insert(Apizza pizza)
        {
            context.Apizzas.Add(pizza);
        }

        public void Update(Apizza pizza)
        {
            context.Entry(pizza).State = EntityState.Modified;
        }

        public void Delete(int pizzaId)
        {
            Apizza pizza = context.Apizzas.Find(pizzaId);
            context.Entry(pizza).State = EntityState.Deleted;
            context.Apizzas.Remove(pizza);
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

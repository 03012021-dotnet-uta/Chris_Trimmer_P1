using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Interfaces;
using Models;
using Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{

    /// <summary>
    /// This is the repository implementation for Stores.
    /// It is implemented from the Pizza Interface, and
    /// performs the CRUD operations on context.
    /// It is used by Business Logic to interface with 
    /// logic of program.
    /// </summary>
    public class StoreRepository : IStoreRepository
    {
        public readonly PizzaBoxContext context;
        public StoreRepository()
        {
            context = new PizzaBoxContext();
        }

        public StoreRepository(PizzaBoxContext pizzaBoxContext)
        {
            context = pizzaBoxContext;
        }

        public List<Astore> GetAll()
        {
            return context.Astores.ToList();
        }

        public Astore GetStore(int storeId)
        {
            return context.Astores.Find(storeId);
        }

        public void Update(Astore store)
        {
            context.Entry(store).State = EntityState.Modified;
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

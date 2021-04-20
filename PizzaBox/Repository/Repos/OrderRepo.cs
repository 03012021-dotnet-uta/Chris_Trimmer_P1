using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repos
{

    /// <summary>
    /// This is the repository implementation for Orders.
    /// It is implemented from the Pizza Interface, and
    /// performs the CRUD operations on context.
    /// It is used by Business Logic to interface with 
    /// logic of program.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {


        public readonly PizzaBoxContext context;
        public OrderRepository()
        {
            context = new PizzaBoxContext();
        }

        public OrderRepository(PizzaBoxContext pizzaBoxContext)
        {
            context = pizzaBoxContext;
        }

        public List<Aorder> GetAll()
        {
            return context.Aorders.ToList();
        }

        public Aorder GetOrder(int orderId)
        {
            return context.Aorders.Find(orderId);
        }

        public void Insert(Aorder order)
        {
            var ord = new Aorder()
            {
                StoreId = order.StoreId,
                CustomerId = order.CustomerId
            };
            context.Aorders.Add(order);
        }

        public void Update(Aorder order)
        {
            context.Entry(order).State = EntityState.Deleted;
        }

        public void Delete(int orderId)
        {
            Aorder order = context.Aorders.Find(orderId);
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

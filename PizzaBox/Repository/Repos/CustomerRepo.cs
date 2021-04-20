using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Models;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{

    /// <summary>
    /// This is the customer repo.  It implements the ICustomer
    /// interface.  It is used by the Business Logic to inteface
    /// with the context.
    /// </summary>
    public class CustomerRepo : ICustomerRepository
    {
        public readonly PizzaBoxContext context;

        public CustomerRepo()
        {
            context = new PizzaBoxContext();
        }

        public CustomerRepo(PizzaBoxContext pizzaBoxContext)
        {
            context = pizzaBoxContext;
        }


        public ICollection<Acustomer> GetAll()
        {
            return context.Acustomers.ToList();
        }

        public Acustomer GetCustomer(int customerId)
        {
            return context.Acustomers.Find(customerId);
        }


        public Acustomer GetCustomer(Acustomer customer)
        {
            var test = context.Acustomers.FirstOrDefault(p => p.Name == customer.Name);

            if (test == null)
            {
                Acustomer newCustomer = new Acustomer()
                {
                    Name = "newCustomer",
                };

                return newCustomer;
            }
            else
            {
                return test;
            }
        }

        public void Insert(Acustomer customer)
        {
            context.Acustomers.Add(customer);
        }

        public void Update(Acustomer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void Delete(int customerId)
        {
            Acustomer customer = context.Acustomers.Find(customerId);
            context.Entry(customer).State = EntityState.Deleted;
            context.Acustomers.Remove(customer);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Models;
using Repository.Interfaces;
using Repository.Repos;
//// error getting this - tried adding package still not working
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{

    /// <summary>
    /// Order Logic class is designed to setup the ability to
    /// cross reference an order with customer, pizza, and store.
    /// It instantiates the Customer, Pizza, and Store Repo interface
    /// and then uses that access the context.
    /// </summary>
    public class OrderLogic
    {

        // declare the Repos that this class will use
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IStoreRepository storeRepository;
        private readonly IPizzaRepository pizzaRepository;
        private readonly IComponentRepository componentRepository;


        // default constructor we will get context for each repo/DbSet
        public OrderLogic()
        {
            customerRepository = new CustomerRepo(new PizzaBoxContext());
            orderRepository = new OrderRepository(new PizzaBoxContext());
            storeRepository = new StoreRepository(new PizzaBoxContext());
            pizzaRepository = new PizzaRepository(new PizzaBoxContext());
            componentRepository = new ComponentRepository(new PizzaBoxContext());
        }


        #region GetAll Functions
        /// <summary>
        /// The following functions are used to
        /// get all records from each respective DbSet:
        /// Customers, Pizzas, Stores, Orders, and Components
        /// </summary>

        //[HttpGet]
        public IEnumerable<Acustomer> GetAllCustomers()
        {
            var customers = customerRepository.GetAll();
            return customers;
        }

        //[HttpGet]
        public IEnumerable<Apizza> GetAllPizzas()
        {
            var pizzas = pizzaRepository.GetAll();
            return pizzas;
        }

        //[HttpGet]
        public IEnumerable<Aorder> GetAllOrders()
        {
            var orders = orderRepository.GetAll();
            return orders;
        }

        //[HttpGet]
        public IEnumerable<Astore> GetAllStores()
        {
            var stores = storeRepository.GetAll();
            return stores;
        }

        //[HttpGet]
        public IEnumerable<Acomponent> GetAllComponents()
        {
            var components = componentRepository.GetAll();
            return components;
        }
        #endregion End of GetAll Functions


        #region Get Single Functions
        /// <summary>
        /// These functions are used to get a single object from
        /// the respective repo: Store, Pizza, Order, Customer,
        /// and Component
        /// </summary>

        //[HttpGet]
        public Acustomer GetCustomer(Acustomer customerId)
        {
            var customer = customerRepository.GetCustomer(customerId);
            return customer;
        }

        //[HttpGet]
        public Apizza GetPizza(int pizzaId)
        {
            var pizza = pizzaRepository.GetPizza(pizzaId);
            return pizza;
        }

        //[HttpGet]
        public Aorder order(int orderId)
        {
            var order = orderRepository.GetOrder(orderId);
            return order;
        }

        //[HttpGet]
        public Astore GetStore(int storeId)
        {
            var store = storeRepository.GetStore(storeId);
            return store;
        }

        //[HttpGet]
        public Acomponent GetComponent(int componentId)
        {
            var component = componentRepository.GetComponent(componentId);
            return component;
        }
        #endregion End of Get Region


        #region Various CRUD functions

        /// <summary>
        /// These are various CRUD functions for the DbSets.
        /// Note that the Read functions are above in the Get 
        /// and GetAll regions
        /// </summary>
        /// 

        // Add an order
        public Aorder AddOrder(Aorder order)
        {
            orderRepository.Insert(order);
            orderRepository.Save();
            return order;
        }

        // Add a customer
        public Acustomer AddCustomer(Acustomer customer)
        {
            customerRepository.Insert(customer);
            customerRepository.Save();
            return customer;
        }

        // Delete a customer
        public void DeleteCustomer(int customerId)
        {
            customerRepository.Delete(customerId);
            customerRepository.Save();
        }

        // Update a Pizza
        public void Update(Apizza pizza)
        {
            pizzaRepository.Update(pizza);
            pizzaRepository.Save();
        }

        // Delete a Pizza
        public void Delete(int pizzaId)
        {
            pizzaRepository.Delete(pizzaId);
            pizzaRepository.Save();
        }

        // Add a Pizza
        public Apizza AddPizza(Apizza pizza)
        {
            pizzaRepository.Insert(pizza);
            pizzaRepository.Save();
            return pizza;
        }

        // Add a Component
        public Acomponent AddComponent(Acomponent component)
        {
            componentRepository.Insert(component);
            componentRepository.Save();
            return component;
        }
        #endregion End of Various CRUD operations

    }
}

using System.Collections.Generic;
using Models.Models;


namespace Repository.Interfaces
{
    /// <summary>
    /// This is the interface of for Pizzas
    /// It includes the main functions that business logic
    /// will use to interface with Repo and context
    /// </summary>
    public interface IPizzaRepository
    {
        List<Apizza> GetAll();
        Apizza GetPizza(int pizzaId);

        void Insert(Apizza customer);

        void Update(Apizza customer);

        void Delete(int customerId);

        void Save();
    }
}
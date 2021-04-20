using System.Collections.Generic;
using Models.Models;

namespace Repository.Interfaces
{
    /// <summary>
    /// This is the interface of for Orders
    /// It includes the main functions that business logic
    /// will use to interface with Repo and context
    /// </summary>
    public interface IOrderRepository
    {
        List<Aorder> GetAll();
        Aorder GetOrder(int orderId);

        void Insert(Aorder order);

        void Update(Aorder order);

        void Delete(int orderId);
        void Save();

    }
}
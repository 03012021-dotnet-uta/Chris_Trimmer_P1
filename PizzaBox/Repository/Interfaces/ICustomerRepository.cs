using System.Collections.Generic;
using Models.Models;


namespace Repository.Interfaces
{
    /// <summary>
    /// This is the interface of for Customer
    /// It includes the main functions that business logic
    /// will use to interface with Repo and context
    /// </summary>
    public interface ICustomerRepository
    {
        ICollection<Acustomer> GetAll();

        Acustomer GetCustomer(int customerId);

        Acustomer GetCustomer(Acustomer customer);

        void Insert(Acustomer customer);

        void Update(Acustomer customer);

        void Delete(int customerId);

        void Save();

    }
}

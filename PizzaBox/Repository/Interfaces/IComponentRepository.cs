using System.Collections.Generic;
using Models.Models;

namespace Repository.Interfaces
{
    /// <summary>
    /// This is the interface of for Components
    /// It includes the main functions that business logic
    /// will use to interface with Repo and context
    /// </summary>
    public interface IComponentRepository
    {
        List<Acomponent> GetAll();
        Acomponent GetComponent(int componentId);

        void Insert(Acomponent component);

        void Update(Acomponent component);

        void Delete(int orderId);

        void Save();

    }
}
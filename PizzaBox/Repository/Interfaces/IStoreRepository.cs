using System.Collections.Generic;
using Models.Models;

namespace Repository.Interfaces
{
    /// <summary>
    /// This is the interface of for Stores
    /// It includes the main functions that business logic
    /// will use to interface with Repo and context
    /// </summary>
    public interface IStoreRepository
    {
        List<Astore> GetAll();

        Astore GetStore(int storeId);

        void Update(Astore store);


        void Save();

    }
}
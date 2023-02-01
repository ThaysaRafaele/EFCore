using EFCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<IEnumerable<Client>> GetAllClients(bool includeOrder = false);
        Task<Client> GetClientById(int id);
        Task<Client[]> GetClientByName(string name);

        Task<IEnumerable<Order>> GetAllOrders(bool includeItems = false);
        Task<Order> GetOrderById(int id, bool includeItems = false);
        Task<Order[]> GetOrderByNumber(int number);
    }
}

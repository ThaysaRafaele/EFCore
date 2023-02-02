using EFCore.Domain.Entities;
using EFCore.Domain.Contracts.Repositories.Shared;

namespace EFCore.Domain.Contracts.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
    Task<List<Client>> GetAllClients();
    Task<Client> GetClientById(int id);
    Task<List<Client>> GetClientByName(string name);
}

using EFCore.Application.Dtos.Client;


namespace EFCore.Application.Contracts.Services;

public interface IClientService
{ 
    Task CreateClientAsync(CreateClienteDto newClient);
    Task<List<ClientDto>> GetAllAsync();
    Task<ClientDto> GetByIdAsync(int id);
    Task<List<ClientDto>> GetByNameAsync(string name);
    Task UpdateClientAsync(UpdateClienteDto newClient);
    Task DeleteClientAsync(int id);
}

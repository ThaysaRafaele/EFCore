using AutoMapper;
using EFCore.Application.Contracts.Services;
using EFCore.Application.Dtos.Client;
using EFCore.Data.Repositories;
using EFCore.Domain.Contracts.Repositories;
using EFCore.Domain.Entities;

namespace EFCore.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    public ClientService(IClientRepository clientRepository,
                              IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }
    public async Task<List<ClientDto>> GetAllAsync()
    {
        try
        {
            var clients = await _clientRepository.GetAllClients();
            var clientsDto = _mapper.Map<List<ClientDto>>(clients);

            return clientsDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ClientDto> GetByIdAsync(int id)
    {
        try
        {
            var client = await _clientRepository.GetClientById(id);
            var clientsDto = _mapper.Map<ClientDto>(client);

            return clientsDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<List<ClientDto>> GetByNameAsync(string name)
    {
        try
        {
            var clients = await _clientRepository.GetClientByName(name);
            var clientsDto = _mapper.Map<List<ClientDto>>(clients);

            return clientsDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task CreateClientAsync(CreateClienteDto newClient)
    {
        try
        {
            var client = _mapper.Map<Client>(newClient);
            _clientRepository.Add(client);
            await _clientRepository.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateClientAsync(UpdateClienteDto newClient)
    {
        try
        {
            var client = await _clientRepository.GetByIdAsync(newClient.Id);
            newClient.Id = client.Id;

            if (client is null) throw new Exception("Registro não encontrado");

            _mapper.Map(newClient, client);
            _clientRepository.Update(client);
            await _clientRepository.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteClientAsync(int id)
    {
        try
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client is null) throw new Exception("Registro não encontrado");

            _clientRepository.Delete(client);
            await _clientRepository.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}

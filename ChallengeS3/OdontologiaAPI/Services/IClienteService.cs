using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OdontologiaAPI.Models;
using OdontologiaAPI.Repositories;

namespace OdontologiaAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            // Adicione validações adicionais aqui, se necessário
            if (!ValidateCliente(cliente))
            {
                throw new ArgumentException("Cliente inválido");
            }
            return await _repository.CreateAsync(cliente);
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            if (!ValidateCliente(cliente))
            {
                throw new ArgumentException("Cliente inválido");
            }
            return await _repository.UpdateAsync(cliente);
        }

        public async Task<bool> DeleteClienteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        private bool ValidateCliente(Cliente cliente)
        {
            // Implemente validações adicionais aqui
            return !string.IsNullOrEmpty(cliente.Email) && !string.IsNullOrEmpty(cliente.NomeCompleto);
        }
    }
}
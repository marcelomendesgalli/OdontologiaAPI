using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using OdontologiaAPI.Models;

namespace OdontologiaAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection");
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var clientes = new List<Cliente>();
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM clientes";
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(MapReaderToCliente(reader));
                        }
                    }
                }
            }
            return clientes;
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM clientes WHERE id = :p_id";
                    cmd.Parameters.Add(new OracleParameter("p_id", OracleDbType.Raw)).Value = id.ToByteArray();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToCliente(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BEGIN inserir_cliente(:p_email, :p_numero_telefone, :p_data_nascimento, :p_nome_completo, :p_senha, :p_usuario, :p_endereco_id); END;";
                    cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = cliente.Email;
                    cmd.Parameters.Add("p_numero_telefone", OracleDbType.Varchar2).Value = cliente.NumeroTelefone;
                    cmd.Parameters.Add("p_data_nascimento", OracleDbType.Date).Value = cliente.DataNascimento;
                    cmd.Parameters.Add("p_nome_completo", OracleDbType.Varchar2).Value = cliente.NomeCompleto;
                    cmd.Parameters.Add("p_senha", OracleDbType.Varchar2).Value = cliente.Senha;
                    cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = cliente.Usuario;
                    cmd.Parameters.Add("p_endereco_id", OracleDbType.Raw).Value = cliente.EnderecoId.ToByteArray();

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return cliente;
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BEGIN atualizar_cliente(:p_id, :p_email, :p_numero_telefone, :p_data_nascimento, :p_nome_completo, :p_senha, :p_usuario, :p_endereco_id); END;";
                    cmd.Parameters.Add("p_id", OracleDbType.Raw).Value = cliente.Id.ToByteArray();
                    cmd.Parameters.Add("p_email", OracleDbType.Varchar2).Value = cliente.Email;
                    cmd.Parameters.Add("p_numero_telefone", OracleDbType.Varchar2).Value = cliente.NumeroTelefone;
                    cmd.Parameters.Add("p_data_nascimento", OracleDbType.Date).Value = cliente.DataNascimento;
                    cmd.Parameters.Add("p_nome_completo", OracleDbType.Varchar2).Value = cliente.NomeCompleto;
                    cmd.Parameters.Add("p_senha", OracleDbType.Varchar2).Value = cliente.Senha;
                    cmd.Parameters.Add("p_usuario", OracleDbType.Varchar2).Value = cliente.Usuario;
                    cmd.Parameters.Add("p_endereco_id", OracleDbType.Raw).Value = cliente.EnderecoId.ToByteArray();

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return cliente;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BEGIN deletar_cliente(:p_id); END;";
                    cmd.Parameters.Add("p_id", OracleDbType.Raw).Value = id.ToByteArray();

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return true;
        }

        private Cliente MapReaderToCliente(OracleDataReader reader)
        {
            return new Cliente
            {
                Id = new Guid((byte[])reader["ID"]),
                Email = reader["EMAIL"].ToString(),
                NumeroTelefone = reader["NUMERO_TELEFONE"].ToString(),
                DataNascimento = Convert.ToDateTime(reader["DATA_NASCIMENTO"]),
                NomeCompleto = reader["NOME_COMPLETO"].ToString(),
                Usuario = reader["USUARIO"].ToString(),
                EnderecoId = new Guid((byte[])reader["ENDERECO_ID"])
            };
        }
    }
}
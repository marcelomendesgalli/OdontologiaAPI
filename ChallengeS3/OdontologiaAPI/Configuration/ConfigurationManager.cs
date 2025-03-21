using Microsoft.Extensions.Configuration;

namespace OdontologiaAPI.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("OracleConnection");
        }

// Adicione outros métodos conforme necessário
    }

    public interface IConfigurationManager
    {
        string GetConnectionString();
    }
}
using Microsoft.Extensions.Configuration;

namespace TestAssignmentVM_Melnyk_Mykhailo
{
    public class ConfigurationReader : IConfigurationReader
    {
        private readonly IConfiguration _configuration;
        private const string  CONNECTION_STRING = "ConnectionString";
        public ConfigurationReader()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "config.json")).Build();
        }

        public string GetConnectionString()
        {
            try
            {
                var connectionString = _configuration.GetSection(CONNECTION_STRING).Value;

                if (string.IsNullOrEmpty(connectionString))
                {
                    MessageSpecifier.PrintErrorMessage("ERROR: Connection string is empty or null");
                    Environment.Exit(-1);
                }
                
                return connectionString;
            }
            catch(Exception ex)
            {
                MessageSpecifier.PrintErrorMessage(ex.Message);
                Environment.Exit(-1);
                return null;
            }
        }

        public IDictionary<string, string> GetParameters()
        {
            try
            {
                var parameters = _configuration.GetChildren().Where(x => x.Key != CONNECTION_STRING);

                if (!parameters.Any())
                {
                    MessageSpecifier.PrintWarnMessage("WARN: There are no other parameters, except connection string");
                    return new Dictionary<string, string>();
                }

                return parameters.ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception ex)
            {
                MessageSpecifier.PrintErrorMessage(ex.Message);
                Environment.Exit(-1);
                return null;
            }
        }
    }
}

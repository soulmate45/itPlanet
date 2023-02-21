using Newtonsoft.Json;

namespace itPlanet.configs;

public class ConfigStructure
{
    [JsonProperty("server")]
    public ServerConfig? Server;
    [JsonProperty("database")]
    public DatabaseConfig? Database;
    
    public ConfigStructure()
    {
        Server = null;
        Database = null;
    }
    
}
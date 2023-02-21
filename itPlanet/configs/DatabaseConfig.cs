using Newtonsoft.Json;

namespace itPlanet.configs;

public class DatabaseConfig
{
    [JsonProperty("host")] public string Host = "";
    [JsonProperty("username")] public string Username = "";
    [JsonProperty("password")] public string Password = "";
    [JsonProperty("database")] public string Database = "";

    
}
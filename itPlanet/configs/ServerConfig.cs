using Newtonsoft.Json;
namespace itPlanet.configs;


public class ServerConfig
{
    [JsonProperty("port")] 
    public int Port;
}
using it_planet.repository.postgres;

namespace itPlanet.repository.postgres.queries.animalType;

public class PostgresAnimalType
{
    [PostgresName("id")]
    public long Id { get; set; }
    
    [PostgresName("value")]
    
    public string Value { get; set; } 
}
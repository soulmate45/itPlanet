using itPlanet.repository.postgres.queries.animalType;

namespace itPlanet.repository.animalType;

public interface IAnimalType
{
    public PostgresAnimalType Create(string value);
}
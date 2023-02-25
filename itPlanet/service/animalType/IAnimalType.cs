using itPlanet.models.animalType;
using itPlanet.repository.postgres.queries.animalType;

namespace itPlanet.service.animalType;

public interface IAnimalType
{
    public PostgresAnimalType Create(CreateAnimalTypeInput props);
}
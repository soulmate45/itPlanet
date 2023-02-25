using itPlanet.repository.postgres;
using itPlanet.repository.postgres.queries;
using itPlanet.repository.postgres.queries.animalType;

namespace itPlanet.repository.animalType;

public class AnimalType : RepositoryResponsibility, IAnimalType
{
    public AnimalType(PostgresDatabase database, PostgresQueries queries) : base(database, queries)
    {
    }

    public PostgresAnimalType Create(string value)
    {
        var query = Queries.AnimalType.Create();
        return GetResultObject<PostgresAnimalType>(query, value);
    }
}
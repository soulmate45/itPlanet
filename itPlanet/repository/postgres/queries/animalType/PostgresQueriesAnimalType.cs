namespace itPlanet.repository.postgres.queries.animalType;

public class PostgresQueriesAnimalType : IQueriesAnimalType
{
    public string Create()
    {
        return "INSERT INTO \"AnimalType\" (value) VALUES ($1) RETURNING *";
    }
}
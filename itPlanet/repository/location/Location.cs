using itPlanet.repository.account;
using itPlanet.repository.postgres;
using itPlanet.repository.postgres.queries;
using itPlanet.repository.postgres.queries.location;

namespace itPlanet.repository.location;

public class Location : RepositoryResponsibility, ILocation
{
    public Location(PostgresDatabase database, PostgresQueries queries) : base(database, queries) {}

    public PostgresLocation Create(double latitude, double longitude)
    {
        var query = Queries.Location.Create();
        return GetResultObject<PostgresLocation>(query, latitude, longitude);
    }
}
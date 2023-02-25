using itPlanet.repository.postgres.queries.location;

namespace itPlanet.repository.location;

public interface ILocation
{
    public PostgresLocation Create(double latitude, double longitude);
}
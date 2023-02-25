using itPlanet.models.location;
using itPlanet.repository.postgres.queries.location;

namespace itPlanet.service.location;

public interface ILocation
{
    public PostgresLocation Create(CreateLocationInput props);
    
}
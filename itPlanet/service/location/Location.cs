using itPlanet.models.location;
using itPlanet.repository;
using itPlanet.repository.postgres.queries.location;

namespace itPlanet.service.location;

public class Location : ServiceResponsibility, ILocation
{
    public Location(Repository repository) : base(repository) {}

    public PostgresLocation Create(CreateLocationInput props)
    {
        if (props.latitude == null || props.latitude < -90 || props.latitude > 90)
        {
            ThrowInvalidRequestField("invalid latitude: {0}", props.latitude);
        }
        if (props.longitude == null || props.longitude < -180 || props.longitude > 180)
        {
            ThrowInvalidRequestField("invalid longitude: {0}", props.longitude);
        }

        return _repository.Location.Create((double)props.latitude, (double)props.longitude);
    }
}
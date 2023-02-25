using itPlanet.models.animalType;
using itPlanet.repository;
using itPlanet.repository.postgres.queries.animalType;

namespace itPlanet.service.animalType;

public class AnimalType : ServiceResponsibility, IAnimalType
{
    public AnimalType(Repository repository) : base(repository) {}

    public PostgresAnimalType Create(CreateAnimalTypeInput props)
    {
        if (props.value == null || props.value.Trim() == "")
        {
            ThrowInvalidRequestField("invalid type: {0}", props.value);
        }

        return _repository.AnimalType.Create(props.value);
    }
}
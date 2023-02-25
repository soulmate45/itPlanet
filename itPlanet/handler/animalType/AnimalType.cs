using itPlanet.models.animalType;
using itPlanet.service;

namespace itPlanet.handler.animalType;

public class AnimalType : HandlerResponsibility, IAnimalType
{
    public AnimalType(Service service) : base(service) {}

    public void Create(RequestContext context)
    {
        var input = context.GetBody<CreateAnimalTypeInput>();
        var animalType = _service.AnimalType.Create(input);
        var output = new CreateAnimalTypeOutput
        {
            id = animalType.Id,
            value = animalType.Value
        };
        context.SendCreated(output);
    }
}
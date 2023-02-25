using itPlanet.repository;
using itPlanet.service.Account;
using itPlanet.service.animalType;
using itPlanet.service.location;

namespace itPlanet.service;

public class Service
{
    public IAccount Account;
    public ILocation Location;
    public IAnimalType AnimalType;
    
    public Service(Repository repository)
    {
        Account = new Account.Account(repository);
        Location = new Location(repository);
        AnimalType = new AnimalType(repository);

    }
}
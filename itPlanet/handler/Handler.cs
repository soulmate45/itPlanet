using itPlanet.handler.Account;
using itPlanet.handler.animalType;
using itPlanet.handler.location;
using itPlanet.server;
using itPlanet.service;

namespace itPlanet.handler;

public class Handler
{
    public readonly IAccount Account;
    public readonly ILocation Location;
    public readonly IAnimalType AnimalType;
        
    public Handler(Service service)
    {
        Account = new Account.Account(service);
        Location = new Location(service);
        AnimalType = new AnimalType(service);
    }

    public Router GetRouter()
    {
        var router = new Router();
        
        router.POST("/registration", Account.Registration);
        // router.GET("/accounts/{accountId}", Account.Get);
        router.POST("/animals/types", AnimalType.Create);
        router.POST("/locations", Location.Create);
        
        return router;
    }
}
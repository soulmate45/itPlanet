using itPlanet.handler.Account;
using itPlanet.handler.location;
using itPlanet.server;
using itPlanet.service;

namespace itPlanet.handler;

public class Handler
{
    public readonly IAccount Account;
    public readonly ILocation Location;
        
    public Handler(Service service)
    {
        Account = new Account.Account(service);
        Location = new Location(service);
    }

    public Router GetRouter()
    {
        var router = new Router();
        
        router.POST("/registration", Account.Registration);
        //router.GET("/accounts/{accountId}", Account.Get);
        router.POST("/locations", Location.Create);
        return router;
    }
}
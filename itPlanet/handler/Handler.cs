using itPlanet.handler.Account;
using itPlanet.server;
using itPlanet.service;

namespace itPlanet.handler;

public class Handler
{
    public readonly IAccount Account;
        
    public Handler(Service service)
    {
        Account = new Account.Account(service);
    }

    public Router GetRouter()
    {
        var router = new Router();
        
        router.POST("/registration", Account.Registration);
        //router.GET("/accounts/{accountId}", Account.Get);
        return router;
    }
}
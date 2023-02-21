using itPlanet.handler.Account;
using itPlanet.service;

namespace itPlanet.handler;

public class Handler
{
    public readonly IAccount Account;
        
    public Handler(Service service)
    {
        Account = new Account.Account(service);
    }
}
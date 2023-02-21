using itPlanet.repository;
using itPlanet.service.Account;

namespace itPlanet.service;

public class Service
{
    public IAccount Account;
    
    public Service(Repository repository)
    {
        Account = new Account.Account(repository);
    }
}
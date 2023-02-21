using itPlanet.repository.postgres;

namespace itPlanet.handler.Account;

public interface IAccount
{
    public void Registration(RequestContext context);
}
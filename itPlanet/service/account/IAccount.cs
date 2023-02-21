using itPlanet.models.account;
using itPlanet.repository.postgres;

namespace itPlanet.service.Account;

public interface IAccount
{
    public PostgresAccount Registration(RegistrationInput props);
    
}
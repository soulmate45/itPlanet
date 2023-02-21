using System.Diagnostics;
using itPlanet.models.account;
using itPlanet.repository;
using itPlanet.repository.postgres;

namespace itPlanet.service.Account;

public class Account : ServiceResponsibility, IAccount
{
    public Account(Repository repository) : base(repository) {}
    
    public PostgresAccount Registration(RegistrationInput props)
    {
        // валидация
        return _repository.Account.Create( props.firstName, 
            props.lastName, props.email, props.password);
        
    }

    

}
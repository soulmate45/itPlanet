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
        if (props.firstName == null || props.firstName.Trim() == "")
        {
            ThrowInvalidRequestField("invalid first_name: {0}", props.firstName);
        }
        
        if (props.lastName == null || props.lastName.Trim() == "")
        {
            ThrowInvalidRequestField("invalid last_name: {0}", props.lastName);
        }
        
        if (props.email == null || props.email.Trim() == "")
        {
            ThrowInvalidRequestField("invalid email: {0}", props.email);
        }
        
        if (props.password == null || props.password.Trim() == "")
        {
            ThrowInvalidRequestField("invalid password: {0}", props.password);
        }
        
        
        // TODO валидация
        return _repository.Account.Create( 
            props.firstName, 
            props.lastName, 
            props.email, 
            props.password);
    }

    

}
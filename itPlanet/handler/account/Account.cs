using itPlanet.models.account;
using itPlanet.service;

namespace itPlanet.handler.Account;

public class Account : HandlerResponsibility, IAccount
{
    public  Account(Service service) : base(service) {}
    
    public void Registration(RequestContext context)
    {
        var input = context.GetBody<RegistrationInput>();
        var account = _service.Account.Registration(input);
        var output = new RegistrationOutput
        {
            id = account.Id,
            firstName = account.FirstName,
            lastName = account.LastName,
            email = account.Email
        };
        context.SendCreated(output);
    }
}
using itPlanet.repository;
using itPlanet.repository.postgres;

namespace itPlanet.service;

public class ServiceResponsibility
{
    protected readonly  Repository _repository;
    public ServiceResponsibility(Repository repository)
    {
        _repository = repository;
    }

    protected void ThrowInvalidRequestField(string template, params  string[] args)
    {
        var message = String.Format(template ?? "", args);
        throw new InvalidRequestFieldException(message);
    }
}
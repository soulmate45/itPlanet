using itPlanet.repository;

namespace itPlanet.service;

public class ServiceResponsibility
{
    protected readonly  Repository _repository;
    public ServiceResponsibility(Repository repository)
    {
        _repository = repository;
    }
}
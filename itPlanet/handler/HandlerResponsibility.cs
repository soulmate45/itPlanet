using itPlanet.service;

namespace itPlanet.handler;

public class HandlerResponsibility
{
    protected readonly Service _service;

    public HandlerResponsibility(Service service)
    {
        _service = service;
    }
}
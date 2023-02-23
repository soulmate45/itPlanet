using itPlanet.handler;

namespace itPlanet.server;

public class RouterPoint
{
    public string EndPoint;
    public HttpMethod Method;
    public Action<RequestContext> Handler;
}
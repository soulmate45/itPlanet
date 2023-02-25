﻿using itPlanet.models.location;
using itPlanet.service;

namespace itPlanet.handler.location;

public class Location : HandlerResponsibility, ILocation
{
    public Location(Service service) : base(service) {}
    
    public void Create(RequestContext context)
    {
        var input = context.GetBody<CreateLocationInput>();
        var location = _service.Location.Create(input);
        var output = new CreateLocationOutput
        {
            id = location.Id,
            latitude = location.Latitude,
            longitude = location.Longitude
        };
        context.SendCreated(output);
    }
}
namespace itPlanet.repository.postgres;

public class InvalidRequestFieldException: Exception
{
    public InvalidRequestFieldException(string message) : base(message) {}

}
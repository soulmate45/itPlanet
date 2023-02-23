namespace itPlanet.repository.postgres;

public class RequestBodyDeserializeException: Exception
{
    private const string MESSAGE = "request body deserialize";
    public RequestBodyDeserializeException() : base(MESSAGE) {}

}
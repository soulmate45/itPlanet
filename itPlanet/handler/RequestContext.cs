using System.Net;
using System.Text;
using itPlanet.models.account;
using itPlanet.repository.postgres;
using Newtonsoft.Json;
using Npgsql.Replication.PgOutput.Messages;

namespace itPlanet.handler;

public class RequestContext
{
    private readonly HttpListenerContext _context;
    private readonly HttpListenerRequest _request;
    private readonly HttpListenerResponse _response;
    public RequestContext(HttpListener listener)
    {
         _context = listener.GetContext();
         _request = _context.Request;
         _response = _context.Response;
    }

    public TBody GetBody<TBody>()
    {
        string stringBody;
        using (var reader = new StreamReader(_request.InputStream, _request.ContentEncoding))
        {
            stringBody = reader.ReadToEnd();
        }

        TBody? body = JsonConvert.DeserializeObject<TBody>(stringBody);
        if (body == null)
        {
            throw new RequestBodyDeserializeException();
        }

        return body;
    }
    public string GetEndPoint()
    {
        return _request.RawUrl ?? "";
    }
    public string GetMethod()
    {
        return _request.HttpMethod;
    }

    public void SendCreated(RegistrationOutput output)
    {

         SendRequest(output, HttpStatusCode.Created);
    }
    public void SendBadRequest(string errMessage)
    {
        SendRequest(errMessage, HttpStatusCode.BadRequest);
    }

    private void SendRequest(object? output, HttpStatusCode code)
    {
        var outputString = JsonConvert.SerializeObject(output);
        var buffer = Encoding.UTF8.GetBytes(outputString);

        _response.StatusCode = (int)code;
        using var outputStream = _response.OutputStream;
        outputStream.Write(buffer, 0, buffer.Length);

    }

    public void SendNotFound()
    {
        SendRequest(null, HttpStatusCode.NotFound);
    }
}
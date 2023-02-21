using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using itPlanet.configs;
using itPlanet.repository;
using itPlanet.repository.account;
using itPlanet.repository.postgres;
using Newtonsoft.Json;
using Npgsql;

const string CONFIG_FILE_PATH = "configs/config.json";

// Загрузка конфига
    var config = new Config();
    config.Load(CONFIG_FILE_PATH);

// Cоединение с базой данных и его проверка
var database = new PostgresDatabase(config);

// Создание слоя для handler, service, repository 
var repository = new Repository(database);

var account = repository.Account.Get("egor.unknown05@mail.ru", "1234");
Console.WriteLine(account.Email);
// Запустить сервер (слушатель на порт)

// Отключить сервер (безопасно самостоятельно разорвать соединение с базой данных)





var connectionString = "Host=localhost; Username=postgres;Password=1234; Database=2023_it_planet";
var connection = new NpgsqlConnection(connectionString);
    //если конекшн заебись, то сервер запустится.
try
{
    connection.Open();
}
catch (Exception e)
{
    Console.WriteLine(e.Message); 
    return;
}
finally
{
    Console.WriteLine("Connection to database successful");
}

var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8080/");
listener.Start();
Console.WriteLine("Server is listener...");

while (true)
{
    Console.WriteLine("Waiting request...");
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;

    var requestParams = request.QueryString;
    var method = request.HttpMethod;
    var endPoint = request.RawUrl;
    if (endPoint == null)
    {
        throw new Exception("end point is null");
    };
    
    
    if (endPoint == "/locations")
    {
        if (method == "POST")
        {
            string body;
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                body = reader.ReadToEnd();
            }

            CreateLocationInput? input = JsonConvert.DeserializeObject<CreateLocationInput>(body);
            if (input == null)
            {
                throw new Exception("error deserialize object");
            }
           
            var tx = connection.BeginTransaction();
            
            
            // Запрос на добавление данных в таблицу 
          
            long id = 0;
            // 1. Создать запрос
            var command = new NpgsqlCommand("INSERT INTO \"LocationPoint\" (latitude, longitude)" +
                                                    " VALUES (@latitude, @longitude) RETURNING id", connection);
            
            // 2. В запрос подставить данные, которые мы получили
            command.Parameters.AddWithValue("latitude", input.latitude);
            command.Parameters.AddWithValue("longitude", input.longitude);
            
            // 3. Выполнить запрос
            var queryReader = command.ExecuteReader();
            var isMoveCursorResult = queryReader.Read();
            if (isMoveCursorResult)
            {
                var idString = queryReader["id"].ToString();
                if (idString == null)
                {
                    throw new Exception("id is null");
                }
                
                id = long.Parse(idString);
            } 
            
            var output = new CreateLocationOutput();
            output.id = id;
            output.latitude = input.latitude;
            output.longitude = input.longitude;
            
            var outputString = JsonConvert.SerializeObject(output);
            var buffer = Encoding.UTF8.GetBytes(outputString);

            response.StatusCode = (int)HttpStatusCode.Created;
            using (var outputStream = response.OutputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}

class CreateLocationInput
{
    public  double latitude { get; set; }
    public  double longitude { get; set; }
}

class CreateLocationOutput
{
    public long id { get; set; }
    public  double latitude { get; set; }
    public  double longitude { get; set; }
}
 
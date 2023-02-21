using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using it_planet.repository.postgres;
using itPlanet.repository.postgres;
using itPlanet.repository.postgres.queries;
using itPlanet.repository.postgres.queries.account;
using Npgsql;

namespace itPlanet.repository;

public class RepositoryResponsibility
{
    private readonly NpgsqlConnection _connection;
    protected readonly PostgresQueries Queries;
    
    protected RepositoryResponsibility(PostgresDatabase database, PostgresQueries queries)
    {
        _connection = database.GetConnection();
        Queries = queries;
        
    }

    protected TResultObject GetResultObject<TResultObject>(string query, params Object[] args) where TResultObject : new()
    {
        var result = new TResultObject();

        var command = new NpgsqlCommand(query, _connection);
        
        foreach (var arg in args)
        {
            command.Parameters.Add(new NpgsqlParameter{Value = arg});
        }
        
        var queryReader = command.ExecuteReader();
        var isMoveCursorResult = queryReader.Read();
        if (!isMoveCursorResult)
        {
            throw new NpgsqlRowNotFoundException();
        }

        var resultType = typeof(TResultObject);
           var properties =resultType.GetProperties();

           foreach (var property in properties)
           {
              using var p = property.CustomAttributes.GetEnumerator();
              while (p.MoveNext())
              {
                  if (p.Current.AttributeType == typeof(PostgresNameAttribute))
                  {

                      var value = p.Current.ConstructorArguments[0].Value;
                      if (value == null)
                      {
                          throw new NpgsqlException("required class database map not found");
                      }

                      var postgresName = value.ToString();
                      var rowValue = queryReader[postgresName];
                      property.SetValue(result, rowValue);
                  }
              }
              
          }
        return result;
    }
}
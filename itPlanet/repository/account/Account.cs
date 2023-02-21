using System.Data;
using itPlanet.repository.postgres;
using itPlanet.repository.postgres.queries;
using Npgsql;

namespace itPlanet.repository.account;

public class Account : RepositoryResponsibility, IAccount
{

    public Account(PostgresDatabase database, PostgresQueries queries) : base(database, queries) {}


    public PostgresAccount Create(string firstName, string lastName, string email, string password)
    {
        
        var query = Queries.Account.Create();        
        return GetResultObject<PostgresAccount>(query, firstName, lastName, email, password);
        
    }

    public PostgresAccount Get(string email, string password)
    {

        var query = Queries.Account.Get();
        return GetResultObject<PostgresAccount>(query, email, password);
        
    }
}

    

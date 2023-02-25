
using itPlanet.repository.postgres.queries.account;
using itPlanet.repository.postgres.queries.location;

namespace itPlanet.repository.postgres.queries;

public class PostgresQueries
{
    public IQueriesAccount Account;
    public IQueriesLocation Location;

    public PostgresQueries()
    {
        Account = new PostgresQueriesAccount();
        Location = new PostgresQueriesLocation();
    }
}
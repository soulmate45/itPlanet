
using itPlanet.repository.postgres.queries.account;

namespace itPlanet.repository.postgres.queries;

public class PostgresQueries
{
    public IQueriesAccount Account;

    public PostgresQueries()
    {
        Account = new PostgresQueriesAccount();
    }
}
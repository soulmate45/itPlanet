using itPlanet.repository.account;
using itPlanet.repository.postgres;
using itPlanet.repository.postgres.queries;

namespace itPlanet.repository;

public class Repository
{
  public IAccount Account;

  public Repository(PostgresDatabase database)
  { 
      var queries = new PostgresQueries();  
      Account = new Account(database, queries);
  }
}

using itPlanet.repository.account;
using itPlanet.repository.animalType;
using itPlanet.repository.location;
using itPlanet.repository.postgres;
using itPlanet.repository.postgres.queries;

namespace itPlanet.repository;

public class Repository
{
  public IAccount Account;
  public ILocation Location;
  public IAnimalType AnimalType;

  public Repository(PostgresDatabase database)
  { 
      var queries = new PostgresQueries();  
      Account = new Account(database, queries);
      Location = new Location(database, queries);
      AnimalType = new AnimalType(database, queries);
  }
}
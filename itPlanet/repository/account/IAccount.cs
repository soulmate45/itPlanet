using itPlanet.repository.postgres;

namespace itPlanet.repository.account;

public interface IAccount
{
    public PostgresAccount Create(string firstName, string lastName, string email, string password);
    public PostgresAccount Get(string email, string password); 
}
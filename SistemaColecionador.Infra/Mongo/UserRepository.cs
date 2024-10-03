using MongoDB.Driver;
using SistemaColecionador.Domain.Entities;
using SistemaColecionador.Domain.Interfaces;
using SistemaColecionador.Domain.Interfaces.Repositories;

namespace SistemaColecionador.Infra.Mongo;

public sealed class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _repo;

    public UserRepository(IMongoSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _repo = database.GetCollection<User>(settings.UserCollectionName);
    }

    public void CreateUser(User user) => _repo.InsertOne(user);

    public User GetUserByCredentials(string username, string password)
    {
        return _repo.Find(user => user.UserName!.Equals(username) &&
            user.Password!.Equals(password)).FirstOrDefault();
    }
}
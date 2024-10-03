using SistemaColecionador.Domain.Entities;

namespace SistemaColecionador.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    User GetUserByCredentials(string username, string password);

    void CreateUser(User user);
}
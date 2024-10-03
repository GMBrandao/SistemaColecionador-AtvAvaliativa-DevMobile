using SistemaColecionador.Domain.Dto;

namespace SistemaColecionador.Domain.Interfaces.Services;

public interface IUserService
{
    UserResponseDto? GetUserByCredentials(UserLoginDto login);

    void CreateUser(CreateUserDto user);
}
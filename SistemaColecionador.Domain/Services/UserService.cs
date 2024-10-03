using SistemaColecionador.Domain.Dto;
using SistemaColecionador.Domain.Entities;
using SistemaColecionador.Domain.Interfaces.Repositories;
using SistemaColecionador.Domain.Interfaces.Services;

namespace SistemaColecionador.Domain.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(CreateUserDto userDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name!,
            UserName = userDto.UserName,
            Password = userDto.Password
        };

        _userRepository.CreateUser(user);
    }

    public UserResponseDto? GetUserByCredentials(UserLoginDto login)
    {
        if (string.IsNullOrWhiteSpace(login.UserName) || string.IsNullOrWhiteSpace(login.Password))
            return null;

        var user = _userRepository.GetUserByCredentials(login.UserName!, login.Password!);

        if (user == null) return null;

        return new UserResponseDto
        {
            Name = user.Name!,
            UserName = user.UserName,
            Success = true
        };
    }
}
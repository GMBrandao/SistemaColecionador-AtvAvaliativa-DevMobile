namespace SistemaColecionador.Domain.Dto;

public sealed class CreateUserDto
{
    public string? UserName { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }
}
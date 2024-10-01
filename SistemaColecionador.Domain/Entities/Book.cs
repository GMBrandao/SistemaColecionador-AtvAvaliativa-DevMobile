namespace SistemaColecionador.Domain.Entities;

public sealed class Book
{
    public Guid Id { get; set; }

    public string? Nome { get; set; }

    public int Ano { get; set; }

    public string? Autor { get; set; }

    public string? Editora { get; set; }

    public string? Ilustrador { get; set; }

    public int Paginas { get; set; }
}